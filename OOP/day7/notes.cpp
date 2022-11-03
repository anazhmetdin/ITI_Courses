/*
    - derived classes could be initialized as type of base
        - basClass x = derived(1, 2) / baseClass *x = new derived(1, 2)

    - Statically binded methods = early binded methods
        - resolving function calls to functions bodies
        - compiler bind functions on compilation
        - binding is based on pointer/variable type

    - Dinamically binded methods = late binded
        - resolved at runtime by OS
        - binding is based on object type, not on the *pointer* type
        - conditions for this case: 
            + public inheritance 
            + virtual public function at parent 
            + public overriding at child
            + *pointer* of type parent -> refering to child object
                - if parent object stores child object -> static binding to parent methods

    - keyword "override" has no functional effect, it just enhances readability
   
    - pure virtual method: virtual function that has no body -> virtual int func() = 0;
        - classes having at least one pure virtual method is an abstract class
        - abstract classes can't be inistiated
        - classses inheriting from abstract classes are abstract 
            unless they provide implementation for all pure virtual methods
        - concrete class = non-abstract class -> any class that can be used in creating objects

    - constructors order: parent to child
    - destructors  order: child to parent

    - aggregation:
        - temporary relation
        - member attributes: pointer to some object
            - the pointed object could be deleted and the pointer set to NULL or another 
*/