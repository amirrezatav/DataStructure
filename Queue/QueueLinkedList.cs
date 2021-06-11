using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public  class QueueLinkedList<T> : IQueue<T>
    {
        LinkedList<T> list;
        public int FullSize { get { return list.Count; } }
        public QueueLinkedList()
        {
            list = new LinkedList<T>();
        }

        public void Clear()
        {
            list.clear();
        }

        public T Dequeue()
        {
            var res = list.Head.Value;
            list.RemoveFirst();
            return res;
        }

        public void Enqueue(T item)
        {
            list.Add(item);
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public bool IsFull()
        {
            return false;
        }

        public T Peek()
        {
            return list.Head.Value;
        }
    }
}
