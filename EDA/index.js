const { ServiceBusClient } = require("@azure/service-bus");
const express = require("express");
const mongoose = require("mongoose");

const EventType = {
    Created: 0,
    Updated: 1,
    Deleted: 2
};

// Define connection string and related Service Bus entity names here
const connectionString = "Endpoint=sb://edatest.servicebus.windows.net/;SharedAccessKeyName=usersConsumer;SharedAccessKey=tLQEKz6IAdettKPsKhIlIGOQD2fuBeFls+ASbL7/IhI=;EntityPath=users";
const queueName = "users";

const sbClient = new ServiceBusClient(connectionString);

const receiver = sbClient.createReceiver(queueName);
const sender = sbClient.createSender(queueName);

const app = express();

// Include the built-in body-parser middleware
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Connect to MongoDB
mongoose.connect("mongodb://127.0.0.1:27017/", {
    useNewUrlParser: true,
    useUnifiedTopology: true
});

// Define user schema
const userSchema = new mongoose.Schema({
    name: String,
    email: String,
    age: Number
});

// Define user model
const User = mongoose.model("User", userSchema);

// Define event schema
const eventSchema = new mongoose.Schema({
    type: Number,
    data: Object,
    timestamp: Date
});

// Define event model
const Event = mongoose.model("UserEvent", eventSchema);

// Create a new user
app.post("/users", async (req, res) => {
    console.log(req.body)
    const { name, email, age } = req.body;

    const user = new User({
        name,
        email,
        age
    });

    await user.save();

    const event = new Event({
        type: EventType.Created,
        data: user,
        timestamp: new Date()
    });

    await event.save();
    const message = {
        body: event,
        contentType: "application/json"
    };
    sender.sendMessages(message);

    res.send(user);
});

// Get all users
app.get("/users", async (req, res) => {
    const users = await User.find();

    res.send(users);
});

// Get a single user by ID
app.get("/users/:id", async (req, res) => {
    const { id } = req.params;

    try {
        const user = await User.findById(id);

        res.send(user);
    }
    catch {
        res.status(404).send();
    }
});

// Update a user by ID
app.put("/users/:id", async (req, res) => {
    const { id } = req.params;
    const { name, email, age } = req.body;

    try {
        const user = await User.findByIdAndUpdate(
            id,
            {
                name,
                email,
                age
            },
            { new: true }
        );

        const event = new Event({
            type: EventType.Updated,
            data: user,
            timestamp: new Date()
        });

        await event.save();
        const message = {
            body: event,
            contentType: "application/json"
        };
        sender.sendMessages(message);

        res.send(user);
    }
    catch {
        res.status(404).send();
    }
});

// Delete a user by ID
app.delete("/users/:id", async (req, res) => {
    const { id } = req.params;

    try {
        await User.findByIdAndDelete(id);

        const event = new Event({
            type: EventType.Deleted,
            data: { id },
            timestamp: new Date()
        });

        await event.save();
        const message = {
            body: event,
            contentType: "application/json"
        };
        sender.sendMessages(message);

        res.send({ message: "User deleted successfully" });
    }
    catch {
        res.status(404).send();
    }
});

app.listen(3000, async () => {
    console.log("Server started")

    await User.deleteMany({});
    const events = await Event.find().sort({ timestamp: -1 }).exec();
    //console.log(events)
    events.forEach(async (event) => {
        switch (event.type) {
            case EventType.Created:
                // Handle Created event
                const user = new User(event.data);
                await user.save();
                break;
            case EventType.Updated:
                // Handle Updated event
                console.log(event)
                await User.findByIdAndUpdate(
                    event.data.id,
                    {
                        "name": event.data.name,
                        "email": event.data.email,
                        "age": event.data.age
                    },
                    { new: true }
                );
                break;
            case EventType.Deleted:
                // Handle Deleted event
                await User.findByIdAndDelete(event.data.id);
                break;
        }
    });
})
/*amqp.connect('Endpoint=sb://edatest.servicebus.windows.net/;SharedAccessKeyName=consumer;SharedAccessKey=52PB9mxFm+RoAPcRvl/x7Q1Co1vCRuyvf+ASbOEmxA8=', function (error, connection) {
  if (error)
    throw error;

  connection.createChannel(function (error1, channel) {
    if (error1)
      throw error1;

    var exchange = "usersbus";

    channel.assertExchange(exchange, 'fanout');
    channel.assertQueue('usersbus.shipping', null, function (error2, q) {
      if (error2)
        throw error2;

      channel.bindQueue(q.queue, exchange);

      console.log("Waiting for messages in usersbus.shipping queue");

      channel.consume(q.queue, function (msg) {
        var userEvent = JSON.parse(msg.content.toString());
        console.log("===============================");
        console.log("Received message");
        processUserEvent(userEvent);
        console.log("===============================");
        channel.ack(msg);
      });
    });

  });

  function processUserEvent(userEvent) {
    console.log("Processing User Event")
    console.log(userEvent);

    var userData = {
      _id: userEvent.userData.id,
      name: userEvent.userData.name,
      address: userEvent.userData.address,
    };

    if (userEvent.type == EventType.Created)
      usersCollection.insertOne(userData);
    if (userEvent.type == EventType.Updated)
      usersCollection.updateOne({ '_id': userData._id }, { $set: userData });
    if (userEvent.type == EventType.Deleted)
      usersCollection.deleteOne({ '_id': userData._id });
  }

});*/