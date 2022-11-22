#include <iostream>

using namespace std;

// swap two variables
template <class T>
void _swap(T& x, T& y)
{
    T temp = x;
    x = y;
    y = temp;
}

// find index that maximizes the comparison function
template <class T>
int findIndex(T* arr, int start, int last, int (*compare)(T, T))
{
    int index = start;
    for (int i = start+1; i < last; i++)
    {
        if (compare(arr[i], arr[index]) > 0)
        {
            index = i;
        }
    }
    return index;
}

// sort array in-place using the the comparison function
template <class T>
void selectionSort(T* arr, int n, int (*compare)(T, T))
{
    for (int i = 0; i < n-1; i++)
    {
        _swap(arr[i], arr[findIndex(arr, i, n, compare)]);
    }
}

// print array in one line
template <class T>
void printArray(T* arr, int n)
{
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;
}

// comparison function
int greaterThan(int x, int y)
{
    return x-y;
}

// comparison function
int lessThan(int x, int y)
{
    return y-x;
}

int main()
{
    int arr[] = {64, 25, 12, 22, 11};

    cout << "Unsorted array: \n";
    printArray<int>(arr, 5);

    selectionSort<int>(arr, 5, &greaterThan);

    cout << "Sorted array descendantly: \n";
    printArray<int>(arr, 5);

    selectionSort<int>(arr, 5, &lessThan);

    cout << "Sorted array ascendantly: \n";
    printArray<int>(arr, 5);

    return 0;
}
