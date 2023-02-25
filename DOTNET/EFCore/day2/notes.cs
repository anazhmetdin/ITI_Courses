/*
- migration files keep track of DB changes [DB first, or code only]
- from console -> Add-Migration <name>
- can pick any point of change and go back to it
    - namespace migration
    - each file represent a class that inherits from class called migration
        - up function to apply changes
        - down function to undo changes
    - snapshot file keeps record of current version and the added changes

- keyless entities are used to map [views and owned entities]
*/