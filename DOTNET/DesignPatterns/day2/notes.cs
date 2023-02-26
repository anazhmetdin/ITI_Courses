/*
Factory method:
- when dealing with multiple hirarichies:
    - create a creator class and use it as an attribute
    - each hirarichy has its own creator and the attribute changes through set and get
- whithout DP creating an instance of concrete object will be against "closed for modification"
- adding a layer for creating the object will enable us to add code only when introducting new types

Abstract Factory:
- there are multiple products composing one product
- the abs factory has multiple steps
- for each combination there is a concrete factory
- the factory has functions to create each part

Adaptor:
- OOP replacement for casting
    - casting is language dependent
    - adaptor doesn't require editing source code
- class inheriting from one class and composing another class
    - delegating any function to the inner object

Facade:
- class composing multiple objects
- have functions that perform multiple operations using these objects

Template Method:
- function has some steps => we need to change some steps
- the class become abstract, steps become abstract or virtual

state pattern:
- similar to strategy
- the state itself has multiple functions
- class delegates to the sate object
- state transition handeled inside state functions

Command:
invoker has
*/