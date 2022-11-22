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

template <class T>
int partitionPivot(T* arr, int first, int last, int (*compare)(T, T))
{
    int& pivot = arr[last];
    int index = first - 1;

    for (int i = first; i <= last - 1; i++)
    {
        if (compare(arr[i], pivot) > 0)
        {
            _swap(arr[i], arr[++index]);
        }
    }
    _swap(pivot, arr[++index]);

    return index;
}

// sort array in-place using the the comparison function
template <class T>
void quickSort(T* arr, int first, int last, int (*compare)(T, T))
{
    if (first < last)
    {
        int pivot = partitionPivot(arr , first, last, compare);
        quickSort(arr, first, pivot - 1, compare);
        quickSort(arr, pivot + 1, last, compare);
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

    quickSort<int>(arr, 0, 4, &greaterThan);

    cout << "Sorted array descendantly: \n";
    printArray<int>(arr, 5);


    quickSort<int>(arr, 0, 4, &lessThan);

    cout << "Sorted array ascendantly: \n";
    printArray<int>(arr, 5);

    return 0;
}
