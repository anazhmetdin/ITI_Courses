/*
    - join could be used witth delete & update
    
    - joins types:    
        - cross: cartesian product 
            -  all rows combination -> equivalent to listing tables after FROM sep with ,
        - outer: left, right, full
            - similar to inner, but includes unmatched rows from one or both tables
        - inner: equi join
            - connecting rows with corresponding rows from other tables using pk & fk
            - leaves unmatched rows from both tables
        - self: unary relationships
    
    - when columns have the same name across tables, should be qualified by tables names
        - table.column
        - tables could be aliased -> select a.column from table a;

    - like: different from = as it matches part of string
        - could search using patterns
            - % 0 or more
            - _ one character
            - [set of characters to select one from them]
            - [a-z] from a to z
            - [!a-z] not from a to z -> [^a-z]
    
    - functions in sql:
        - isnull(column, other_value) -> replaces null from column with other value or other column
        - convert(dtype, column)
        - concat(col1,col2,' ',col3) -> converts all values to string and replaces null with empty string

    - drop: ddl, data&metadata
    - delete: dml, slower, logs, rollback, +where
    - truncate: all data, faster, no rollback (sometimes logs), resets identity, affect child tables

    - row definition identity(1,1) starts from 1 and adds 1 every row
        - only one identity per table, not necessarily pk

    - functional dependency: one value has one corresponding value in another column
        - full: value depends on the pk
        - partial: depends on part of the pk
        - transitive: one col. on non-key col. while the second depends on pk

        - partial & transitive should be avoided by normalization

    - 1nf: remove repeated groups
    - 2nf: no partial FD
    - 3nf: no transitive FD

*/