#include <stdio.h>
#include <stdlib.h>
#define size 5

int main()
{
    int arr[size] = {};

    for (int i = 0; i < size; i++)
    {
        printf("Please enter int #%i/%i: ", i+1, size);
        scanf("%i", &arr[i]);
    }

    for (int i = 0; i < size; i++)
    {
        printf("value #%i/%i: %i\n", i+1, size, arr[i]);
    }

    return 0;
}
