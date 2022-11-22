#include <iostream>
#include <stdlib.h>
#include <conio.h>

using namespace std;

template <class T>
class Node
{
public:
    T data;
    Node *prev, *next;

    static Node* newNode(T data)
    {
        Node *node = (Node*) malloc(sizeof(Node));
        node->data = data;
        node->next = node->prev = NULL;

        return node;
    }
};

template <class T>
class DList
{
public:
    Node<T> *pFirst, *pLast;

    DList()
    {
        pFirst = NULL;
        pLast = NULL;
    }

    void add(T data)
    {
        Node<T> *node = Node<T>::newNode(data);

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
        Node<T>* current = pFirst;
        while(current != NULL)
        {
            cout << current->data << endl;
            current = current->next;
        }
    }

    Node<T>* search(T data)
    {
        Node<T>* current = pFirst;
        while(current != NULL)
        {
            if (current->data == data)
                return current;

            current = current->next;
        }

        return NULL;
    }

    void display(T data)
    {
        cout << search(data)->data;
    }

    void deleteAll()
    {
        Node<T> *temp;
        while (pFirst != NULL)
        {
            temp = pFirst;
            pFirst = pFirst->next;
            free(temp);
        }

        pFirst = NULL;
        pLast  = NULL;
    }

    void deleteNode(Node<T> *node)
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

    void deleteData(T data)
    {
        deleteNode(search(data));
    }

    ~DList()

    {
        deleteAll();
    }
};

template <class T>
class Stack
{
    DList<T> arr;
    int pos;

    void incrementPos()
    {
        pos++;
    }
    void decrementPos()
    {
        pos--;
    }
    int  getPos() const
    {
        return pos;
    }
    void setPos(int p)
    {
        pos = p;
    }

public:

    Stack()
    {
        setPos(0);
    }

    Stack(const Stack<T> &s)
    {
        setPos(0);
        Node<T>* current = s.arr.pLast;
        while(current != NULL)
        {
            push(current->data);

            current = current->prev;
        }
    }

    Stack(Stack<T> &stk)
    {
        // cout << "Copy Constructor: " << this << endl;
        setPos(0);
        Node<T> *temp = stk.arr.pFirst;
        while(temp != NULL)
        {
            push(temp->data);
            temp = temp->next;
        }
    }

    bool isEmpty()
    {
        return getPos() == 0;
    }

    void push(T data)
    {
        arr.add(data);
        incrementPos();
    }

    T pop()
    {
        if (isEmpty())
        {
            cout << "Stack is empty, can't pop" << endl;
            return T();
        }
        else
        {
            decrementPos();
            T data = arr.pLast->data;
            arr.deleteNode(arr.pLast);
            return data;
        }
    }

    T peek()
    {
        if (isEmpty())
        {
            cout << "Stack is empty, can't peek" << endl;
            return T();
        }
        else
        {
            return arr.pLast->data;
        }
    }

    bool isFull() {return false;};

    int getCount()
    {
        return getPos();
    }

    template <class A>
    friend void viewContent(Stack<A>&);

    Stack<T> reverseStack()
    {
        Stack<T> reversed;

        Node<T> temp = arr.pLast;
        while(temp != NULL)
        {
            reversed.push(temp);
            temp = temp.prev;
        }

        return reversed;
    }

    ~Stack()
    {
        arr.deleteAll();
    }
};

template <class T>
void viewContent(Stack<T> &stk)
{
    Node<T>* current = stk.arr.pLast;
    while(current != NULL)
    {
        cout << current->data << endl;

        current = current->prev;
    }
}

typedef struct Employee
{
    int ID, Age;
    char Gender, Name[100], Address[200];
    double Salary, OverTime, Deduct;
} Employee;

ostream& operator << (ostream &o, const Employee& emp)
{
    return o << emp.ID << ". " << emp.Name << ", $" << emp.Salary + emp.OverTime - emp.Deduct << endl;
}

int main()
{

    Stack<Employee> s1;

    Employee e1 = {1,25,'M',"Ahmed","st. df.", 2000, 400, 50};
    Employee e2 = {2,28,'M',"Ali","st. df.", 2500, 200, 100};
    Employee e3 = {3,23,'F',"Asmaa","st. df.", 2100, 200, 70};
    Employee e4 = {4,25,'M',"Alaa","st. df.", 2300, 100, 10};

    s1.push(e1);
    s1.push(e2);
    s1.push(e3);
    s1.push(e4);

    cout << "display stack:" << endl;
    viewContent(s1);

    cout << "s2 = s1" << endl;
    Stack<Employee> s2 = s1;

    cout << "\npeek:" << endl;
    cout << s1.peek();

    cout << "\npop:" << endl;
    cout << s1.pop();

    cout << "\ncount:" << endl;
    cout << s1.getCount() << endl;

    cout << "\npeek:" << endl;
    cout << s1.peek();


    cout << "\npop:" << endl;
    cout << s1.pop();
    cout << "\ncount:" << endl;
    cout << s1.getCount() << endl;
    cout << "\npop:" << endl;
    cout << s1.pop();
    cout << "\npop:" << endl;
    cout << s1.pop();
    cout << "\npop:" << endl;
    cout << s1.pop();

    cout << "\ndisplay s2:" << endl;
    viewContent(s2);

    return 0;
}
