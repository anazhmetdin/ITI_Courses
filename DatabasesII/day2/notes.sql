/*
- local variables are local to the scope of current batch/function/SP
    - DECLATE @x int -> initial value is NULL
        - or -> DECLATE @X int = value
        - value could be a select statement
    - SET @X = 8;
        - could be used in UPDATE
    - SELECT @X = 9;
        - could be used in SELECT -> all columns should be stored in a variable or displayed
        - without assignment its value will be displayed
    - dtype of array is "table(col1 int, col2 nchar(1), ...)"
        - INSERT INTO @myTable
            - VALUES (1, 'sd', ..)
            - or -> SELECT statement

- global variables are pre-defined and are read-only
    - global on the scope of server, so would be affected by other users queries
    - some are reset after each batch
    - SET @X = @@servername
    - @@servername
        - defualt instance or named instance -> default is named after the pc name
    - @@version
    - @@rowsCount
        - number of rows affected from the last query
    - @@error
        - error code from the last query -> 0 indicates no error
    - @@identity
        - identity value of the last inserted identity

- dynamic queries using variables with EXECUTE('SELECT '+@col1+' FROM '+@table1)

- if else if -> works as other languages -> curly brackets are replaced by BEGIN and END
- BEGIN TRY ... END TRY
- BEGIN CATCH ... END CATCH
    - inside catch we can get information about the error using built-in functions
    - ERROR_LINE() ERROR_MESSAGE()
- to perform if inside SELECT
    - CASE
        WHEN (Condition) THEN 'value to be selected'
        WHEN ...
      END

- **** search for "IIF, CHOSE, WAIT"

- SELECT X = LAG|LEAD(col to be displayed) OVER(ORDER BY COL_TO_BE_USED_IN_SORINT)
    - to view lag and lead by groups
        - PARTITION BY col1 ORDER BY col2

- windowing functions
    - rank
    - lag|lead
    - first_value
    - last_value

- create function fun_name(@p1 dtype, ...)
  returns dtype
  as
    begin
        declare @v1 dtype
        ...
        return @v1;
    end

- inline functions return table VS. multi-statement above
    - return (Select ...)

- can't use EXECUTE() inside function because it might allow DML -> which is not accepted inside functions generally

- scalar functions returns one value 
    - all built-in functions are scalar F

- batch: a set of independent queries -> independent in sense of error and rows count
- script: similar to batch -> batch is converted to group of scripts -> by dividing using 'GO'
- transaction: set of dependent queries, single unit of action, all fail or all succeed
    - implicit transactions when server commits and rollback on single query
    - explicit transaction:
        - BEGIN TRANSACTION
            ...
          ROLLBACK || COMMIT
        
        - if server fails, server rollback automatically
        - if query fails due to constraint error -> works as batch if commit is found
            - should handle errors in a try catch
        - TRUNCATE only inside explicit transaction is saved in the log file
- transactions are ACID
    - Atomic: All changes to data are performed as if they are a single operation
    - Consistent: maintaining data integrity constraints
    - Isolated: data used during transaction cannot be used by another transaction
    - Durable: permanently stored and not erased by accident, even during a database crash
        - It is accomplished by storing all transactions into a non-volatile storage medium

===================================
- convert() = cast() -> convert could change date format

- idnetity constraint continues after the largest value
- trunctate resets identity counter
- SET IDENTITY_INSERT ON|OFF -> to control identity manually
*/