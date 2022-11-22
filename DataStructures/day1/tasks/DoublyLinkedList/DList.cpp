#include "DList.h"
#include <iostream>

using namespace std;

template <class T>
Node<T>* Dlist<T>::getFirst()
{
    return pFirst;
}

template <class T>
Node<T>* Dlist<T>::getLast()
{
    return pLast;
}

template <class T>
void Dlist<T>::setFirst(Node<T>* first)
{
    pFirst = first;
}

template <class T>
void Dlist<T>::setLast(Node<T>* last)
{
    pLast = last
}

template <class T>
void Dlist<T>::add(T data)
{
    Node<T> *node = new Node<>(data);

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

bool remove(T);
void removeAll();
Node<T>* find(T);
void display();