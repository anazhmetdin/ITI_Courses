var values = [];

for (var i = 1; i < 6; i++) {
    do {
        values[i-1] = parseFloat(prompt(`Enter value #${i}:`, i));
    } while (!isFinite(values[i-1]));
}

function sortDesc(x, y) {
    return y-x;
}

function sortAsc(x, y) {
    return x-y;
}

document.write(`<p style="color:blue; display:inline;">U've enterd: </p><p style="display:inline;">${values.join(' ')}</p><br>`);
document.write(`<p style="color:blue; display:inline;">Descending : </p><p style="display:inline;">${values.sort(sortDesc).join(' ')}</p><br>`);
document.write(`<p style="color:blue; display:inline;">Ascending  : </p><p style="display:inline;">${values.sort(sortAsc).join(' ')}</p><br>`);