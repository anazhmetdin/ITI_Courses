const mongoose = require("mongoose");

mongoose.set('strictQuery', false);
mongoose.connect("mongodb://127.0.0.1:27017/DoctorsPatients");

//2)Create Schema
usersSchema = new mongoose.Schema({
    name: {type: String, required: true},
    age: {type: Number, required: true},
    email: {
                type: String,
                required: true,
                unique: true,
                match: /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/
            },
    password: {type: String, required: true}
})

//3)Connect Schema With Collection
module.exports = mongoose.model("users",usersSchema);