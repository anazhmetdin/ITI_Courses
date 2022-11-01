#include <iostream>

using namespace std;

class test
{
    static int x;

public:
    static int getX()
    {
        return x;
    }
};
int test::x = 0;

int main()
{
    cout << test::getX() << endl;
    return 0;
}
