using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public class ColoredRingLinkedList
    {
        StackLinkedList<int>[] Rods;
        int RodsNum;
        int min;
        bool IsSelectMin = false;
        public int Length { get; set; }
        Table table;
        public ColoredRingLinkedList(int length = 15 , int number = 3)
        {
            if (number < 3) throw new Exception("Rods Must Be Greater than 2");
            RodsNum = number;
            this.Length = length;
            Rods = new StackLinkedList<int>[number];
            for (int i = 0; i < number; i++)
                Rods[i] = new StackLinkedList<int>();
            table = new Table(10 * number, ConsoleColor.DarkGray , ConsoleColor.White);
        }
        public void SetRod(int rodnum , params int[] inputs )
        {
            if (rodnum >= RodsNum) throw new Exception("rod number must less than " + RodsNum.ToString());
            if(inputs.Length != 0)
            {
                if(!IsSelectMin)
                {
                    min = inputs[0];
                    IsSelectMin = true;
                }
                foreach (var target in inputs)
                {
                    if (min > target)
                        min = target;
                    Rods[rodnum].Push(target);
                }
            }
        }
        void AddAllinLastRod()
        {
            for (int i = 0; i < RodsNum - 1; i++)
            {
                while (!Rods[i].IsEmpty())
                {
                    Rods[RodsNum-1].Push(Rods[i].Pop());
                }
            }
                
        }
        void Print(int step)
        {
            StackLinkedList<int>[] Rodscopy = new StackLinkedList<int>[RodsNum];
            for (int i = 0; i < RodsNum; i++)
                Rodscopy[i] = new StackLinkedList<int>();
            for (int i = 0; i < RodsNum; i++)
                StackLinkedList<int>.Copy(Rodscopy[i], Rods[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Step : " + step.ToString());
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            table.PrintLine();
            string[] title = new string[RodsNum];
            for (int j = 0; j < RodsNum; j++)
            {
                title[j] = "Rod " + j.ToString();
            }
            table.AddRow(title);
            table.PrintLine();
            int[] rStart = new int[RodsNum];
            for (int i = 0; i < RodsNum; i++)
                rStart[i] = Length - Rodscopy[i].FullSize - 1;
            
            for (int i = 0; i < Length; i++)
            {
                string[] row = new string[RodsNum];
                for (int j = 0; j < RodsNum; j++)
                {
                    row[j] = i <= rStart[j] ? "*" : Rodscopy[j].Pop().ToString();
                }
                table.AddRow(row);
            }
        }
        int step = 0;
        public void Ascending(int RodNumber)
        {
            if (RodNumber >= RodsNum) throw new Exception("rod number must less than " + RodNumber.ToString());
            Print(step++);
            AddAllinLastRod();
            Print(step++);
            while (Rods[RodsNum-1].Peek() != min)
                Rods[RodsNum - 2].Push(Rods[RodsNum - 1].Pop());
            Print(step++);
            Rods[0].Push(Rods[RodsNum - 1].Pop());
            while (Rods[0].FullSize != Length)
            {
                Print(step++);
                while (!Rods[RodsNum - 2].IsEmpty())
                {
                    if (Rods[RodsNum - 2].Peek() - Rods[0].Peek() == 1)
                        Rods[0].Push(Rods[RodsNum - 2].Pop());
                    else
                        Rods[RodsNum - 1].Push(Rods[RodsNum - 2].Pop());
                }
                Print(step++);
                while (!Rods[RodsNum - 1].IsEmpty())
                {
                    if (Rods[RodsNum - 1].Peek() - Rods[0].Peek() == 1)
                    {
                        Rods[0].Push(Rods[RodsNum - 1].Pop());
                    }
                    else
                        Rods[RodsNum - 2].Push(Rods[RodsNum - 1].Pop());
                }
            }
            Print(step++);
            if(RodNumber != 0)
            {
                if (RodNumber >= RodsNum) throw new Exception("rod number must less than " + RodNumber.ToString());
                if (RodNumber != 1)
                {
                    while (!Rods[0].IsEmpty())
                        Rods[1].Push(Rods[0].Pop());
                    while (!Rods[1].IsEmpty())
                        Rods[RodNumber].Push(Rods[1].Pop());
                }
                else
                {
                    while (!Rods[0].IsEmpty())
                        Rods[2].Push(Rods[0].Pop());
                    while (!Rods[2].IsEmpty())
                        Rods[1].Push(Rods[2].Pop());
                }
            }
            Print(step++);
        }
        public void Descending(int RodNumber)
        {
            if (RodNumber != 0)
            {
                Ascending(0);
                while (!Rods[0].IsEmpty())
                    Rods[RodNumber].Push(Rods[0].Pop());
                Print(step++);
            }
            else
            {
                Ascending(1);
                while (!Rods[1].IsEmpty())
                    Rods[RodNumber].Push(Rods[1].Pop());
                Print(step++);
            }
        }
    }
}
