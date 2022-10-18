#include <stdio.h>
#include <stdlib.h>

int multVect(int cols1, int cols2, int mat1[][cols1], int mat2[][cols2], int row, int col, int len)
{
    int result = 0;

    for (int i = 0; i < len; i++)
    {
        result += mat1[row][i] * mat2[i][col];
    }

    return result;
}


int main()
{

    int rows1 = 3, cols1 = 2, cols2 = 1;
    int rows2 = cols1;
    int mat1[rows1][cols1];
    int mat2[rows2][cols2];

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols1; j++)
        {
            printf("please enter int in matrix 1, row #%i/%i, column #%i/%i: ", i+1, rows1, j+1, cols1);
            scanf("%i", &mat1[i][j]);
        }
    }

    for (int i = 0; i < rows2; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            printf("please enter int in matrix 2, row #%i/%i, column #%i/%i: ", i+1, rows2, j+1, cols2);
            scanf("%i", &mat2[i][j]);
        }
    }

    printf("\nResult:\n");
    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            printf("%i ", multVect(cols1, cols2, mat1, mat2, i, j, cols1));
        }
        printf("\n");
    }

    return 0;
}
