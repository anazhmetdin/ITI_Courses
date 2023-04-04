const express  = require("express");
const http  = require("http");
const {Server} = require("socket.io");
const { generateUsername } = require("unique-username-generator");


const app = express();
const server = http.createServer(app);
const io = new Server(server);

const port = process.env.PORT || 7008;

app.use(express.static('Client'));app.use(express.json());
app.use(express.json());

app.get('/', (req, res) => {
    res.sendFile(__dirname + '/Client/index.html');
});

const TypingList = [];

function SendCount() {
    io.emit("count", io.sockets.sockets.size);
}

function RemoveTyping(username) {    
    TypingList.splice(TypingList.indexOf(username), 1);        
    io.emit('typing', TypingList.slice(-1));
}

io.on('connection', (socket) => {
    SendCount()
    const username = generateUsername();
    socket.emit('username', username);
    socket.emit('typing', TypingList.slice(-1));

    socket.broadcast.emit('event', `${username} connected`);

    socket.on('message', (message) => {
        socket.broadcast.emit('message', {message, username} );
    });
    
    socket.on('disconnect', () => {
        SendCount();
        RemoveTyping(username);
        socket.broadcast.emit('event', `${username} disconnected`);
    });

    socket.on('typing', () => {
        if (TypingList.indexOf(username) == -1)
        {
            TypingList.push(username);
            socket.broadcast.emit('typing', TypingList.slice(-1));
        }
    })

    socket.on('stoppedtyping', () => {
        RemoveTyping(username);
    })
});

server.listen(port, () => {
    console.log(`listening on port http://localhost:${port}`)
});