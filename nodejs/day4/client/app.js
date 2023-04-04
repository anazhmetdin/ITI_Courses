(() => {
    const socket = io();
    const input = document.getElementById("message-input");
    const sendBtn = document.getElementById("send");
    const messages = document.getElementById("messages");
    const typing = document.getElementById("typing");
    const chat = document.querySelector(".card-body");
    let myName;

    let online = document.getElementById("online");

    function GenerateMessage(direction, color, message, username) {
        let user = "", message_direction = "";
        if (username)
        {
            user = `<div class="fw-bold mb-1"> ${username}: </div>`
        }

        if (direction == "end")
        {
            message_direction = "d-flex flex-row-reverse"
        }

        return `<div class="align-self-${direction} col-8 ${message_direction}">
                    <div class="bg-${color}-subtle py-2 px-4 rounded-3 d-inline-block">
                        ${user}
                        <div class="mb-1"> ${message} </div>
                    </div>
                </div>`
    }

    function ChatIsScrolled() {        
        let scroll = false;
        
        if (Math.abs(chat.scrollHeight - chat.scrollTop - chat.clientHeight) < 1)
            scroll = true;

        return scroll;
    }

    function RescrollChat(scroll) {
        if (scroll)
            chat.scrollTop = chat.scrollHeight;
    }

    sendBtn.addEventListener('click', () => {
        const scroll = ChatIsScrolled();

        const message = input.value;
        if (message.trim() != "")
        {
            socket.emit('message', message);
            messages.innerHTML += GenerateMessage("end", "success", message.trim());
            input.value = "";
            socket.emit('stoppedtyping')
        }

        RescrollChat(scroll);
    })

    input.addEventListener("keypress",function(e){
        if(e.key=='Enter'){
            sendBtn.click();
            e.preventDefault();
        }
    });

    input.addEventListener("input",function(e){
        if (input.value == '')
            socket.emit('stoppedtyping')
        else
            socket.emit('typing');
    });

    socket.on('event', (what) => {
        const scroll = ChatIsScrolled();

        messages.innerHTML += `<div class="align-self-center"> - ${what} - </div>`
        
        RescrollChat(scroll);     
    })

    socket.on('typing', (username) => {

        const scroll = ChatIsScrolled();

        if (username.length > 0 && username != myName)
            typing.innerText = `- ${username} is typing... -`
        else
            typing.innerText = ``

        RescrollChat(scroll);
    })
    
    socket.on('count', (count) => {
        online.innerText = count;        
    })

    socket.on('username', (username) => {
        myName = username;
        document.getElementById('username').innerHTML = username;        
    })

    socket.on('message', (message) => {

        const scroll = ChatIsScrolled();

        messages.innerHTML += GenerateMessage("start", "primary", message.message, message.username);

        RescrollChat(scroll);
    })

})();