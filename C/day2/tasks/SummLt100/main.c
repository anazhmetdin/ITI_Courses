#include <stdio.h>
#include <stdlib.h>

int main()
{
    int x, sum = 0;

    while (sum <= 100)
    {
        printf("Please enter a number, sum now is %d: ", sum);
        scanf("%d", &x);
        sum += x;
    }


    printf("Sum now is %d\n", sum);

    return 0;
}
