using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    
    public class LinkedListNode<Type>
    {
        public Type Value { get; set; }
        public LinkedListNode<Type> Next { get; set; }
        public LinkedListNode<Type> Previous { get; set; }
    }
    public interface IlinkedList<T>
    {
        void Add( LinkedListNode<T> newNode);
        // Adds a new node containing the specified value after the specified existing node in the LinkedList<T>.
        void Add( T newValue);
        // Adds the specified new node after the specified existing node in the LinkedList<T>.
        void AddAfter(LinkedListNode<T> existingNode, LinkedListNode<T> newNode);
        // Adds a new node containing the specified value after the specified existing node in the LinkedList<T>.
        void AddAfter(LinkedListNode<T> existingNode,T newValue);
        // Adds a new node containing the specified value after the specified existing node in the LinkedList<T>.
        void AddBefore(LinkedListNode<T> existingNode, LinkedListNode<T> newNode);
        // Adds a new node containing the specified value before the specified existing node in the LinkedList<T>.
        void AddBefore(LinkedListNode<T> existingNode, T newValue);
        // Adds the specified new node at the start of the LinkedList<T>.
        void AddFirst(LinkedListNode<T> newNode);
        // Adds a new node containing the specified value at the start of the LinkedList<T>.
        void AddFirst(T newValue);
        // Adds the specified new node at the end of the LinkedList<T>.
        void AddLast(LinkedListNode<T> newNode);
        // Adds a new node containing the specified value at the end of the LinkedList<T>.
        void AddLast(T newValue);
        // Removes all nodes from the LinkedList<T>.
        void clear();
        // Determines whether a value is in the LinkedList<T>.
        bool Contains(T value);
        // Determines whether a Node is in the LinkedList<T>.
        bool Contains(LinkedListNode<T> value);
        // Finds the first node that contains the specified value.
        LinkedListNode<T> Find(T Value);
        // 	Finds the last node that contains the specified value.
        LinkedListNode<T> FindLast(T Value);
        // Removes the specified node from the LinkedList<T>.
        void Remove(LinkedListNode<T> newNode);
        // Removes the first occurrence of the specified value from the LinkedList<T>.
        void Remove(T newValue);
        // Removes the node at the start of the LinkedList<T>.
        void RemoveFirst();
        // Removes the node at the end of the LinkedList<T>.
        void RemoveLast();


    }
    public class LinkedList<T> : IlinkedList<T>
    {
        public int Count { get; set; }
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> End { get; set; }
        public LinkedList()
        {
            Head = null;
            End = null;
        }
        public void Add( LinkedListNode<T> newNode)
        {
            AddLast(newNode);
        }
        public void Add(T newValue)
        {
            AddLast(newValue);
        }
        public void AddAfter(LinkedListNode<T> existingNode, LinkedListNode<T> inputnewNode)
        {
            if (!Contains(existingNode)) throw new Exception("Passed Node Not Found !");
            Count++;
            LinkedListNode<T> newNode = new LinkedListNode<T>() {Value = inputnewNode.Value };
            newNode.Previous = existingNode;
            newNode.Next = existingNode.Next;
            existingNode.Next.Previous = newNode;
            existingNode.Next = newNode;
        }
        public void AddAfter(LinkedListNode<T> existingNode, T newValue)
        {
            if (!Contains(existingNode)) throw new Exception("Passed Node Not Found !");
            Count++;
            LinkedListNode<T> newNode = new LinkedListNode<T>{ Value = newValue };
            newNode.Previous = existingNode;
            newNode.Next = existingNode.Next;
            existingNode.Next.Previous = newNode;
            existingNode.Next = newNode;
        }
        public void AddBefore(LinkedListNode<T> existingNode, LinkedListNode<T> inputnewNode)
        {
            if (!Contains(existingNode)) throw new Exception("Passed Node Not Found !");
            Count++;
            LinkedListNode<T> newNode = new LinkedListNode<T>() {Value = inputnewNode.Value };
            newNode.Next = existingNode;
            newNode.Previous = existingNode.Previous;
            existingNode.Previous.Next = newNode;
            existingNode.Previous = newNode;
        }
        public void AddBefore(LinkedListNode<T> existingNode, T newValue)
        {
            if (!Contains(existingNode)) throw new Exception("Passed Node Not Found !");
            Count++;
            LinkedListNode<T> newNode = new LinkedListNode<T> { Value = newValue };
            newNode.Next = existingNode;
            newNode.Previous = existingNode.Previous;
            existingNode.Previous.Next = newNode;
            existingNode.Previous = newNode;
        }
        public void AddFirst(LinkedListNode<T> inputnewNode)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>() {Value = inputnewNode.Value };
            Count++;
            if (Head == null)
            {
                newNode.Previous = null;
                newNode.Next = null;
                Head = newNode;
                End = newNode;
            }
            else
            {
                newNode.Next = Head;
                newNode.Previous = null;
                Head.Previous = newNode;
                Head = newNode;
            }
        }
        public void AddFirst(T newValue)
        {
            Count++;
            if (Head == null)
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>
                {
                    Value = newValue,
                    Next = null,
                    Previous = null
                };
                Head = newNode;
                End = newNode;
            }
            else
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>
                {
                    Value = newValue,
                    Next = Head,
                    Previous = null
                };
                Head.Previous = newNode;
                Head = newNode;
            }
        }
        public void AddLast(LinkedListNode<T> inputnewNode)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>() {Value = inputnewNode.Value };
            Count++;
            if (Head == null)
            {
                newNode.Next = null;
                newNode.Previous = null;
                Head = newNode;
                End = newNode;
            }
            else
            {
                newNode.Previous = End;
                newNode.Next = null;
                End.Next = newNode;
                End = newNode;
            }
        }
        public void AddLast(T newValue)
        {
            Count++;
            if (Head == null)
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>
                {
                    Value = newValue,
                    Next = null,
                    Previous = null
                };
                Head = newNode;
                End = newNode;
            }
            else
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>
                {
                    Value = newValue,
                    Next = null,
                    Previous = End
                };
                End.Next = newNode;
                End = newNode;
            }
        }
        public void clear()
        {
            Head = null;
            Count = 0;
        }
        public bool Contains(T value)
        {
            LinkedListNode<T> temp = Head;
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                    return true;
                else
                    temp = temp.Next;
            }
            return false;
        }
        public bool Contains(LinkedListNode<T> value)
        {
            LinkedListNode<T> temp = Head;
            while(temp != null)
            {
                if (temp == value)
                    return true;
                else
                    temp = temp.Next;
            }
            return false;
        }
        public LinkedListNode<T> Find(T Value)
        {
            LinkedListNode<T> temp = Head;
            while (temp != null)
            {
                if (temp.Value.Equals(Value))
                    return temp;
                else
                    temp = temp.Next;
            }
            return null;
        }
        public LinkedListNode<T> FindLast(T Value)
        {
            LinkedListNode<T> temp = Head;
            LinkedListNode<T> res = null;
            while (temp != null)
            {
                if (temp.Value.Equals(Value))
                    res = temp;
                else
                    temp = temp.Next;
            }
            return res;
        }
        public void Remove(LinkedListNode<T> existingNode)
        {
            if (!Contains(existingNode)) throw new Exception("Passed Node Not Found !");
            if(Count == 0) throw new Exception("Linked List is Empty !");
            Count--;
            existingNode.Previous.Next = existingNode.Next;
            existingNode.Next.Previous = existingNode.Previous;
            existingNode = null;
        }
        public void Remove(T newValue)
        {
            var existingNode = Find(newValue);
            if (existingNode == null) throw new Exception("Passed value Not Found !");
            if (Count == 0) throw new Exception("Linked List is Empty !");
            Count--;
            existingNode.Previous.Next = existingNode.Next;
            existingNode.Next.Previous = existingNode.Previous;
            existingNode = null;
        }
        public void RemoveFirst()
        {
            if(Count == 0) throw new Exception("Linked List is Empty !");
            Count--;
            Head = Head.Next;
            if(Count != 0) Head.Previous = null;
            else Head = null;

        }
        public void RemoveLast()
        {
            if(Count == 0) throw new Exception("Linked List is Empty !");
            Count--;
            End = End.Previous;
            if (Count != 0) End.Next = null;
            else Head = null;
        }
        public static LinkedList<T> operator +(LinkedList<T> a, LinkedList<T> b)
        {
            LinkedList<T> res = new LinkedList<T>();
            var tmp = a.Head;
            while (tmp.Next != null)
            {
                res.Add(tmp);
                tmp = tmp.Next;
            }
            tmp = b.Head;
            while (tmp.Next != null)
            {
                res.Add(tmp);
                tmp = tmp.Next;
            }
            return res;
        }
        public static void Copy(LinkedList<T> dis, LinkedList<T> source)
        {
            var h = source.Head;
            if (h != null)
                do
                {
                    dis.Add(h);
                    h = h.Next;
                } 
                while (h != null);
        }
    }
}