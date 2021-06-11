using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStructureProject_1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_AddCar()
        {
            Random rd = new Random();
            int Max = 0;
            Max = 10;
            CarControllerStack carController = new CarControllerStack(Max);
            int[] arr = new int[Max];
            for (int i = 0; i < Max; i++)
            {
                int a = rd.Next(10000, 99999);
                carController.AddCar(a);
                arr[i] = a;
            }
            int ex = arr[rd.Next(0, 9)];
            QueueArray<int> Q = carController.Check(ex);
            for (int i = Max - 1; !Q.IsEmpty(); i--)
            {
                Assert.AreEqual<int>(arr[i], Q.Dequeue());
            }
        }
        /// <summary>
        /// Array Queue Test
        /// </summary>
        [TestMethod]
        public void TestMethod_ArrayQueue()
        {
            Random rd = new Random();
            uint Max = 10;
            int[] arr = new int[Max];
            QueueArray<int> ql = new QueueArray<int>(Max + 1);
            for (int i = 0; i < Max; i++)
            {
                int a = rd.Next(10000, 99999);
                ql.Enqueue(a);
                arr[i] = a;
            }
            Assert.AreEqual<int>(10, (int)ql.FullSize);
            Assert.AreEqual<bool>(false, ql.IsEmpty());
            for (uint i = 0; i < Max / 2; i++)
            {
                Assert.AreEqual<int>(arr[i], ql.Dequeue());
            }
            for (int i = 0; i < Max / 2; i++)
            {
                int a = rd.Next(10000, 99999);
                ql.Enqueue(a);
                arr[i] = a;
            }
            Assert.AreEqual<int>(10, (int)ql.FullSize);
            Assert.AreEqual<bool>(false, ql.IsEmpty());
            QueueArray<int> ql2 = new QueueArray<int>(ql.Size + 1);
            QueueArray<int>.Copy(ql2, ql);
            for (uint i = 0; i < Max; i++)
            {
                Assert.AreEqual<int>(ql2.Dequeue(), ql.Dequeue());
            }
            Assert.AreEqual<bool>(true, ql.IsEmpty());
        }
        /// <summary>
        /// LinkedList Queue
        /// </summary>
        [TestMethod]
        public void TestMethod_LinkedListQueue()
        {
            Random rd = new Random();
            uint Max = 10;
            int[] arr = new int[Max];
            QueueLinkedList<int> ql = new QueueLinkedList<int>();
            for (int i = 0; i < Max; i++)
            {
                int a = rd.Next(10000, 99999);
                ql.Enqueue(a);
                arr[i] = a;
            }
            Assert.AreEqual<int>(10, (int)ql.FullSize);
            Assert.AreEqual<bool>(false, ql.IsEmpty());
            for (uint i = 0; i < Max; i++)
            {
                Assert.AreEqual<int>(arr[i], ql.Dequeue());
            }
            Assert.AreEqual<bool>(true, ql.IsEmpty());
        }
        /// <summary>
        /// LinkedList Stack Test
        /// </summary>
        [TestMethod]
        public void TestMethod_LinkedListStack()
        {
            Random rd = new Random();
            uint Max = 10;
            int[] arr = new int[Max];
            StackLinkedList<int> ql = new StackLinkedList<int>();
            for (int i = 0; i < Max; i++)
            {
                int a = rd.Next(10000, 99999);
                ql.Push(a);
                arr[i] = a;
            }
            Assert.AreEqual<int>(10, (int)ql.FullSize);
            Assert.AreEqual<bool>(false, ql.IsEmpty());
            Assert.AreEqual<int>(arr[9], ql.Peek());
            for (int i = (int)Max - 1; i >= 0; i--)
            {
                Assert.AreEqual<int>(arr[i], ql.Pop());
            }

            Assert.AreEqual<bool>(true, ql.IsEmpty());
        }
        /// <summary>
        /// Array Stack 
        /// </summary>
        [TestMethod]
        public void TestMethod_ArrayStack()
        {
            Random rd = new Random();
            int Max = 10;
            int[] arr = new int[Max];
            StackArray<int> ql = new StackArray<int>(Max);
            for (int i = 0; i < Max; i++)
            {
                int a = rd.Next(10000, 99999);
                ql.Push(a);
                arr[i] = a;
            }
            Assert.AreEqual<int>(10, (int)ql.FullSize);
            Assert.AreEqual<bool>(false, ql.IsEmpty());
            Assert.AreEqual<int>(arr[9], ql.Peek());
            for (int i = (int)Max - 1; i >= 0; i--)
            {
                Assert.AreEqual<int>(arr[i], ql.Pop());
            }

            Assert.AreEqual<bool>(true, ql.IsEmpty());
        }
        /// <summary>
        /// Parenthesis
        /// </summary>
        [TestMethod]
        public void TestMethod_Parenthesis()
        {
            string input = ".2+3.5*6+7-9/3+(11*2)";
            string Realoutput = "(((0.2+(3.5*6))+(7-(9/3)))+(11*2))";
            string output = ParenthesisStack.Set(input);
            Assert.AreEqual(output, Realoutput);
        }
        
    }
}
