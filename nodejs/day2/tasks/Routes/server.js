const http = require("http");
const fs = require("fs");

const indexHtml = fs.readFileSync("./Client/index.html").toString();
let welcomeHtml = fs.readFileSync("./Client/HTML/welcome.html").toString();
const notfoundHtml = fs.readFileSync("./Client/HTML/notfound.html").toString();
const styleCSS = fs.readFileSync("./Client/style.css").toString();
const scriptJS = fs.readFileSync("./Client/script.js").toString();
const favIcon = fs.readFileSync("./Client/Icons/favicon.ico");

const clients = JSON.parse(fs.readFileSync("clients.json"));

http.createServer((req, res)=>{
    console.log(req.url);
    //#region GET
    if(req.method == "GET"){
        switch(req.url){
            case '/':
            case '/index':
            case '/client/index':
            case '/index.html':
            case '/client/index.html':
                res.write(indexHtml);
            break;
            case '/getall':
                res.write(JSON.stringify(clients));
            break;
            case '/':
            case '/welcome':
            case '/client/welcome':
            case '/welcome.html':
            case '/client/welcome.html':
                res.write(welcomeHtml);
            break;
            case '/style.css':
            case '/client/style.css':
                res.write(styleCSS);
            break;
            case '/script.js':
            case '/client/script.js':
                res.write(scriptJS);
            break;
            case '/favicon.ico':
            case '/client/favicon.ico':
            case '/client/Icons/favicon.ico':
                res.write(favIcon);
            break;
            default:
                res.write(notfoundHtml)
            break;
        }
        res.end();
    }
    //#endregion
    
    //#region POST
    else if(req.method=="POST"){
        req.on("data",(data)=>{
            
            const input = decodeURIComponent(data.toString()).split('&');

            let field;
            var client = {};

            for (let i = 0; i < input.length; i++)
            {
                field = input[i].split("=");
                client[field[0]] = field[1];
            }
            
            clients.unshift(client);
            fs.writeFile("clients.json", JSON.stringify(clients, null, 4), ()=>{});
        })
        req.on("end",()=>{
            for (const [key, value] of Object.entries(clients[0])) {
                welcomeHtml = welcomeHtml.replace(`{${key}}`, value);
            }
            res.write(welcomeHtml);
            res.end();
        })
    }
    //#endregion
    
    //#region Default
    else{
        res.end("Please Select GEt OR POST Method");
    }
    //#endregion
}).listen(7001,()=>{console.log("Listining on Port 7001")})