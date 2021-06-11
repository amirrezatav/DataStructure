using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public class StackLinkedList<T> : IStack<T>
    {
        LinkedList<T> list;
        public int FullSize { get { return list.Count; } }

        public StackLinkedList()
        {
            list = new LinkedList<T>();
        }
        public void Clear()
        {
            list.clear();
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
            return list.End.Value;
        }

        public T Pop()
        {
            var res = list.End.Value;
            list.RemoveLast();
            return res;
        }

        public void Push(T item)
        {
            list.AddLast(item);
        }

        public bool IsExist(T item)
        {
            return list.Contains(item);
        }
        public static StackLinkedList<T> operator +(StackLinkedList<T> a, StackLinkedList<T> b)
        {
            StackLinkedList<T> res = new StackLinkedList<T>();
            return res;
        }
        public static void Copy(StackLinkedList<T> dis, StackLinkedList<T> source)
        {
            LinkedList<T>.Copy(dis.list, source.list);
        }
    }
}
