//
// Created by Liza Zayats on 21.05.2022.
//
#include <iostream>
#include <cstdlib>
#include <vector>
#include <iterator>
#include"stdc++.h"
#include"BinomialHeap.cpp"

using namespace std;

class BinaryHeap {
private:
    vector <int> heap;
    int l(int parent);
    int r(int parent);
    int par(int child);
    void heapifyup(int index);
    void heapifydown(int index);
public:
    BinaryHeap() {}
    void Insert(int element);
    void DeleteMin();
    int ExtractMin();
    void showHeap();
    int Size();
};
int main() {

    int ch,key;
    list<Node*> _heap;

    // Insert data in the heap
    for (int i = 0; i < 16; i++) {
        _heap = insert(_heap, rand() % 100);
    }

    cout << "Heap elements after insertion:\n";
    printHeap(_heap);

    Node *temp = getMin(_heap);
    cout << "\nMinimum element of heap "
         << temp->data << "\n";

    // Delete minimum element of heap
    _heap = extractMin(_heap);
    cout << "Heap after deletion of minimum element\n";
    printHeap(_heap);

    BinaryHeap h;
    for(int i = 0; i < 16; i++) {
        h.Insert(rand()%100);
    }
    h.showHeap();
    cout << "Minimum element is: " << h.ExtractMin() << "\n";
    h.DeleteMin();
    h.showHeap();
    cout << "Minimum element is: " << h.ExtractMin() << "\n";
}
int BinaryHeap::Size() {
    return heap.size();
}
void BinaryHeap::Insert(int ele) {
    heap.push_back(ele);
    heapifyup(heap.size() -1);
}
void BinaryHeap::DeleteMin() {
    if (heap.size() == 0) {
        cout<<"Heap is Empty"<<endl;
        return;
    }
    heap[0] = heap.at(heap.size() - 1);
    heap.pop_back();
    heapifydown(0);
    cout<<"Element Deleted"<<endl;
}
int BinaryHeap::ExtractMin() {
    if (heap.size() == 0) {
        return -1;
    }
    else
        return heap.front();
}
void BinaryHeap::showHeap() {
    vector <int>::iterator pos = heap.begin();
    cout<<"Binary Heap :  ";
    while (pos != heap.end()) {
        cout<<*pos<<" ";
        pos++;
    }
    cout<<endl;
}
int BinaryHeap::l(int parent) {
    int l = 2 * parent + 1;
    if (l < heap.size())
        return l;
    else
        return -1;
}
int BinaryHeap::r(int parent) {
    int r = 2 * parent + 2;
    if (r < heap.size())
        return r;
    else
        return -1;
}
int BinaryHeap::par(int child) {
    int p = (child - 1)/2;
    if (child == 0)
        return -1;
    else
        return p;
}
void BinaryHeap::heapifyup(int in) {
    if (in >= 0 && par(in) >= 0 && heap[par(in)] > heap[in]) {
        int temp = heap[in];
        heap[in] = heap[par(in)];
        heap[par(in)] = temp;
        heapifyup(par(in));
    }
}
void BinaryHeap::heapifydown(int in) {
    int child = l(in);
    int child1 = r(in);
    if (child >= 0 && child1 >= 0 && heap[child] > heap[child1]) {
        child = child1;
    }
    if (child > 0 && heap[in] > heap[child]) {
        int t = heap[in];
        heap[in] = heap[child];
        heap[child] = t;
        heapifydown(child);
    }
}