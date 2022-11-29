var radius, sqrt, angle;

do {
    radius = parseFloat(prompt(`Enter circle radius`, 5));
} while (!isFinite(radius));

alert(`Circle area = ${Math.pow(radius,2)*Math.PI}`);

do {
    sqrt = parseFloat(prompt(`Enter sqrt`, 9));
} while (!isFinite(sqrt));

alert(`sqrt of ${sqrt} = ${Math.sqrt(sqrt)}`);

do {
    angle = parseFloat(prompt(`Enter angle in degrees`, 45));
} while (!isFinite(angle));

alert(`cos(${angle})= ${Math.cos(angle*Math.PI/180).toFixed(3)}`);