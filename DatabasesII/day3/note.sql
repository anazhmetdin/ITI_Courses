/*
- tables without PK are stored as heap (not sorted)
    - table scan is used to find data
- PK -> data is sorted on disk -> clustered index
    - data is inserted in order (slow, but fast retreival)
    - clustered index is BST -> nodes are data pages
    - first number in page is used in sorting nodes
    - page scan -> applied when the required page is found

    - when searching by other column -> table scan

- non-clustered index -> non-PK columns
    - column data is copied and sorted in BST
    - nodes are column data and a pointer to row on disk
    - if table has no PK -> can create clustered on any column
        - later, if table is altered and one column is set as PK
          creates non-clustered index

- CREATE CLUSTERED INDEX index_name ON table_name(col);
- CREATE NONCLUSTERED ...;

- unique constrint -> nonclustered
    - CREATE UNIQUE INDEX ...;
        - adds constraint on old and new data, then builds index

- sql server profiler -> trace file to log server performance
    - logs all queries applied on DB
- sql tuning advisor -> analyse trace file
    - recommends columns to be indexed

- temporary tables -> delated when session is closed
    - visible only to the creator
    - same as normal table -> name is preceded by #
- shared/global temp table
    - ##
    - visible to all users

- tables stored in variable is local to batch

- group by rollup(col): applies aggregate function to the resulting table
- group by rollup(col1, col2): to each sub group, and total
- group by cube(col1, col2): all combinations groups
- group by grouping sets(col1, col2): roll up on each unique val from each col

- SELECT * FROM sales
  PIVOT (SUM(Quantity) FOR SalesmanName IN ( [Ahmed], [Khalid], [ali])) as PVT
    
    - column of salesmanName will be used as row
    - sum(quantity) will be applied for each person

- view is a select statement
    - could be used as access object
    - restric data view for user
    - hide DB objects for security

- types of views:
    - standard
        - CREATE VIEW view_name AS
          SELECT ...;
    - partitioned: using tables from different servers
    - indexed view: index stored on disk
        - WITH SCHEMA BINDING
        - altering table must no affect columns in the view
    - materialized view: data is stored on disk as actual table
        - stores the result of select -> could be refreshed when wanted
    
- VIEW could hide column names by giving alis names
    - CREATE VIEW vname (new_col) AS
      SELECT ...;

- views could be combined
    - CREATE VIEW vname AS
      SELECT * FROM vname1
      UNION ALL
      SELECT * FROM vname2;
    - or JOIN

- sp_helptext 'vname' -> displays code of creation
    - CREATE VIEW vname WITH ENCRYPTION
        - to hide the creation query

- DML on views is possible but with some conditions
    - cols not included in view must be one of
        - identity
        - allows null
        - default
        - driven
    - cols are from one table
        - except for delete, view must be from one table only
        - from multiple tables must be divided into multiple queries

- when should use schema name?
    - scaler function
    - from other database/server
    - creating indexed view -> FROM dbo.

- CREATE VIEW vname (new_col) AS
    SELECT ...
    WHERE ...
  WITH CHECK OPTION;

    - DML must comply with conditions from the select statement

- MERGE INTO targetTablename T
  USING sourceTable S
  ON S.id = T.id
  WHEN MATCHED THEN
    UPDATE SET T.col = S.col
  WHEN NOT MATCHED THEN
    INSERT VALUES (S.col1, S.col2, ...);

or

MERGE INTO targetTablename T
  USING sourceTable S
  ON S.id = T.id
  WHEN MATCHED THEN
    UPDATE SET T.col = S.col
  WHEN NOT MATCHED BY SOURCE THEN
    INSERT VALUES (S.col1, S.col2, ...);
  WHEN MATCHED BY TARGET THEN
    DELETE;
*/