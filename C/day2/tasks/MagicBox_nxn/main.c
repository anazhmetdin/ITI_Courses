#include <stdio.h>
#include <stdlib.h>
#include <windows.h>


/*
    function to circulate around n
    inputs:
    x: coordinate value
    n: grid size
*/
int circle(int x, int n) {

    if (x < 0) {
        return n + x;
    }
    else if (x >= n) {
        return x - n;
    }

    return x;
}


/*
    function to move cursor to x, y
*/
void gotoxy( int column, int line )
{
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
}


int main()
{
    // grid size, row index, column index, coordinate position of first column in rows, coordinate position of first row in columns
    int n, row = 0, col, rowStart = 0, colStart = 5;

    // take input from user until input is valid
    do
    {
        printf("Please enter grid size (positive odd): ");
        scanf("%d", &n);
    }
    while (n <= 0 || n % 2 == 0);

    // calculate the middle position
    col = n / 2;

    for (int i = 1; i <= n*n; i++)
    {
        // move cursor to the right position
        gotoxy(rowStart + col * 3, colStart + row * 3);
        // print the current number
        printf("%d", i);

        // move in grid according to the current number
        if (i % n == 0)
        {
            row++;
        }
        else
        {
            row--;
            col--;

        }

        // make sure that coordinates are inside the grid
        col = circle(col, n);
        row = circle(row, n);
    }


    return 0;
}
