document.addEventListener('DOMContentLoaded', (event)=>{
    const main = document.getElementsByClassName('center')[0];
    const header = document.getElementById('header');
    const footer = document.createElement('div');
    const footerImg = document.createElement('img');
    
    footerImg.src = header.getElementsByTagName('img')[0].src;

    footer.appendChild(footerImg);
    footer.id = 'footer';
    
    main.appendChild(footer);

    header.style.display = 'flex';
    header.style.flexDirection = 'row-reverse';
    
    footer.style.display = 'flex';
});