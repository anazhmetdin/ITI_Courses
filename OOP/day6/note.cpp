/*

    - inheritance relation between classes = "is a"
    - child class inherits all "available" members from parent class
    - inheritance have different access levels: (public, private, protected)
        - inheritance type determines access modifier of inherited public members from child
            - private inheritance change access modifier of public and protected members from parent
        - private members are not accessible within child, but the child has a copy of them
        - class childName: public parentName {};

    - protected access modifier: accesible only within class and inheriting classes
        - similar to private when there is no inheritance
    
    - when creating objects from child, parent constructor is executed first

    - parent constructors aren't inherited
        - constructors chaining -> childName (parameters): parentName(parameters from child paremters)
        - implicitly parameterless parent constructor is called when not specified
    - parent constructor then child constructor -> child destructor then parent destructor

    - child class could override parent function which hides the parent function
        - you can still access parent child -> childInstance.parentName::func();
            - this is only possible if type of inheritance is public and func() is public in parent
            - in protected inheritance, public members are inherited as protected, so not accessible
            - so we should provide a public interface in child to parent func
*/