function myEvaluate(operand1, operator, operand2) {
    if (operator === '+') {
        return parseFloat(operand1) + parseFloat(operand2);
    } else if (operator === '-') {
        return parseFloat(operand1) - parseFloat(operand2);
    } else if (operator === '*') {
        return parseFloat(operand1) * parseFloat(operand2);
    } else if (operator === '/') {
        return parseFloat(operand1) / parseFloat(operand2);
    }
}

document.addEventListener("DOMContentLoaded", function(event) {
    const calcScreen = document.getElementById('screen');
    var numbers = [], numbersIndex = 0, operators = ['+'], operatorsIndex = 0;
    
    for (var button of document.getElementsByClassName('number')) {
        button.addEventListener('click', (event) => {
            // chek if not decimal point, or current number doesn't have point already
            if (event.target.innerText != '.' || numbers[numbersIndex].indexOf('.') == -1) {
                calcScreen.innerText += event.target.innerText;
                    
                if (numbers.length == numbersIndex) {
                    numbers[numbersIndex] = '0';
                    operatorsIndex++;
                }
    
                numbers[numbersIndex] += event.target.innerText;
            }
        });
    }

    for (var button of document.getElementsByClassName('operator')) {
        button.addEventListener('click', (event) => {
            if (numbersIndex == operatorsIndex - 1) {
                calcScreen.innerText += event.target.innerText;
                numbersIndex++;
                operators.push(event.target.innerText);
            }
        });
    }

    document.getElementById('clear').addEventListener('click', (event) => {
        calcScreen.innerHTML = '&nbsp;';
        numbers = [], numbersIndex = 0, operators = ['+'], operatorsIndex = 0;
    });
    
    document.getElementById('equal').addEventListener('click', (event) => {
        if (numbersIndex != operatorsIndex - 1) {
            alert("Invalid expression");
        } else {
            var result = 0;
            for (var i in operators) {
                result = myEvaluate(result, operators[i], numbers[i]);
            }
            alert(result);
        }
    });
});