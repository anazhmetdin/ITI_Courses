/*
    - private members could be accessed directly inside member functions even for other objects
    
    - function overloading: a level of polymorphisms, having different function signatures with the same name
        - all of them has the same functionality/objective but different behaviors/bodies based on input parameters
        - different number of parameters or type or order
        - valid for member and standalone functions
        - doesn't consider the return data type, nor parameter names

    - constructor/s: special member function that gets called automatically once memory is allocated
        - has the same name as the class name
        - has no explecit return dtype, implicit void, no need to write void
        - a default constructor is a parameterless constructor
            - generated automatically unless a single constructor is created manually
            - gets called -> Complex c1; -> vs. Complex c2 = Complex(1, 2);

    - opjects in cpp is a value type vs reference type in java & c#

    - if attributes are assigned a value in class definition
        - compiler-based behavior
        - the compiler will do it as the first line after creating object

    - destructor: another special function that gets called before object is deleted
        - to clean up, deallocat dynamic memory, close files, etc...
        - no explicit return type
        - must have no parameters, hence no destructor overloading
        - defined as -> ~class_name() {}

    - if constructors are private we can't create objects outside member functions
    - destructor must be public, called automatically

    - native code: is what you write
    - compiled code: code edited automatically by the compiler
        - it adds another parameter for member functions, a pointer to the caller instance (this)

    - functions return dtype is int in C/C++
*/