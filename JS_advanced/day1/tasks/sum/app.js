function mySum() {
    if (arguments.length === 0) {
        throw new Error('zero arguments were passed');
    }
    var sum = 0;
    for (var number of arguments) {
        if (typeof number != 'number') {
            throw new Error('invalid parameter type');
        } else {
            sum += number;
        }
    }
    
    return sum;
}