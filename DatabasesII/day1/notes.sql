/*
- create DB: (physical ldf and mdf - logical representation)
    - logical rep -> file groups (primary fg -> points to mdf)
        - other FGs points to ndf
        - tables are distributed across files in order to be accessed similtanously
    - physical -> mdf (and other ndf (secondary))

- while creating DB on SQL Server:
    - press "Add" to add secondary data files
    - and create different file groups to point to ndfs
    - data files have a size limit -> when file group points to multiple DFs, it writes simultanously

- in creating tables, the assigned file group could be specified, while keeping meta data in the primary FG

- deriven attributes: while creating columns -> could be added by writing the formula in "Computed Column Specification"
    - "is presisted" stores the derived attribute on disk beside the fomula (updated reqularly)

- column property -> identity -> auto increments

- "is sparse" property is used for columns with many NULL values and that column is not accessed frequently
- FK on delete and update properties could be set by editing relation
    - on delete cascade -> deletes children -> but shows message of 1 row affected
    - set default -> checked on runtime that child's column default value exists in parent
        - the default value in parent table could be erased -> could be prevented by triggers

- SQLServer Schema:
    - solves 3 problems:
        - can't create objects (tables, functions, triggers,...) with the same name
        - can't organize and categorize objects
        - can't group objects while setting users permissions
    - so schema is: logical group of objects
    - default schema is "dbo"
    - CREATE SCHEMA newSchema;
    - ALTER SCHEMA newSchema TRANSFER myTable;
    - SELECT * from newSchema.myTable;
    - CTRATE TABLE newSchema.newTable (...);

- to create login -> right click on server and make sure authentication mode is windows auth and sql auth then restart
    - create new login (name and password) -> server roles: preset of permissions -> default is public: no permissions
    - add user
        - default schema -> grants all permissions on its objects
        - to grant perm. on specific shema -> right click on schema then edit permission tab
    
- DB integrity: domain, entity, refrential (should be implemented in CST and backend)
    - Constraints:
        - Domain Int.: range of values
            - datatypes
            - not null
            - check
            - defailt
        - Entity Int.: uniqueness
            - PK
            - UNIQUE constraint: same as PK but allows null and could have more than one
        - Referential Int.: relationships
            - FK
    - DB objects:
        - rule (domain)
        - index (entity)
        - trigger (domain, entity, referential)
    
- the fifth constraint is Stored Procecures + Triggers

- to set column as derived: create tabel x (colName as (formula) [persisted])
- composite primary key -> CONSTRAINT PK_name PRIMARY KEY (col1, col2)
- unique constraint could be set on columns combination: CONSTRAINT unique_name UNIQUE(col1, col2);
- constaint names are used late in ALTER statements

- mdf data could be accessed from "sys."
    - some info has stored procedures and could be called as:
        - sp_name 'param1'

- constaints should apply on old data if altered
- constaints can't be shared accross tables
- constriants can't be linked to a specific data type

- rules solve problems of constraints
    - CREATE RULE rule_name AS @x>100
        - @x is variable that represents any value
    - sp_bindrule rule_name, 'table.column'

- one column could have multiple constraints, but only one rule
    - constaint is checked first

- to create data type:
    - sp_addtype type_name, 'int'
- then, we can bind rules to the created dtypes

- default value could be created and binded the same as rules

- folder named 'System Databese' contains a template for all the created databases
*/