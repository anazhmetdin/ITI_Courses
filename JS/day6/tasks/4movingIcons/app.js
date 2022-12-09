var left, right, bottom;
var leftSize, rightSize, bottomSize;
var progress = 0, moving = false, interval, step=1, direction=1;
var moveButton, icon1Info, icon2Info, topInfo;

var move, reset;

document.body.onload = ()=> {
    left = document.getElementById('left'); 
    right = document.getElementById('right'); 
    bottom = document.getElementById('bottom');
    
    moveButton = document.getElementById('start');

    icon1Info = document.getElementById('icon1Style');
    icon2Info = document.getElementById('icon2Style');
    topInfo = document.getElementById('topStyle');
    
    function setInfo() {
        icon1Info.innerText = parseFloat(left.getBoundingClientRect().x).toFixed(0);
        icon2Info.innerText = parseFloat(right.getBoundingClientRect().x).toFixed(0);
        topInfo.innerText = parseFloat(bottom.getBoundingClientRect().y).toFixed(0);
    }

    setInfo();
    
    leftSize = parseInt(left.getBoundingClientRect().width);
    rightSize = parseInt(right.getBoundingClientRect().width);
    bottomSize = parseInt(bottom.getBoundingClientRect().height);
    
    move = function () {
        if (moving) {
            clearInterval(interval);
            moveButton.innerText = 'Go';
            moving = false;
        } else {
    
            interval = setInterval(()=>{
                if (direction == 1 && progress + step > 100) {
                    direction = -1;
                } else if (direction == -1 && progress - step < 0) {
                    direction = 1;
                }
    
                progress += step * direction;
                
                
                left.style.left = `calc(${progress}% - ${progress*leftSize/100}px)`;
                right.style.right = `calc(${progress}% - ${progress*rightSize/100}px)`;
                bottom.style.bottom = `calc(${progress}% - ${progress*bottomSize/100}px)`;
    
                setInfo();
                
            }, 10);
    
            moveButton.innerText = 'Stop';
            moving = true;
        }
    }
    
    reset = function () {
        
        progress = 0;
        direction = 1;
        moving = false;
    
        clearInterval(interval);
        moveButton.innerText = 'Go';
    
        left.style.left = `0%`;
        right.style.right = `0%`;
        bottom.style.bottom = `0%`;
        
        setInfo();
    }
};
