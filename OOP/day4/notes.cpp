/*
    -  operator overloading can be a member function or stand-alone
        - className operator + (const className &x){...; return y;}
        - c1 + c2 -> c1.operator +(c2)

    - operators that change the caller could return by reference because the caller (the returned value) have a larger scope
        - like +=

    - most operators are overload-able, except dot and arrow
    - postfix operator is distinguished from prefix by passing a dummy parameter int
        - className operator++(int) {className temp (*this); ...; return temp;}
        - without the dummy parameter it's interpreted as prefix

    - type casting operator -> int(x) or (int) x
        - operator int() {...;} -> must return int

    - default operator = for objects does a member-wise =
        - if LHS has a pointer member -> data leakage & will access data of the RHS
            - operator overloading is required to free old allocated memory and allocated new memory then copy values one by one

    - if the function returns a pointer, it could be written on the left hand side of =

    - operator[] -> one parameter of index -> when returns by reference could be used in setting and getting
*/