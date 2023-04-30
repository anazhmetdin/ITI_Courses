function increment() {
    alert("Incrementing")
}

function decrement() {
    DotNet.invokeMethodAsync("RazorClassLibrary", 'decrement').then((data) => {

        const myElement = document.getElementById('count');
        myElement.value = data;

    })
}