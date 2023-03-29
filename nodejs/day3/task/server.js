const express  = require("express");
const fs    = require("fs");
const path  = require("path");
var engines = require('consolidate');
const cors  = require('cors');
const bodyParser = require('body-parser');

const app = express();
const port = process.env.PORT || 7008;

app.use(express.static('Client'));
// app.use(express.json());
app.use(cors(
    {origin: "*"}
));
app.use(bodyParser.urlencoded({ extended: true }));

app.set('views', path.join(__dirname, 'Client', 'HTML'));
app.engine('html', engines.mustache);
app.set('view engine', 'html');

const clients = JSON.parse(fs.readFileSync("clients.json"));


app.post('/', (req, res) => {
    res.render(path.join(__dirname, 'Client', 'HTML', 'welcome.html'), req.body);
    clients.unshift(req.body);
    fs.writeFile("clients.json", JSON.stringify(clients, null, 4), ()=>{});
});

app.get('/getall', (req, res) => {
    res.send(JSON.stringify(clients));
});

app.get('/*', (req, res) => {
    res.status(404);
    res.sendFile(path.join(__dirname, 'Client', 'HTML', 'notfound.html'));
});

app.listen(port, () => {
  console.log(`listening on port expresss://localhost:${port}`)
});