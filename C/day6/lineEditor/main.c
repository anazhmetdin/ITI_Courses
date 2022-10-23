#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string.h>

#define lineSize 10

#define Enter 0x0D
#define ESC 27
#define SpecialIndicator -32
#define Up 72
#define Down 80
#define Right 77
#define Left 75
#define Home 71
#define End 79

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

/*
    fills line with accepted characters only and prints to the console

    x: column, y: row, Schar: first character in range, Echar: last char in range, line: char array to be edited
*/
void lineEditor(int x, int y, char Schar, char Echar, char *line)
{
    int sCol = x, cCol = x, eCol = x, maxCol = x + lineSize, exitFlag = 0;
    char key;

    do
    {
        // go to current place
        gotoxy(cCol, y);
        // get user input without printing
        key = _getch();
        // handle input
        switch (key)
        {
        // extended keys
        case SpecialIndicator:

            key = _getch(); // get next button from buffer

            switch (key) // handle extended keys
            {

            case Left:
                // go left if the cursor is after the start
                cCol = cCol > sCol ? cCol - 1 : cCol;
                break;

            case Right:
                // go right if the cursor is before the last character
                cCol = cCol < eCol ? cCol + 1 : cCol;
                break;

            case Home:
                // go to the beginning of the line
                cCol = sCol;
                break;

            case End:
                // go to the end of the line
                cCol = eCol;
                break;
            }

            break;

        case Enter:
            // break the input loop
            exitFlag = 1;
            break;

        case ESC:
            // go to the end of the line
            cCol = eCol;
            break;

        default: // other non-extended keys

            // if there still a place in the line
            if (cCol < maxCol && ((key >= Schar && key <= Echar) || key == ' '))
            {
                // add key to the line
                line[cCol - x] = key;
                // print it to the screen
                printf("%c", key);
                // if we are at the end of the line
                if (cCol == eCol)
                {
                    // expand the line position
                    eCol++;
                }
                // move the cursor
                cCol++;
            }
        }
    }
    while (!exitFlag);
}

int main()
{
    char line[lineSize + 1];

    printf("Please enter your number (max 10):\n");

    lineEditor(0, 3, 48, 57, line);

    printf("\n\n\nYour input is:\n");
    puts(line);
    return 0;
}
