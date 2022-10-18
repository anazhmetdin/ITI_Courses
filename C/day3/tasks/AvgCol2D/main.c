#include <stdio.h>
#include <stdlib.h>
#define rows 2
#define cols 3

int main()
{
    int arr[rows][cols] = {};
    int avg[cols] = {};

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            printf("please enter int in row #%i/%i, column #%i/%i: ", i+1, rows, j+1, cols);
            scanf("%i", &arr[i][j]);

            avg[j] += arr[i][j];
        }
    }

    for (int i = 0; i < cols; i++)
    {
        printf("Average of column #%i: %.2f\n", i+1, (float) avg[i] / rows);
    }

    return 0;
}
