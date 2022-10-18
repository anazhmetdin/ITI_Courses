#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#define size 5

int main()
{
    int arr[size] = {};
    int minimum = INT_MAX;
    int maximum = INT_MIN;

    for (int i = 0; i < size; i++)
    {
        printf("Please enter int #%i/%i: ", i+1, size);
        scanf("%i", &arr[i]);

        if (arr[i] > maximum)
        {
            maximum = arr[i];
        }

        if (arr[i] < minimum)
        {
            minimum = arr[i];
        }
    }

    printf("Maximum value is: %i\n", maximum);
    printf("Minimum value is: %i\n", minimum);

    return 0;
}
