
function generate() {
    const message = document.getElementsByTagName('textarea')[0].value;
    const image   = document.querySelector('input[name="card"]:checked').value;
    const card    = window.open("./card.html", "_blank", `fullscreen=0,height=700,width=700,top=300,left=300`);
    
    card.addEventListener('DOMContentLoaded', ()=>{   
        card.document.body.style.display = 'flex';  
        card.document.body.style.flexDirection = 'column'; 
        card.document.body.style.alignItems = 'center';

        const imageElement        = document.createElement('img');
        imageElement.src          = `./imgs/${image}.jpg`;
        imageElement.style.margin = 'auto';
        imageElement.style.height = '35rem';
    
        const messageElement          = document.createElement('p');
        messageElement.innerText      = message;
        messageElement.style.color    = 'green';
        messageElement.style.fontSize = '2rem';
        
        const closeButton     = document.createElement('button');
        closeButton.innerText = 'Close Preview';
        closeButton.onclick   = ()=>{card.close()};
        
        card.document.body.appendChild(imageElement);
        card.document.body.appendChild(messageElement);
        card.document.body.appendChild(closeButton);
    });
}