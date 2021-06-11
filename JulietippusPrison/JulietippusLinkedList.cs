using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace JulietippusPrison
{
   
    public partial class JulietippusLinkLiest
    {
        QueueLinkedList<Person> Corridor;
        QueueLinkedList<Person> GroundFloor;
        QueueLinkedList<Person> Yard;
        readonly int PrisonCapacity;
        public readonly int CorridorCapacity;
        readonly int JulietippusNumbers;
        Person[] People;
        public int FullSize = 0;
        bool isAdd = true;
        TimeSpan RecvTime = new TimeSpan(0, 0, 2);
        TimeSpan PowerTime = new TimeSpan(0, 0, 15);
        public DispatcherTimer RecvTimer;
        public DispatcherTimer PowerTimer;
        public bool Power = true;
        TimeSpan PwoerOffTime ;
        public JulietippusLinkLiest(int JulietippusNumbers , int PrisonCapacity , int CorridorCapacity  ,
            TimeSpan RecvTime  , TimeSpan PowerTime , TimeSpan PwoerOffTime , TimeSpan intervalFood)
        {
            if (RecvTime.TotalSeconds < 2)
                throw new Exception("RecvTime TotalSeconds grater than 2");
            if (PowerTime.TotalSeconds < 15)
                throw new Exception("PowerTime TotalSeconds grater than 15");
            if (PwoerOffTime.TotalSeconds < 1 || PwoerOffTime.TotalSeconds > 10)
                throw new Exception("PwoerOff Time TotalSeconds Between  1 and 10 ");
            if (intervalFood.TotalSeconds < 5)
                throw new Exception("PwoerOff Time TotalSeconds grater than 5 ");
            if (JulietippusNumbers<1 )
                throw new Exception("JulietippusDefualt Numbers must be grater than 1");
            if (PrisonCapacity < 5)
                throw new Exception("Prison Capacity must be grater than 5");
            if (CorridorCapacity < 2)
                throw new Exception("Corridor Capacity must be grater than 2");
            if (JulietippusNumbers > PrisonCapacity)
                throw new Exception("JulietippusNumbers must be less than PrisonCapacity");
            if (PrisonCapacity < CorridorCapacity)
                throw new Exception("GroundFloorCapacity must be less than PrisonCapacity");

            this.PrisonCapacity = PrisonCapacity;
            this.CorridorCapacity = CorridorCapacity;
            this.JulietippusNumbers = JulietippusNumbers;
            this.RecvTime = RecvTime;
            this.PowerTime = PowerTime;
            this.PwoerOffTime = PwoerOffTime;
            Person.Interval = intervalFood;

            Init();
            RegisterTimer();
            AddDefualt();
        }
        private void Init()
        {
            Corridor = new QueueLinkedList<Person>();
            GroundFloor = new QueueLinkedList<Person>();
            Yard = new QueueLinkedList<Person>();
            People = new Person[PrisonCapacity];
        }
        private void AddDefualt()
        {
            for (int i = 0; i < JulietippusNumbers; i++)
                Add_Person(i);
        }
        private void RegisterTimer()
        {
            RecvTimer = new DispatcherTimer();
            RecvTimer.Interval = RecvTime;
            RecvTimer.Tick += (sender, e) => { Handle_Corridor(); };

            PowerTimer = new DispatcherTimer();
            PowerTimer.Interval = PowerTime;
            PowerTimer.Tick += (sender, e) => { Power_Handle(); };

            PowerTimer.Start();
            RecvTimer.Start();
        }
        public void start()
        {
            for (int i = 0; i < FullSize; i++)
            {
                Thread.Sleep(2 * 1000);
                People[i].dispatcherTimer.Start();
            }
        }
        public void EnterPerson(int i)
        {
            Thread.Sleep(2 * 1000);
            People[i].dispatcherTimer.Start();
        }
        public bool Add_Person(int i)
        {
            if(isAdd)
            {
                try
                {
                    isAdd = false;
                    People[FullSize] = new Person(Handel_Yard);
                    People[FullSize].id = i;
                    People[FullSize].id = i;
                    lock (Yard)
                    {
                        Yard.Enqueue(People[FullSize]);
                    }
                    MainWindow.uy(People[FullSize], true);
                    FullSize++;
                    isAdd = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add Person Error", ex.Message , MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return isAdd;
            }
            else return isAdd;

        }
         void AddYard(Person ps)
        {
                try
                {
                    if(Yard.FullSize != PrisonCapacity)
                    {
                        lock (ps)
                        {
                        lock (Yard)
                            Yard.Enqueue(ps);
                        ps.dispatcherTimer.Start();
                        MainWindow.uy(ps, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add Yard", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
        bool AddCorridor(Person ps)
        {
            try
            {
                if (Corridor.FullSize != CorridorCapacity && Power)
                {
                    lock (Corridor)
                        Corridor.Enqueue(ps);
                    MainWindow.uc(ps);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Corridor", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        bool  AddGroundFloor(Person ps)
        {
            try
            {
                if (GroundFloor.FullSize != PrisonCapacity)
                {
                    lock (GroundFloor)
                        GroundFloor.Enqueue(ps);
                    MainWindow.ug(ps);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add GroundFloor", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        void DeleteFormYard(Person ps)
        {
            lock (Yard)
            {
                try
                {
                    if (!Yard.IsEmpty())
                    {
                        ps.dispatcherTimer.Stop();
                        QueueLinkedList<Person> temp = new QueueLinkedList<Person>();
                        while (ps != Yard.Peek() && !Yard.IsEmpty())
                            temp.Enqueue(Yard.Dequeue());
                        MainWindow.uy(Yard.Dequeue(), false);
                        while (!temp.IsEmpty())
                            Yard.Enqueue(temp.Dequeue());
                    }
                    else throw new Exception("Yard is Empty !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Form Yard", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        void DeleteFormCorridor(ref Person ps)
        {
            try
            {
                if (!Corridor.IsEmpty())
                {
                    lock (Corridor)
                        ps = Corridor.Dequeue();
                    MainWindow.uc(null);
                }
                else ps = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Form Corridor", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                ps = null;
            }
        }
        void DeleteFormGroundFloor(ref Person ps)
        {
            try
            {
                if (!GroundFloor.IsEmpty())
                {
                    lock (GroundFloor)
                        ps = GroundFloor.Dequeue();
                    MainWindow.ug(null);
                }
                else ps = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Form GroundFloor", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                ps = null;
            }
        }
        private void Handel_Yard(Person sender)
        {
            try
            {
                Person ps = (Person)sender;
                DeleteFormYard(ps);
                if (!AddCorridor(ps))
                    if (!AddGroundFloor(ps))
                        throw new Exception("Can't Delete From Yard!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Form Yard", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Handle_Corridor()
        {
            try
            {
                Person p = new Person(null);
                lock (p)
                {
                    DeleteFormCorridor(ref p);
                    if (p != null)
                        AddYard(p);
                }
                Handle_GroundFloorCapacity();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Handle Corridor", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Power_Handle()
        {
            Thread th = new Thread(new ThreadStart(()=> {
                try
                {
                    RecvTimer.Stop();
                    Power = false;
                    MainWindow.pw(true);
                    while (!Corridor.IsEmpty())
                    {
                        Person ps = new Person(null);
                        lock(ps)
                        {
                            DeleteFormCorridor(ref ps);
                            AddGroundFloor(ps);
                            Thread.Sleep(100);
                        }

                    }
                    Thread.Sleep(PwoerOffTime);
                    Power = true;
                    MainWindow.pw(false);
                    while (Corridor.FullSize != CorridorCapacity && !GroundFloor.IsEmpty())
                    {
                        Person ps = new Person(null);
                        lock(ps)
                        {
                            DeleteFormGroundFloor(ref ps);
                            AddCorridor(ps);
                            Thread.Sleep(100);
                        }
                    }
                    RecvTimer.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Power Handle", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }));
            th.IsBackground = true;
            th.ApartmentState = ApartmentState.STA;
            th.Start();
        }
        public void Handle_GroundFloorCapacity()
        {
            try
            {
                Person p = new Person(null);
                lock(p)
                {
                    DeleteFormGroundFloor(ref p);
                    if (p != null)
                        AddCorridor(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Handle GroundFloorCapacity", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
