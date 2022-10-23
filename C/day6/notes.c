/*

    - pointer size in 64-bit system is 4 byts, 2 bytes in 32-bit system (to store memory address)
    - content of pointer is address, vs content of normal variables is data
    - pointer data type specifies the type of data stored in the address, in order to know how many bytes to read after the stored address

    - declaration: int* ptr; -> initialized with garpage
    - initialization: ptr = &x; -> returns the address of variable x
    - access data pointed to: *ptr = 9; -> stores 9 in x
        - int y = *ptr; -> returns the content of x and stores it inside y

    - scanf("%i", ptr); -> equivalent to &x
    - to print address we could use format specifier %x or %p

    - double *d = null; -> points to no address

    - ptr++ -> will increases the address by step of data type, used with arrays

    - int arr[5]; arr -> will be a pointer to the address of the first element in the array
        - arr++ -> a syntax error, because the array pointer is not editable (fixed pointer)
    - ptr = arr; ptr[i] will return the value at index i
        - ptr++ -> NOT a syntax error, will point to the second cell

    - pass by address: pass &x to function, the original variable could be modified; vs pass by value: a copy of data is passed to the function
        - void swap(int *x, int *y){} -> swap(&x, &y);
        - to pass an array to a function -> void func(int *arr){} -> func(arr);
            - there will be two copies of the array pointer, one in the original stack frame, and another in the function stack frame
            - while the original data of array resides in the original stack frame

    - StructPtr = &struct; structPtr->x OR *structPtr.x
        - scanf("%i", &structPtr->x);

*/