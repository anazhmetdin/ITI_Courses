/*
    - scope: number of lines of code where a variable is accessible and exists in memory
        - it's managed automatically, memory is allocated and deallocated automatically (statically allocated)
        - dynamically allocated: memory managed manually by programmer

    - return_type function_name(parameter list, data_type name) {body; return value;}

    - stack: fixed size place in memory for the entire program
        - stack overflow happens when statically allocated variables overflow the 1Mb allocated for the stack
        - stack frame: area in stack for a specific function (variable size)
        - main() is the first stack frame allocated when a program runs
        - when a function is called, a new stack frame is allocated in memory
        - stack trace: stack frames ordered above each other according to the order of execution in memory
        - when a function returns, the stack frame is deallocated
        - stack is handled by the OS
        - stack is fast because it only adds to the top or removes from the top
        - local variable are allocated upfront once the stackframe is allocated
    
    - old C compilers compiles function according to their order of definitions, a function can't be called before its definiton
    - local variables of the function includes the parameters variables but needs to be initialized by the caller
    - block statements (loops, or any {} other than functions) has no scope
    - variables could have the same name as long as they have different scopes
    - function could have a return type but doesn't return a value
    - there is no guarantee that parameters have a specific order of evaluation (passing order)
    - default parameters passing is by value (a copy of its value) != pass by address
    - global variabls are defined outside all function scopes (stored in heap) managed by OS
        - could be read and written by any function

    - Recursive function: a function that calls itself
        - power(x,y) = x * power(x, y-1)
        - base condition is needed to prevent stack overflow: if y == 1: return x
        - always loops are faster (less memory) than recursion
        - recursion sometimes are more readible than loops

    - chaining function calls: calling a function as an argument for another function

    - user-defined data types: combine multiple attributes in a single variable:
        - struct struct_name {att_type att_name;};
        - struct size is the total size of all attributes
        - struct's att are only accesible through instances of struct (x.att)
*/