/*
    - relation usually implemented as fk
        - fk is a column in one table refers to another col in different/same table
        - standard rule is fk refers to pk
        - by default, can't edit pk while fk refers to it
        - fk in tables is marked with dashed underline

    - col domain is determined by datatype and constraints

    - strong entities are mapped to a table
    - composite attr. are mapped as seprate columns
    - multi-valued attr. mapped to a seprate table -> with the original pk as fk in second table

    - 1:1 mapped depending on participation
        - total:total -> pk as fk in any table
        - part:total -> pk of total as fk in part
        - part:part -> new table connecting pks

    - 1:m
        - total:part -> pk of part as fk in total
        - (check lec pdf)

    - ANSI SQL: standard sql -> engines build on top of it
        - microsoft -> Transact-sql
            - DDL, DCL, DML
            - DQL, controling how data is displayed (select)
            - TCL. transactional control lang. (rollback, commit, begin transaction)

    - sql server runs as a service, MS sql management connects to the service and just works as GUI
        - by default, the sql server takes the same IP as laptop (local or .) and same name

    - to share DB, create a backup from tasks menu, then restore the generated compressed file (.back)

    - when inserting multiple rows we use (insert constructor)

    - col alias
        - select c as alias
        - select c alias
        - select c [ali as]
        - select alias = c
*/