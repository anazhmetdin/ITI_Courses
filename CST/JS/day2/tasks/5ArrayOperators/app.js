var values = [];

for (var i = 1; i < 4; i++) {
    do {
        values[i-1] = parseFloat(prompt(`Enter value #${i}:`, i));
    } while (!isFinite(values[i-1]));
}

document.write(`<p style="color:blue; display:inline;">Summation: </p><p style="display:inline;">${(values[0]+values[1]+values[2]).toFixed(2)}</p><br>`);
document.write(`<p style="color:blue; display:inline;">Multiplication: </p><p style="display:inline;">${(values[0]*values[1]*values[2]).toFixed(2)}</p><br>`);
document.write(`<p style="color:blue; display:inline;">Division: </p><p style="display:inline;">${(values[0]/values[1]/values[2]).toFixed(2)}</p><br>`);