using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public class CarControllerLinkedList
    {
        StackLinkedList<int> AllCars;
        readonly int PrakingMaxSize;
        public int CarCount { get { return AllCars.FullSize; } }
        public CarControllerLinkedList(int PrakingMaxSize)
        {
            AllCars = new StackLinkedList<int>();
            this.PrakingMaxSize = PrakingMaxSize;
        }
        public void AddCar(int newcar)
        {
            if (AllCars.IsExist(newcar)) throw new Exception("The car already exists");
            try
            {
                AllCars.Push(newcar);
            }
            catch
            {
                throw new Exception("Praking is Full");
            }
        }
        public QueueLinkedList<int> Check(int newcar)
        {
            if (AllCars.IsExist((int)newcar))
            {
                QueueLinkedList<int> Exitcars = new QueueLinkedList<int>();
                StackLinkedList<int> copy = new StackLinkedList<int>();
                StackLinkedList<int>.Copy(copy, AllCars);
                while (copy.Peek() != newcar)
                    Exitcars.Enqueue(copy.Pop());
                return Exitcars;
            }
            return null;
        }
        public void RemoveCar(uint newcar)
        {
            if (AllCars.IsExist((int)newcar))
            {
                StackLinkedList<int> Exitcars = new StackLinkedList<int>();

                while (AllCars.Peek() != newcar)
                    Exitcars.Push(AllCars.Pop());

                AllCars.Pop();


                while (!Exitcars.IsEmpty())
                    AllCars.Push(Exitcars.Pop());

                return ;
            }
            else
            {
                throw new Exception("Car Not Found!");
            }
        }
        public StackLinkedList<int> GetCarList()
        {
            StackLinkedList<int> Exitcars = new StackLinkedList<int>();
            StackLinkedList<int>.Copy(Exitcars,AllCars);
            return Exitcars;
        }
        public void RemoveAllCars()
        {
            try
            {
                while (true)
                    AllCars.Pop();
            }
            catch (Exception ex)
            {
                // ignore
            }
        }
    }
}
