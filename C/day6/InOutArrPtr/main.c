#include <stdio.h>
#include <stdlib.h>

int main()
{
    int arr[5] = {};
    int *arrPtr = arr;

    for (int i = 0; i < 5; i++)
    {
        printf("Enter a value %i/5: ", i+1);
        scanf("%i", arrPtr+i);
    }

    puts("\n\n");

    for (int i = 0; i < 5; i++)
    {
        printf("Value %i/5: %i\n", i+1, arrPtr[i]);
    }

    return 0;
}
