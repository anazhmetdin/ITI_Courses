function myFunc(a, b) {
    if (arguments.length != 2) {
        throw new Error('parameters count must be 2');
    }
}