/*
- automatic property is slower because it adds stack frames
    - but less code and adds encapsulation
    - creates backing field (attribute) that is not accessible directly
    - could add setter, getter, and init -> used only in initialization
    - int x {get; set;} = 4;

- default access level for classes is internal
    - internal is accessible only to classes in the same project

- property access new levels:
    - protected internal: or
    - private protectected: protected and internal

- struct default cstor always exists and initialize attributes to default
- class default cstor exists only when no defined cstor, doesnt init members

- copy cstor must be called as new foo(old), because new = old will copy ref only

- managed resources: by CLR garbage collector
- unmanaged resources: files and database connections
- destructor in c# is not guarenteed to be called at a specific time

- pass by value: creates new pointer pointing to ref data type
- pass by ref: new pointer to the ref pointer, treated as an alias of the original var

- static constructor called autmatically once per program before the first usage of class, must be parameterless

- point x = new point() {x=2,y=4}
     - equals x.x = 2; x.y=4;

-  overloading operators: must be static always
    - non-overloadable: . -> => ! [] new

- x??0 -> if null use 0
*/