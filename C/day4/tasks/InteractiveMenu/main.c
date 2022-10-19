#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
#include <string.h>

#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27
#define SpecialIndicator -32
#define Up 72
#define Down 80
#define Home 71
#define End 79
/*
    function to colorize output
*/
void textattr (int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
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
    // menu stores entry options, key stores user input
    // data stores saved text, dataTemp cashes user data
    char menu[3][5] = {"New ", "Save", "Exit"}, key, data[100] = {}, dataTemp[100] = {};
    // current highlighted option, exitFlag when ESC or Exit
    int current = 0, exitFlag = 0;

    // print menu after each key stroke, until user exits
    do
    {
        system("cls");
        puts("Current data: ");
        puts(data);

        // print menu entries
        for (int i = 0; i < 3; i++)
        {
            // highlight current
            if (current == i)
                textattr(HighLightPen);


            gotoxy(5, 10+3*i);
            // print this entry
            puts(menu[i]);
            // reset text color
            textattr(NormalPen);
        }

        // get user input
        key = _getch();

        // react to user input
        switch (key)
        {
        case ESC:
            exitFlag = 1;
            break;

        case Enter:
            // do current entry
            switch (current)
            {
                case 0: // new
                    system("cls");
                    puts("Please enter your note: ");
                    gets(dataTemp);
                    break;

                case 1: // save
                    strcpy(data, dataTemp);
                    break;

                case 2: // exit
                    exitFlag = 1;
                    break;
            }

            break;

        case SpecialIndicator: // extended keys

            // read from buffer
            key = _getch();

            // perform key
            switch (key)
            {

            case Up:
                current = !current ? 2 : current - 1;
                break;

            case Down:
                current = current == 2 ? 0 : current + 1;
                break;

            case Home:
                current = 0;
                break;

            case End:
                current = 2;
                break;
            }

            break;
        }
    }
    while (!exitFlag);
}
