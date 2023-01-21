/*
- js is object based, it's the baseic unit
- ojects is a colloction of properties: key and value
- object types: custom, built in, BOM, DOM
- variable are created using literal creation (short-hand) or constructor

- Error object should be used to flag error while messeging information
    - explicitly: throw new Error('message');
        - useful as we could use other error objects inheriting from Error
        - could pass more descriptive arguments
    - implicityl: throw 'message';

- function object could be stored in a variable
    - literal function (not hoisted): var x = function() {return 0;}
        - IIFE (Immediately Invoked Function Expression)
            - !function () {console.log("inside IIFE")}();
            - (function () {console.log("inside IIFE")}());
        = anonymous, factory function, function expression)
    - function statement (hoisted): function x() {return 0;}
    - functions always return a value, undefined by default
    - dynamic function: new function('param1Name',..., 'function body');
        - global scope
    - fun.length -> number of parameters expected
    - unpassed parameters -> undefined
    - passed arguments could be found in "arguments" object
        - could pass more arguments than the defined parameters
*/