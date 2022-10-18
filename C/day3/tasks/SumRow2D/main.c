#include <stdio.h>
#include <stdlib.h>
#define rows 2
#define cols 3

int main()
{
    int arr[rows][cols] = {};
    int sums[rows] = {};

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            printf("please enter int in row #%i/%i, column #%i/%i: ", i+1, rows, j+1, cols);
            scanf("%i", &arr[i][j]);

            sums[i] += arr[i][j];
        }
    }

    for (int i = 0; i < rows; i++)
    {
        printf("Sum of row #%i: %i\n", i+1, sums[i]);
    }

    return 0;
}
