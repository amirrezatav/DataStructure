using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulietippusPrison
{
    /// <summary>
    ///  implement stack Using Array
    /// </summary>
    /// <typeparam name="T">The type of data that is stored in the stack</typeparam>
    public  class StackArray<T> : IStack<T>
    {
        T[] Buffer;
        readonly int BufferLen;
        // Point to the highest empty Array cell
        int Pointer;
        // return Stack Size
        public int Size {get { return BufferLen; }}
        // return Stack Empty Cells Number
        public int EmptySize { get { return (BufferLen - Pointer); } }
        // return Stack Full Cells Number
        public int FullSize { get { return Pointer; } }
        // this Constructor Get Stack Max Size 
        public StackArray(int stackSize)
        {
            BufferLen = ((stackSize != 0) ? stackSize : throw new Exception("Stack Size Can't be Ziro!"));
            Buffer = new T[BufferLen];
            Pointer = 0;
        }
        // return True if Pointer = 0
        public bool IsEmpty()
        {
            return Pointer == 0;
        }
        // return True if Pointer = Stack Last Cell
        public bool IsFull()
        {
            return Pointer == BufferLen;
        }
        // Adding elements in the Stack
        public void Push(T input)
        {
            Buffer[Pointer] = (!IsFull()) ? input : throw new OverflowException("Stack OverFlow!");
            Pointer++;
        }
        // removes the beginning element of the stack.
        public T Pop()
        {
            if(!IsEmpty())
            {
                Pointer--;
                T res = Buffer[Pointer];
                return res;
            }
            else
            {
                throw new OverflowException("Stack UnderFlow!");
            }
        }
        // returns the object at the beginning of the stack without removing it.
        public T Peek()
        {
            return (!IsEmpty()) ? Buffer[Pointer-1] : throw new Exception("Stack is Empty!");
        }
        //remove all the objects from the stack.
        public void Clear()
        {
            Buffer = new T[BufferLen];
            Pointer = 0;
        }
        public bool IsExist(T item)
        {
            foreach (var target in Buffer)
            {
                if (target.Equals(item))
                    return true;
            }
            return false;
        }
        public static StackArray<T> operator +(StackArray<T> a, StackArray<T> b) 
        {
            StackArray<T> res = new StackArray<T>(a.Size + b.Size);
            a.Buffer.CopyTo(res.Buffer, 0);
            b.Buffer.CopyTo(res.Buffer, a.Pointer);
            res.Pointer = a.Pointer + b.Pointer;
            return res;
        }
        public static void Copy(StackArray<T> dis, StackArray<T> source)
        {
            source.Buffer.CopyTo(dis.Buffer, 0);
            dis.Pointer = source.Pointer;
        }
    }
}
