#include <stdio.h>
#include <stdlib.h>

int main()
{
    int option = -1;

    while (option != 0)
    {
        printf("=================\n");

        printf("1- option 1\n");
        printf("2- option 2\n");
        printf("3- option 3\n");
        printf("0- Exit\n");

        printf("please enter your option: ");
        scanf("%d", &option);
    }

    printf("\nGoodbye!");

    return 0;
}
