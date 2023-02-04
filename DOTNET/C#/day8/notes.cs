/*
- delegate creates a class that inherits from multiclassdelegate
    - public delegate int MyDelegate (int x, int y);
    - pointer to function returns int, have two parameters int
    - MyDelegate fptr = new MyDelegate(MyFunction);
        - MyDelegate fptr = MyFunction;
        - fptr(1, 3) -> unsafe, fptr might be null
        - fptr?.invoke(1, 3)?? int -> safe

    - Func<T1,T2, ..., Tresult> x = delegte (int x1, int x2, ...) {return x1+x2+...;}; [[anonymous]]
    - Predicate<T1, T2, ...> -> returns bool
    - Action<T1,T2, ...> -> returns void
    - (i) => i%4==0; lambda expression equivaltent to anonymous functions

*/