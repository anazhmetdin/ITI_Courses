/*
    - static members are defined at the beginning of the program and stays at the heap
    - static members are not initialized by default, needs to be initialized outside the class
        - int className::variableName = 0;

    - static members are similar to global variables except for the scope

    - template functions: functions that works with a general data type
        - the data type is specified later based on the used types while calling
        - template <class anyName>
            - anyName will be the generic data type that could be used any where inside the function

    - template class: similar to template functions
        - the generic class is determined at object initialization -> className<int> x;
        - static variable initializtion -> int className<anyName>::variableName = 0;
        - static members are different for each copy of the template class
        - when defining a member function outside a template class
            - the function needs to be specified as template
            - the scope of Template <class ...> ends with the end of the next block line

    - template classes and functions can have multiple template types
        - template <class name1, class name2>

    - objects relationships: (Association, Aggregation, Composition) sorted by their strength

    - Association:
        - temporary relation
        - peer to peer (no whole and part)
        - could be bi-directional relationship
        - no dependancy for creation and removal of objects
        - represented by a pointer or a reference

    - Aggregation:
        - whole/part relation
        - unidirectional
        - else similar to association

    - Composition:
        - Permenant
        - complete ownership (whole/part)
        - unidirectional
        - complete dependency on creation and destruction
        - represented by a member object attribute

        - constructor chaining for members object
            - className(class parameters including member object parameters):
              objectName(object parameters from class constructor parameters)
              {class constructor body;}
*/