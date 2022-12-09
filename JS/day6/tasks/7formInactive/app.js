var active = false;

var evt = new CustomEvent('inactive')

document.addEventListener('DOMContentLoaded', ()=>{
    
    const submitButton = document.getElementById('submit');
    
    setTimeout(() => {
        if (!active) {
            submitButton.dispatchEvent(evt);
        }
    }, 3000); // 3 seconds instead of 30

    submitButton.addEventListener('click', (event)=>{
        event.preventDefault();
        var go = confirm('Are you sure you want to submit?');
        if (go) {
            window.location.assign('');
        }
    });

    submitButton.addEventListener('inactive', (event)=>{
        event.target.disabled = true;
    });

    for (var input of document.querySelectorAll('input[type]:not([type="submit"]), select')) {
        input.addEventListener('change', ()=>{
            active = true;
        });
    }
});