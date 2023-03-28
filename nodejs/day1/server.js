const http = require("http");
const fs = require("fs");


http.createServer((req,res)=>{
    
    if(req.url != "/favicon.ico"){
        
        let result, operand = 0;
        const params = req.url.split('/');
        const operator = params[1].toLowerCase();
        
        if (operator)
        {
            for (let i = 2; i < params.length; i++)
            {
                if (isFinite(params[i]) || params[i] != '')
                {
                    let num = Number.parseInt(params[i]);
                    if (result == undefined) { result = num; }
                    else
                    {
                        if (operator == 'add')
                        {
                            result += num;
                        }
                        else if (operator == 'multiply')
                        {
                            result *= num;
                        }
                        else if (operator == 'subtract')
                        {
                            result -= num;
                        }
                        else if (operator == 'divide')
                        {
                            if (num == 0)
                            {
                                res.write(`Can't divide by 0`);
                                res.end();
                                return;
                            }
                            result /= num;
                        }
                        else
                        {
                            res.write(`Invalid Operator`);
                            res.end();
                            return;
                        }
                    }                    
                }
                else
                {
                    res.write(`Invalid operand: ${params[i]}`);
                    res.end();
                    return;
                }
            }
        }
        else
        {
            res.write(`No operator was found`);
            res.end();
            return;
        }
        
        if (result == undefined) { result = 0; }
        
        fs.appendFile("log.txt", `${req.url} = ${result}\n`, ()=>{});

        res.write(result.toString())
        res.end();
    }
    
}).listen(7000)
