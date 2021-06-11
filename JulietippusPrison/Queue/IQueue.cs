using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulietippusPrison
{
    interface IQueue<T>
    {
        // 	Adds an object to the end of the queue.
        void Enqueue(T item);
        // Removes and returns the object at the beginning of the queue.
        T Dequeue();
        bool IsEmpty();
        bool IsFull();
        // Returns the object at the beginning of the queue without removing it.
        T Peek();
        // Removes all objects from the queue.
        void Clear();
    }
}
