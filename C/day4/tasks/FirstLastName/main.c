#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char firstName[100] = {}, lastName[100] = {}, fullName[200] = {};

    printf("Enter your first name: ");
    gets(firstName);

    printf("Enter your last name: ");
    gets(lastName);

    strcpy(fullName, firstName);

    strcat(fullName, " ");
    strcat(fullName, lastName);

    printf("\nYour full name is: ");
    puts(fullName);

    return 0;
}
