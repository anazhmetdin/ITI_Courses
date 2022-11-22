#ifndef DLIST
#define DLIST

#include "../Node/Node.h"

template <class T>
class Dlist
{
    Node<T> *pFirst, *pLast;
public:
    Node<T>* getFirst();
    Node<T>* getLast();
    void setFirst(Node<T>*);
    void setLast(Node<T>*);

    void add(T);
    bool remove(T);
    void removeAll();
    Node<T>* find(T);
    void display();
};

#endif