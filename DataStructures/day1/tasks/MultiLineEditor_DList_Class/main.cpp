#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
#include <string.h>

#define MenuCount 6
#define FormCount 8
#define EmpCount 10
#define lineSize 10

#define NotFound "\nThis employee wasn't found.\n"

#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27
#define Backspace 8
#define Tab 9

#define SpecialIndicator -32
#define Up 72
#define Down 80
#define Right 77
#define Left 75
#define Home 71
#define End 79
#define Delete 83
#define Insert 82


typedef struct Employee
{
    int ID, Age;
    char Gender, Name[100], Address[200];
    double Salary, OverTime, Deduct;
} Employee;

class Node
{
public:
    Employee *data;
    Node *prev, *next;

    static Node* newNode(Employee *emp)
    {
        Node *E = (Node*) malloc(sizeof(Node));
        E->data = emp;
        E->next = E->prev = NULL;

        return E;
    }
};

void displayEmployee(Employee *emp)
{
    if (emp == NULL)
        printf("\nThis employee doesn't exist\n\n");

    printf("\n%i. %s, $%.2lf\n\n", emp->ID, emp->Name, emp->Salary + emp->OverTime - emp->Deduct);
}

class DList
{
public:
    Node *pFirst, *pLast;

    DList()
    {
        pFirst = NULL;
        pLast = NULL;
    }

    void addEmp(Employee *emp)
    {
        Node *node = Node::newNode(emp);

        if (pFirst == NULL)
        {
            pFirst = pLast = node;
        }
        else
        {
            node->prev = pLast;
            pLast = pLast->next = node;
        }
    }

    void displayAll()
    {
        Node* current = pFirst;
        while(current != NULL)
        {
            displayEmployee(current->data);
            current = current->next;
        }
    }

    Node* search(int id)
    {
        Node* current = pFirst;
        while(current != NULL)
        {
            if (current->data->ID == id)
                return current;

            current = current->next;
        }

        return NULL;
    }

    Node* searchName(char *name)
    {
        Node* current = pFirst;
        while(current != NULL)
        {
            if (strcmp(current->data->Name, name) == 0)
                return current;

            current = current->next;
        }

        return NULL;
    }

    void display(int id)
    {
        displayEmployee(search(id)->data);
    }

    void deleteAll()
    {
        Node *temp;
        while (pFirst != NULL)
        {
            temp = pFirst;
            pFirst = pFirst->next;
            free(temp->data);
            free(temp);
        }
    }

    void deleteNode(Node *node)
    {
        if (node != NULL)
        {
            if (node->prev == NULL)
            {
                pFirst = node->next;
                if (pFirst != NULL)
                    pFirst->prev = NULL;
            }
            else if (node->next == NULL)
            {
                pLast = node->prev;
                pLast->next = NULL;
            }
            else if (pFirst == pLast)
            {
                pFirst = pLast = NULL;
            }
            else
            {
                node->prev->next = node->next;
                node->next->prev = node->prev;
            }

            free(node);
        }
    }

    void deleteEmp(int id)
    {
        Node *node = search(id);
        deleteNode(node);
    }

    void deleteEmpName(char *name)
    {
        Node *node = searchName(name);
        deleteNode(node);
    }
};

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

/*
    get x position of form element number i
*/
int getX(int i)
{
    return (i/6)*35+15;
}

/*
    get y position of form element number i
*/
int getY(int i)
{
    return (i%6)*3+3;
}

/*
    go to the place where user will enters input number i
*/
void gotoIInput(int i)
{
    gotoxy(getX(i), getY(i));
}

/*
    print spaces in the current input
*/
void printSpaces(int i, int size)
{
    gotoIInput(i);
    for (int j = 0; j < size; j++)
        printf(" ");
    gotoIInput(i);
}

/*
    Highlight current input
*/
void highlightInput(int i, int size)
{
    textattr(HighLightPen);
    printSpaces(i, size);
}

/*
    Normal pen with current input
*/
void lowlightInput(int i, char *line, int size)
{
    // reset pen
    textattr(NormalPen);
    // go to the beginning of the input
    gotoIInput(i);

    // print current line
    printf("%s", line);

    // get string length and print the reminder spaces
    int len = strlen(line);
    for (int j = 0; j < size - len; j++)
        printf(" ");
}

/*
    shifts array and on screen
*/
void shiftLeft(char *start, char *end, char *line)
{
    for (char *cChar = start; cChar < end; cChar++)
    {
        *cChar = *(cChar+1);
        printf("%c", *cChar);
    }
    printf(" ");
}

/*
    set field parameters when entering for the first time
*/
void setFieldParameters(int x, int y, char *line, int size, int *cols[4], char **chars[3], int field)
{

    highlightInput(field, size);

    for (int i = 0; i < 3; i++)
    {
        *cols[i] = x;
        *chars[i] = line;
    }

    *cols[3] = x + size;
}

/*
    fills line with accepted characters only and prints to the console

    x: column, y: row, Schar: first character in range, Echar: last char in range, line: char array to be edited
*/
char **lineEditor(int count, int *size, int *x, int *y, char *sRange, char *eRange, char **allowedChar)
{
    char **line = (char**) malloc(count * sizeof(char*));

    int sCol, cCol, eCol, maxCol, exitFlag = 0, insert = 0, valid;
    char key, *sChar, *cChar, *eChar;

    // grouping parameters in an array
    int *cols[4] = {&sCol, &cCol, &eCol, &maxCol};
    char **chars[3] = {&sChar, &cChar, &eChar};

    int field = 0;

    // initializing strings with the required size
    for (int i = 0; i < count; i++)
    {
        line[i] = (char*) malloc((size[i] + 1) * sizeof(char));
        // filling strings with null terminators
        for (int j = 0; j < size[i] + 1; j++)
            line[i][j] = '\0';
    }

    setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);

    do
    {
        // go to current place
        gotoxy(cCol, y[field]);
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
                if (cCol > sCol)
                {
                    cCol--;
                    cChar--;
                }
                break;

            case Right:
                // go right if the cursor is before the last character
                if (cCol < eCol)
                {
                    cCol++;
                    cChar++;
                }
                break;

            case Up:
                // move to the upper field
                if (field > 0)
                {
                    lowlightInput(field, line[field], size[field]);
                    field--;
                    setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);
                }
                break;

            case Down:
                // move to the below field
                if (field < count - 1)
                {
                    lowlightInput(field, line[field], size[field]);
                    field++;
                    setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);
                }
                break;

            case Home:
                // go to the beginning of the line
                cCol = sCol;
                cChar = sChar;
                break;

            case End:
                // go to the end of the line
                cCol = eCol;
                cChar = eChar;
                break;

            case Delete:
                // if cursor is not at the end
                if (cCol < eCol)
                {
                    // shift elements to the left starting from current
                    shiftLeft(cChar, eChar, line[field]);
                    // decrease text size
                    eCol--;
                    eChar--;
                }
                break;

            case Insert:
                insert = !insert;
                break;
            }

            break;

        case Enter:
            // move to the below field
            lowlightInput(field, line[field], size[field]);
            if (field < count - 1)
            {
                field++;
                setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);
            }
            else
            {
                exitFlag = 1;
            }
            break;

        case ESC:
            textattr(NormalPen);
            system("cls");
            _Exit(0);
            break;

        case Tab:
            // move to next field and circulate
            if (field < count - 1)
            {
                lowlightInput(field, line[field], size[field]);
                field++;
                setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);
            }
            else
            {
                lowlightInput(field, line[field], size[field]);
                field = 0;
                setFieldParameters(x[field], y[field], line[field], size[field], cols, chars, field);
            }
            break;

        case Backspace:

            if (cCol > sCol)
            {
                // move cursor back
                gotoxy(--cCol, y[field]);
                cChar--;
                // shift chars left
                shiftLeft(cChar, eChar, line[field]);

                eChar--;
                eCol--;
            }

            break;

        default: // other non-extended keys
            // if key is in range or it's an allowed character
            valid = (key >= sRange[field] && key <= eRange[field]) || (strchr(allowedChar[field], key) != NULL);

            if (!insert) // override
            {
                // if there still a place in the line
                if (cCol < maxCol && valid)
                {
                    // add key to the line
                    *cChar = key;
                    // print it to the screen
                    printf("%c", key);
                    // if we are at the end of the line
                    if (cCol == eCol)
                    {
                        // expand the line position
                        eCol++;
                        eChar++;
                    }
                    // move the cursor
                    cCol++;
                    cChar++;
                }
            }
            else // shift
            {
                // there is a place at the end
                if (eCol < maxCol && valid)
                {
                    // print the input key
                    printf("%c", key);
                    // expand the end position
                    eCol++;
                    eChar++;
                    int index = 0;
                    // shift chars to the right, starting from the end
                    for (char *i = eChar; i > cChar; i--)
                    {
                        gotoxy(eCol - index, y[field]);
                        *i = *(i-1);
                        printf("%c", *i);
                        index++;
                    }
                    // insert input to the array
                    *cChar = key;
                    cCol++;
                    cChar++;
                }
            }
        }
    }
    while (!exitFlag);

    return line;
}

/*
    function to prints new employee form and gets information from user
*/
Employee* getEmployee(Employee *emp)
{
    char formEntries[FormCount][12] = {"ID        :", "Age       :", "Gender M/F:", "Name      :", \
                                       "Address   :", "Salary    :", "Over  Time:", "Deduct    :"
                                      };

    int x[FormCount], y[FormCount];

    // print form
    for (int i = 0; i < FormCount; i++)
    {
        x[i] = getX(i);
        y[i] = getY(i);
        gotoxy(x[i] - 12, y[i]);
        puts(formEntries[i]);
    }

    _flushall();

    char sRange[FormCount] = {48, 48, 0, 65, 33, 48, 48, 48};
    char eRange[FormCount] = {57, 57, 0, 122, 122, 57, 57, 57};

    char *allowedChar[FormCount] = {"", "", "MF\0", " ", " ,.", ".", ".", "."};
    int size[FormCount] = {8, 2, 1, 16, 32, 8, 8, 8};

    char **lines = lineEditor(FormCount, size, x, y, sRange, eRange, allowedChar);

    _flushall();

    char *ptr;

    emp = (Employee*) malloc(sizeof(Employee));

    emp->ID = atoi(lines[0]);
    emp->Age = atoi(lines[1]);
    emp->Gender = lines[2][0];
    strcpy(emp->Name, lines[3]);
    strcpy(emp->Address, lines[4]);
    emp->Salary = strtod(lines[5], &ptr);
    emp->OverTime = strtod(lines[6], &ptr);
    emp->Deduct = strtod(lines[7], &ptr);

    return emp;
}

/*
    prints employee summary using its index in the emp array
*/
void displayEmployeeIndex(Employee *emp, int i)
{
    displayEmployee(&emp[i]);
}

/*
    displays all employees from emp array
*/
void displayEmployees(Employee *emp)
{
    // records if the list empty or not
    int empty = 0;
    for (int i = 0; i < EmpCount; i++)
    {
        // display Employee info if exists
        if (strcmp("", emp[i].Name) != 0)
        {
            empty++;
            displayEmployeeIndex(emp, i);
        }
    }

    if (!empty)
        printf("There are no employees, yet");
}

/*
    displays an employee from the emp Arr using its ID
*/
void displayEmployeeID(Employee *emp, int id)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // display Employee info if the ID matches
        if (id == emp[i].ID && strcmp("", emp[i].Name) != 0)
        {
            displayEmployeeIndex(emp, i);
            return;
        }
    }

    printf(NotFound);
}

/*
    delete an employee from the emp Arr using its index, and shift all other elements left
    up to currentEmp
*/
void deleteEmployeeIndex(Employee *emp, int index, int currentEmp)
{
    currentEmp = currentEmp == EmpCount ? currentEmp - 1 : currentEmp;

    for (int i = index; i < currentEmp - 1; i++)
    {
        emp[i] = emp[i+1];
    }

    emp[currentEmp - 1].ID = -1;
    strcpy(emp[currentEmp - 1].Name, "");
}

/*
    confirms from the user to delete an employee from the emp Arr using its index,
    and shift all other elements left up to currentEmp
*/
int areYouSureDelete(Employee *emp, int index, int currentEmp)
{
    displayEmployeeIndex(emp, index);
    char sure;
    do
    {
        printf("Are you sure you want to delete this employee? (y/n)\n");
        scanf("%c", &sure);
    }
    while (sure != 'y' && sure != 'n');

    if (sure == 'y')
    {
        deleteEmployeeIndex(emp, index, currentEmp);
        return 1;
    }
    else
    {
        return 0;
    }
}

/*
    delete an employee from the emp Arr using its ID, and shift all other elements left
    up to currentEmp
*/
int deleteEmployeeID(Employee *emp, int id, int currentEmp)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // delete Employee info if the ID matches
        if (id == emp[i].ID && strcmp("", emp[i].Name) != 0)
        {
            // ask the user if he is sure to delete this emp
            return areYouSureDelete(emp, i, currentEmp);
        }
    }

    printf(NotFound);

    return 0;
}


/*
    delete an employee from the emp Arr using its Name, and shift all other elements left
    up to currentEmp
*/
int deleteEmployeeName(Employee *emp, char name[100], int currentEmp)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // delete Employee info if the name matches
        if (strcmp(name, emp[i].Name) == 0 && strcmp("", emp[i].Name) != 0)
        {
            // ask the user if he is sure to delete this emp
            return areYouSureDelete(emp, i, currentEmp);
        }
    }

    printf(NotFound);

    return 0;
}

/*
    returns the first index of emp having the same id, returns -1 if not found
*/
int findId(Employee *emp, int id)
{
    for (int i = 0; i < EmpCount; i++)
    {
        if (emp[i].ID == id && strcmp("", emp[i].Name) != 0)
        {
            return i;
        }
    }

    return -1;
}

/*
    halts until user press any key
*/
void waitKey()
{
    _flushall();
    printf("\n\n\n(press any key to continue)");
    _getch();
    _flushall();
}


int main()
{
    // menu stores entry options, key stores user input
    // nameTemp stores employee name to be deleted
    char menu[MenuCount][15] = {"New", "Display By ID", "Display All",
                                "Delete By ID", "Delete By Name", "Exit"},
         key, nameTemp[100];
    // current highlighted option, exitFlag when ESC or Exit
    int current = 0, exitFlag = 0, ID, found;
    // array of employees
    //Employee emp[EmpCount] = {}, empTemp = {}, *empPtr = &empTemp;
    Employee *empPtr;
    Node *tempNode;
    DList emp;

    // print menu after each key stroke, until user exits
    do
    {
        system("cls");

        // print menu entries
        for (int i = 0; i < MenuCount; i++)
        {
            // highlight current
            if (current == i)
                textattr(HighLightPen);


            gotoxy(5, 3+3*i);
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
                // if there is a place for a new emp
                // get emp info
                empPtr = getEmployee(empPtr);

                // checks if the ID already exists
                tempNode = emp.search(empPtr->ID);
                found = tempNode != NULL;

                // if not found
                if (found == 0)
                     emp.addEmp(empPtr);
                else // if found, ask the user to be replaced
                {
                    char replace;

                    system("cls");

                    _flushall();

                    do
                    {
                        printf("\nThis ID exists:");
                        displayEmployee(empPtr);
                        printf("Do you want to replace him/her? (y/n)\n");
                        scanf("%c", &replace);
                    }
                    while(replace != 'y' && replace != 'n');

                    _flushall();

                    if (replace == 'y')
                        tempNode->data = empPtr;

                    waitKey();
                }
                break;

            case 1: // display by ID
                system("cls");
                _flushall();
                printf("Please enter the employee ID to be displayed: ");
                scanf("%i", &ID);
                _flushall();
                displayEmployee(emp.search(ID)->data);
                waitKey();
                break;

            case 2: // display all
                system("cls");
                emp.displayAll();
                waitKey();
                break;

            case 3: // delete by ID
                system("cls");
                printf("Please enter the employee ID to be DELETED: ");
                _flushall();
                scanf("%i", &ID);
                _flushall();
                emp.deleteEmp(ID);
                waitKey();
                break;

            case 4: // delete by Name
                system("cls");
                printf("Please enter the employee Name to be DELETED: ");
                _flushall();
                gets(nameTemp);
                emp.deleteEmpName(nameTemp);
                waitKey();
                break;

            case 5: // exit
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
                current = !current ? MenuCount-1 : current - 1;
                break;

            case Down:
                current = current == MenuCount-1 ? 0 : current + 1;
                break;

            case Home:
                current = 0;
                break;

            case End:
                current = MenuCount-1;
                break;
            }

            break;
        }
    }
    while (!exitFlag);

    return 0;
}
