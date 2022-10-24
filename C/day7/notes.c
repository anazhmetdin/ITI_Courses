/*
    - data leakage: unreachable location in memory while being allocated for this program
        - it would be a problem if the program runs for a long time or using large memory chuncks
    
    - malloc(int number_bytes) -> returns pointer to void
        - needs to be casted to a pointer to the desired datatype (explecit casting)
            - vs (implicit casting) -> long x; short y = 2; x = y; -> value of 7 would be casted to long
        - dtype* malloc(number_bytes);
        - void pointer is a memory address of the first byte with no information about the block step
            - eg: int has a step size of 4
        - the returned ptr is not fixed (as int x[10]) -> this means it could be reassigned
    
    - free(dynamic_ptr) -> deallocate the memory
        - deosn't erase data, nor erases the address from the ptr
        - ptr = NULL; -> to erase the address
        - the best practice is to free a pointer once it won't be longer used;

    - adding data to heap: slower than stack because allocated memory not necessarily continous
        - fragmented memory: happens when memory isn't continously allocated

    - allocated memory blocks in heap can't be expanded, however, the heap itself has flexible size
    - arrays could be allocated dynamically using malloc() -> it returns a pointer to the first cell

    - global variables are initialized by default to the zero equivalent, so for a pointer it's NULL

    - to dynamically allocate 2D array: allocate an array of arrays
        - the first dimenstion would be casted to (dtype **) -> pointer of pointer -> size_1D * sizeof(int *);
        - the second dimension, at eact entry, an array would be allocated and casted to (dtype *) -> pointer of dtype -> size_2D * sizeof(int);

*/