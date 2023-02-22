/*
- EF supports DB-first and code-first

- mapping methods:
    - Table per type [TPT]: per class or enum [no support for struct yet]
        - common attributes are stored once
        - cons: storage optimized but overhead performance
    - Table per Hirarachy [TPH]: default
        - is a relations are mapped to one table
        - conditional mapping [null columns may determine type]
            - or descriminator col 
    - Table per Concrete Class [TPCC]:
        - repeat common attributes in each table

- Navigational property: reference to foriegn keys elements
    - by default lazy loaded [all attributes]
    - queried as join statement -> then separated in runtime to two+ objects

- required keyword: makes nullable ref type oblgated to be initialized by class users

- attribute named ID or EntityNameID -> automatically represented as pk [identity]

- how to specify DB constraints:
    - EF conventions
    - data annotation
    - Fluent API
    - Configuration classes

- EF save changes are transactional by default
- virtual navigational property -> convention for lazy loading
*/