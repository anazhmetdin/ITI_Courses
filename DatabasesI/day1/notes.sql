/*
    - ERD: entity relationship diagram
    - RDBMS: relational database managemnet system
    - SQL: structured query lang.

    - DB life cycle:
        1- analysis: [system analyst] (expert in IT and business specilization) -> req. doc. "scope"
        2- DB design: [DB designmer] transforming req. doc. to ERD
        3- DB mapping: [DB designer] db schemea -> tables & relations
        4- Implementation: logical design to physical -> through RDBMS (files: .mdf master, .ldf log)
            - on DB server: to control access and unify source of data to be trusted
        5- application: GUI interface connected to backend server [App programmer]
            - [DB user] the developer who are supposed to use DB
        6- clinet: [end user] accessing application through url

    - DB systems:
        - file-based: delimted or fixed width (bytes)
        - cons: 
            - slow performance
            - diff modiffcation
            - copies and inconsistency
            - no relations between files
            - no data validation
            - no integtiy (rules or structure) not trusted
            - redundancy and duplications
            - large size, time, developing
            - no security, anyone could read and write
            - manual duplication and restoration
            - no standard, diff integration
        
        - DB:
            - null and unique constraints
                - null isn't a value, can't be used with =, >, <
            - no dependency between application and DB

    - strong entity: its existence doesn't depend on other entity
    - weak entity: depends on another strong entity
        - when deleting the parent, all related rows will be deleted without a warning (and shows "1 row affected")
        - partial key: unique per parent key, needs the parent key to a primary key
    
    - attr types:
        - simple attribute: no repeat, no division, no calculation (single line ellipse)
        - multi-valued attr: douple-lined ellipse
        - composite atttr: dashed ellipse -> must have a meaning when concatenated

        - complex attr: attr with different types

    - req. doc. may produces multiple correct ERD -> ERD produces only one correct mapping
    
    - ERD constructed from: entities (square), attributes (ellipses), relations (diamonds, verbs)
        - foriegn key constraint: to ensure relation between entities refers to atual columns
        - relationships' attributes: attr. that have meaning only when two entities has related instances

    - relation's properties:

        - degree (often used as relation type): unary (recursive, or self), binary, ternary

        - cardinality (constraint): how many rows from one entity is connected to single row from other entity
            - 1:1 , 1:M , M:M
            - weak relation must be 1 from the side of strong

        - participation (constraint): do all rows have relation to the other instance
            - total (doubled line) vs. partial (single line)
            - weak enities must have a "total partic." to the strong entity

    - candidate key: unique and not null
    - primary key: shortest candidate (underlined attr.)
    - composite key: a combination of columns that is unique
        - prefered over adding column for id -> to check for uniqueness while inserting (have other better solutions later)

*/