﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulietippusPrison
{
    interface IStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
        bool IsFull();
        T Peek();
        void Clear();
        bool IsExist(T item);
        
    }
}
