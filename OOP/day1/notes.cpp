/*
    - oop promises to reduce the cost of change, as the effect of change in code would be restricted
        to a small scope, since data is more controlled vs structured programming (C)

    - oop is concered firstly about data, how it's ordered
        - each group of related data has restricted access to other groups
        - seperation of concerns: each object (instance of class) is responsible about specific part of data
        - objects are building blocks of the program
            - classes are the entities or dtypes, objects are the variables or instances of classes
        - encapsulated data: controlled/hidden data inside objects, so other objects will access the data according to the owner rules
    
    - class Car {}; -> Car c1; //object
        - c1.currentSpeed = 20; // data is accessed publicly, bad practice
            - if currentspeed changed in the future, we will need to change all code using it
            - instead, if Car provided a function to read and write data, we won't need to change other code
                (known as interface)

    - inheritance: classes inherits attributes and functions from older classes
        - reduce maintenance cost
        - Open for extension, Closed for modification (sOlid Principles)
            - to add features, create new code or classes, but don't modify old code

    - polymorphism: objects could have different behaviors based on the way it's called     

    - C++ is backward compatible with C, so C++ is not purly OOP
        - pure OOP can't have a stand-alone functions

    - to print and input in C++ we use streams, standard Input\output
        - cin/cout are objects defined in iostream, with overloaded shift operators << and >>
    
    - struct keyword is optional to use when creating instances of struct

    - int *x = new int[4]; -> dynamically allocate array of size 4
        - delete []x; -> free array x
        - or delete y; // if y is a pointer to a single object -> Employee *emp = new Employee();

    - pass by refrence, the function access the arguments directly not through pointers as in pass by address
        - refrence is an ALIAS for the original variable
        - zero bytes are allocated in stack
        - void swap(int &x, int &y); -> int &x = a; -> in this case x is an alias of a

    - member attributes of struct are public by default
        - we can use an access modifier (private:) to specify that all following members are only accessible inside the struct
        - in cpp we can add member functions to struct so they could be public setters and getters of private members
            - in addition to controlling access, setters and getters could provide more functionalities/logic to control the values

    - members attributes of class are private by default
*/