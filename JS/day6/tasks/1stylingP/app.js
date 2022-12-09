document.addEventListener('DOMContentLoaded', (event)=>{
    const pElement = document.getElementById('p');
    
    for (var input of document.getElementsByTagName('input')) {
        input.addEventListener('change', (event)=>{
            if (event.target.checked) {
                pElement.style[event.target.name] = event.target.value;
            }
        });
    }
});
