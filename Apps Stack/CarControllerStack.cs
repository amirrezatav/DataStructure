using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public class CarControllerStack
    {
        StackArray<int> AllCars;
        readonly int PrakingMaxSize;
        public int CarCount { get { return AllCars.FullSize; } }
        public CarControllerStack(int PrakingMaxSize)
        {
            AllCars = new StackArray<int>(PrakingMaxSize);
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
        public QueueArray<int> Check(int newcar)
        {
            if (AllCars.IsExist((int)newcar))
            {
                QueueArray<int> Exitcars = new QueueArray<int>((uint)PrakingMaxSize);
                StackArray<int> copy = new StackArray<int>(PrakingMaxSize);
                StackArray<int>.Copy(copy, AllCars);
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
                StackArray<int> Exitcars = new StackArray<int>(PrakingMaxSize);

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
        public StackArray<int> GetCarList()
        {
            StackArray<int> Exitcars = new StackArray<int>(PrakingMaxSize);
            StackArray<int>.Copy(Exitcars,AllCars);
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
