/*
- Creational pattersn: 5

- Structural patters: 7
    - Facade: similar to data access layer, single class contains all needed functions to control system

- Behavioral patterns: 11


- strategy: delegating call to another composited object
    - composition better than inheritance
    - using base types to represent derived
    - behavior is implemented as classes
    - derived classes inherits the signature of function, perform action through composing behavoir
        - parent function delegates logic to strategy object
    - new behaviors could be created and assigned in runtime
    - parent constructor could assign default behaviors
        - derived classes should chain on parent constructor and assign their initial behaivors

- observer:
    - publisher have list of subscribers [observers]
    - when event happens, publisher notify subscribers
        - in C#, publisher has list of delegates [function references] that are called on event

- decorator:
    - child class that have composed object of parent
    - any combination of children classes could be created by wrapping the parent class inside multiple decorators
    - calling child would call composed object plus some additional functionality
    - parent could be an interface, components that will be wrapped jush need to inherit from the same interface

- 
*/