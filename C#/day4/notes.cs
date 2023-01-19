/*
- variables are allocated upfront
- stacktrace is stackframes above eachother
- named parameters could be arranged in any order
    - compiler rearranges to the orriginal order
- stacktrace object could be accessed in runtime
- value-typed variables are passed by value by default
    - void fun(ref int x)
- reference-typed is passed by pointer value
- uninitialized variable could be passed as out
    - void fun(out int x)
    - out variables could be defined inside fun call and used in other lines
*/