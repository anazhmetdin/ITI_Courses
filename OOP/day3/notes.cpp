/*
    - RVO: return value optimizer -> compiler optimization to skip creating a temp object to hold the return value of a function
        - without optimization: a temp object is created by member-wise copy constructor, then, the function stack frame is deleted
        - with optimization: the return value is linked directly to the variable that is supposed to hold the value

    - pass by value objects are created by copy constructor
        - if the object contains a pointer and a destructor frees that pointer, the pointer will be freed by the end of the function
            - because at the end of the function, the stack frame gets erased and all local objects are destructed (shallow copy)
        - this could be avoided by passing by reference -> however, the original data could be modified
            - const reference: read only reference -> however, pointers inside original data could still be accessed and the pointed-to data could be modified

    - default input parameter: giving a default value for parameters in case the user didn't specify a value
        - int func(int x = 3){} -> could be called as func() -> x would be 3
        - a function could have multiple default parameters, but all default parameters should be at the end of parameters list

    - friend function: using a function prototype inside some class will make the function able to access private members
        - this violates OOP
        - only in c++
        - class A {int x; public: friend int foo(A obj);} -> int foo(A obj) {A.x;}

    - if we defined a copy constructor it will override the member-wise copy constructor generated automatically
        - this constructor must have a pass by refrence parameter of the same class
            - if pass by value this will create an infinite recursion
        - needed when passing object by value whilt it has a pointer (will be copied by default as an address)

    ============
    tasks: with and without RVO
    - add copy constructor
    - override values in dynamically allocated arrays (-1)
    - implement reverse member function
    - stk.reverse().pop()
*/ 