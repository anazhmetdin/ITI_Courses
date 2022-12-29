/*
- query life cycle: prepared each time a query is executed
    - parsing: syntax checking
    - optimization (make sure metadata exists)
    - query tree -> steps to execute query parts
    - execution plan -> algorithms and internal steps

- stored proc -> saves time of preparing query life cycle
    - accepts all DQL
    - hides all meta data for security
    - could have parameters
    - CREATE PROC pname @param int
      AS
        ....
    - errors must be handled inside proc inorder to avoid leaking metadata from sever
    - can call execute() to perform dynamic queries
    - custom constraints
    
    - **** search how to prevent sql injection
        - procedure knows which is data and which is sql
        - using execute prevents this ?

    - proc is a dbo object
    - parameters are passed by position by default
        - could be passed by name @x=4,@y=5
    - parameters could have default values
        - @pname int=8
    - WITH ENCRYPTION AS
    - return is optional
        - should be used to return execution status
        - expected is integer
    - EXECUTE pname p1,p2; -> EXECUTE is optional
        - but not optional when the returned data is being stored in a variable
            - SELECT INTO @v EXECUTE pname;
        - or could return single variable
    - parameters by default has input parameter and passed by value
        - OUTPUT keyword is used to pass by reference
            - used in proc defintion, and in passing argument
    
    - types of stored proc:
        - built in
        - custom
        - implicit: trigger
            - can't be called

- triggers: objects stored on all levels
    - levels: server, database, schema, table, object
    - has no parameters
    
    - CREATE TRIGGER tname
      ON table_name
      AFTER INSERT
      AS
        SELECT ...;

    - triggers types:
        - AFTER
            - fires whether query failed or not
        - INSTEAD OF
            - could be used to make tables/columns read only
    
    - triggers are stored in the same schema of the table it's created on

    - inside trigger:
        - could check affected columns as
            - IF UPDATE(col_name)
        - get INSERTED, DELETED rows:
*/