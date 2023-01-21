/*
    - private members could be defined inside constructor as var and used inside inner functions
    - hard binding-> (function() {}).bind(this) -> private method could be called from inside inner functions only
        - will be called as object methods, "this" passed implicitly
        - instead we could save "this" in a variable and use to access the outer context inside a non-member function
    - descriptor, enumerable, configurable -> could be set for properties -> Object.setProperty(obj, 'name', {
        value: ...,
        option1: ...,
        option2: ...,
        option3: ...,
    })
*/