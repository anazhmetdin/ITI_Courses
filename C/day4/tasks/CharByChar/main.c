#include <stdio.h>
#include <stdlib.h>

#define Enter 0x0D
#define NullTerminator '\0'

int main()
{
    // text to store user input
    char text[100] = {}, ch;

    printf("Enter your text (max 100 char, press enter when finished):\n");

    // read char by char until enter is pressed
    int i = 0;
    do
    {
        ch = _getche();
        // add null terminator if enter is pressed, else add ch
        text[i] = ch == Enter ? NullTerminator : ch;
        i++;
    }
    while (ch != Enter);


    printf("\n\nHere is your text using loop: \n");
    i = 0;
    do
    {
        // print char by char until the null terminator
        printf("%c", text[i]);
        i++;
    }
    while (text[i] != NullTerminator);

    printf("\n\nHere is your text using puts: \n");
    puts(text);


    return 0;
}
