document.addEventListener("DOMContentLoaded", function(event) {

    const name = getCookies('name');
    const gender = getCookies('gender');
    const color = getCookies('color');

    const uuid = name+gender+color+getCookies('age')+'_counter';
    console.log(uuid, hasCookie(uuid));
    
    setCookie(uuid, hasCookie(uuid)? parseInt(getCookies(uuid))+1 : 1);

    document.getElementById('profile').src = gender === 'male' ? './imgs/1.jpg' : './imgs/2.jpg';

    document.getElementById('name').style.color = color;
    document.getElementById('name').innerText = name;
    
    document.getElementById('counter').style.color = color;
    document.getElementById('counter').innerText = getCookies(uuid);
});