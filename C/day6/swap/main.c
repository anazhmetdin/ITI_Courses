#include <stdio.h>
#include <stdlib.h>

void swapValue(int x, int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void swapAddress(int *x, int *y)
{
    int temp = *x;
    *x = *y;
    *y = temp;
}

int main()
{
    int x = 3, y = 4;
    printf("x = %i, y = %i\n", x, y);
    swapValue(x, y);
    printf("Swap by value -> x = %i, y = %i\n", x, y);
    swapAddress(&x, &y);
    printf("Swap by address -> x = %i, y = %i\n", x, y);
    return 0;
}
