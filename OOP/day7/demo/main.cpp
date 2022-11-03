#include <iostream>

using namespace std;

class parent
{
public:
    int x;
};

class child: public parent
{
public:
    int y;
};

int main()
{
    child *cPtr = new child[3];
    (cPtr)->x = 1;
    (cPtr+1)->x = 2;
    (cPtr+2)->x = 3;
    (cPtr+2)->y = 4;
    (cPtr+1)->y = 5;
    (cPtr+2)->y = 6;
    cout << "";
    cout << (cPtr+1)->x << endl;

    // won't work properly since the pointer step is different
    parent *pPtr = cPtr;
    cout << (pPtr+1)->x << endl;

    // won't work properly since the pointer step is different
    parent **pPtr1 = new parent*;
    pPtr1[0] = cPtr;

    cout << (*(pPtr1+1))->x << endl;

    return 0;
}
