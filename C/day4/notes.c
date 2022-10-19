/*
    - getch and getche might be buggy with CB, use _getch (newer version)
    - if (ch == 0x0D) if user press enter
    - scanf() format specifier %s to read string stored inside char x[]
        - scanf("%s", x) no need to add & (becase array is stored as reference by default)
        - %s stops after the first white space
    - if x[] has size of 5, then max number of char is 4 because one should be reserved for \n
        - if longer string is stored, it will be written on a non-reserved memory space
          which might cause problems as it could be erased easily
    - gets() and puts() are used to input and output strings including spaces (until enter is pressed)
    - operator = can't be used to assign value to char x[]
        - strcpy(x, "any string"); to assign value to the array
    - strlen(x) to get length of char array 
    - equality has two states (T or F)
        - comparison has three states (+ve=greater, 0=equal, -ve=smaller)
        - could be simplified to x-y for numerical values
    - strcmp() case sensitive, strcmpi() case insensitive
    - strcat() concatenates two strings and stores result in the first string (+=)
    - scanf() reads from a buffer, if buffer not empty the func doesn't prompt user
        - some symbols are represented with more than one byte, so scanf reads them over multiple times
            - known as extended keys: writes two bytes, one special idicator 0xFFE0 (-32),
              and other is the key code
            - to work around, checks if getch() reads the indicaor, run getch() again
        - to flush buffer use flushall()

    - if we have 2D array x[][] and used x[index] will access each row, not as 1D array

    - multi-valued argument: each group of bits encode some information
    - system("") to send commends to cmd, "cls" to clear screen
    
*/