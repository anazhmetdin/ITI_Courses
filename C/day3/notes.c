/*
    - normal variables are stored in stack memory in separate addresses
    - array block variable is stored in a continous memory addresses
        - size of single element * number of elements
        - using the address of the first element we can access other elements using indexing
        - initial values by default is garbage
        - int arr[4] = {1,2} first two values are initialized and other = 0
        - int arr[] = {1,2,3,4} size is determined from initial values count
        - int arr[10] = {} initialize values with 0
        - #define size 5: replaces each "size" in code with 5,
            so we could use a variable to represents arr size
        - if tried to acces memory outside the block, compiler won't show an error,
            but OS would terminate if accessed other program's memory
        
    - arr[3][5]: three rows, 5 columns - or three arrays each of 5 elements
        - in memeory, it's a continous block
        - arr[3][5] = {{1,2,3}, {1,2,3,4,5}, {}}

    - getch() vs getche(): e for echo, no need for \n to enter each char
    - null terminator \0 non-printable character used to terminate strings
*/