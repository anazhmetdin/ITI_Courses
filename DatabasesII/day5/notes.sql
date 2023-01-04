/*
-cursor flowchart:
    - declare cursor
    - declare variables: to store column values
    - open cursor: point at first row of result set
    - fetch row: place row in memory
    - @@fetch_status -> 0 no error, 1 row exists but error happened, 2 no row
    - close cursor: save current cursor state
    - dellocate cursor -> free allocated memory

    - DECLARE c1 CURSOR
      FOR SELECT ....
      FOR [READ ONLY | UPDATE] -- update is default
      DECLARE @id int, @name nchar(10)
      OPEN c1
      FETCH c1 INTO @id, @name
      WHILE @@fetch_status = 0
        BEGIN

        
        FETCH c1 INTO @id, @name -- start next iteration

        END
      CLOSE c1
      DEALLOCATE c1;

    
    - WHERE CURRENT OF c1

- types of backups:
    - full: mdf
    - differential: mdf
        - only backs up new added data since last full backup
    - tansaction log: ldf
        - saves queries and empties log file
    
    - best preactice is to use all types on different timeline
        - full: each month
        - differential: each few days
        - transactiona: each few hours
    
    - .bak file -> contains all 3 types at the same time
    - task

- snapshot: read only DB on same server
    - pointers to current tables rows (pages)
    - store rows when edited
- old snapshots refer to eachother
- one snap for each data file

- CREATE DATABSE example 
  ON 
  (
    name = 'iti' -- source mdf,
    filename = 'path.ss' -- target
  ),
  (
    name = 'iti1' -- source ndf,
    filename = 'path1.ss' -- target
  ),
  AS SNAPSHOT OF ITI

- 
*/