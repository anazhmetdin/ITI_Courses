
document.getElementById("ClientInfo").onsubmit = () => {
    let valid = true;

    if (document.getElementById("name").value.length < 2)
    {
        window.alert("Name length must be larger than 2");
        valid = false;
    }
    else if (!document.getElementById("phone").value.match(/[0-9]{11}/))
    {
        window.alert("Invalid phone number, must be composed of 11 digits");
        valid = false;
    }
    else if (document.getElementById("address").value.length < 16)
    {
        window.alert("Invalid address, must be longer than 16");
        valid = false;
    }
    else if (!document.getElementById("email").value.match(/[a-z]{1}[a-z0-9]+@[a-z]+\.[a-z]+/i))
    {
        window.alert("Invalid email");
        valid = false;
    }

    return valid;
};

document.getElementById("GetAll").onclick = () => {
    
    fetch('http://localhost:7008/getall')
    .then(function(response) {
        return response.json();
    })
    .then(function(clients) {
        const table = document.getElementById("clients");
        table.innerHTML = `
        <table>
            <thead>
                <tr class="table100-head">
                    <th>Name</th>
                    <th>Phone ID</th>
                    <th>Address</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                ${
                    (()=>{
                        let body = ""
                        for (let client of clients)
                            body += `<tr>
                                <td>${client.name}</td>
                                <td>${client.phone}</td>
                                <td>${client.address}</td>
                                <td>${client.email}</td>
                            </tr>`
                        return body;
                    })()
                }
            </tbody>
        </table>
        `
    });
}