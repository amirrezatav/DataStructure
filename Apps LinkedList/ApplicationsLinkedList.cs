using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    public class ApplicationLinkedList
    {
        bool readline, readkey;
        bool exit = false;
        public void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (!readline && !readkey)
            {
                UI.PrintError("<<<< You Can't exit , Try again Later !");
            }
            if (readkey)
            {
                exit = true;
                UI.PrintLineWarning("<<<< For Exit Press any key !");
            }
            e.Cancel = true;
        }
        string ReadNewLine()
        {
            readline = true;
            readkey = !readline;
            string res = Console.ReadLine();
            if (res == "yes" || res == null)
            {
                throw new ExecutionEngineException("13791213");
            }
            readline = false;
            readkey = false;
            return res;
        }
        ConsoleKey ReadNewKey()
        {
            readline = false;
            readkey = !readline;
            var res = Console.ReadKey().Key;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            if (exit)
            {
                exit = !exit;
                throw new ExecutionEngineException("13791213");
            }
            readline = false;
            readkey = false;
            return res;
        }
        void Parking(bool isTest = true)
        {
            Console.Clear();
            Console.Title = "Data Structure Projects - Parking - Amirreza Tavakoli";
            UI.PrintLineInformation("> For Exit Press CTRL+C");
            UI.PrintLineTitle(">> Parking : ");
            CarControllerLinkedList ParkingSys;
            int Max;
            Random rd = new Random();
            try
            {
                UI.PrintQuestion(">> Enter Maximum of Parking Size: ");
                Max = Convert.ToInt32(ReadNewLine());
                ParkingSys = new CarControllerLinkedList(Max);
            }
            catch (Exception ex)
            {
                if (ex.Message == "13791213")
                    return;
                UI.PrintLineError(ex.Message);
                Parking();
                return;
            }
            UI.PrintLineInformation(">> defualt Cars  :");
            for (int i = 0; i < Max / 4; i++)
            {
                int a = rd.Next(10000, 99999);
                ParkingSys.AddCar(a);
            }
            var def = ParkingSys.GetCarList();
            if (def.IsEmpty())
                UI.PrintLineError(">>>> Parking is Empty !");
            while (!def.IsEmpty())
                UI.PrintLineAnswer(def.Pop().ToString());
            while (true)
            {
                UI.PrintLineMenu(">> Choose  : (Enter 1,2,3,4,...)");
                UI.PrintLine(">>> 1. Add New Car");
                UI.PrintLine(">>> 2. See Cars List");
                UI.PrintLine(">>> 3. Delete a Car");
                UI.PrintLine(">>> 4. Full Count");
                UI.PrintLine(">>> 5. Remove All");
                UI.PrintLine(">>> 0. Exit");

                var Item = ReadNewKey();
                if (Item == ConsoleKey.D1 || Item == ConsoleKey.NumPad1)
                {
                    try
                    {
                        UI.PrintQuestion(">>>> Enter Number : ");
                        int num = Convert.ToInt32(ReadNewLine());
                        ParkingSys.AddCar(num);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "13791213")
                            return;
                        UI.PrintLineError(ex.Message);
                    }
                }
                else if (Item == ConsoleKey.D2 || Item == ConsoleKey.NumPad2)
                {
                    var all = ParkingSys.GetCarList();
                    if (all.IsEmpty())
                        UI.PrintLineError(">>>> Parking is Empty !");
                    while (!all.IsEmpty())
                        UI.PrintLine(">>>> " + all.Pop().ToString());
                }
                else if (Item == ConsoleKey.D3 || Item == ConsoleKey.NumPad3)
                {
                    try
                    {
                        {
                            UI.PrintQuestion(">>>> Enter Car Number :");
                            int id = Convert.ToInt32(ReadNewLine());
                            var res = ParkingSys.Check(id);
                            if (res != null)
                            {
                                UI.PrintLineInformation(">>>> This Cars Should Exit :");
                                while (!res.IsEmpty())
                                    UI.PrintLine(res.Dequeue().ToString());
                                UI.PrintWarning(">>>>> Are you sure for exiting ? press y (Yes) and n (No)");
                                while (true)
                                {
                                    var enter = ReadNewKey();
                                    if (enter == ConsoleKey.Y)
                                    {
                                        ParkingSys.RemoveCar((uint)id);
                                        UI.PrintLineSuccess(">>>>>> Delete Successful!");
                                        break;
                                    }
                                    else if (enter == ConsoleKey.N)
                                    {
                                        UI.PrintLineWarning(">>>>>> Ignore!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                UI.PrintLineError(">>>> Car Not Found!");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "13791213")
                            return;
                        UI.PrintLineError(ex.Message);

                    }
                }
                else if (Item == ConsoleKey.D4 || Item == ConsoleKey.NumPad4)
                {
                    UI.PrintQuestion(">>>> Full Count : ");
                    UI.PrintLineAnswer(ParkingSys.CarCount.ToString());
                }
                else if (Item == ConsoleKey.D5 || Item == ConsoleKey.NumPad5)
                {
                    UI.PrintLineWarning(">>>> Are you sure for Deleting All ? press y (Yes) and n (No)");
                    while (true)
                    {
                        try
                        {
                            var enter = ReadNewKey();
                            if (enter == ConsoleKey.Y)
                            {
                                ParkingSys.RemoveAllCars();
                                UI.PrintLineSuccess(">>>>> Delete Successful!");
                                break;
                            }
                            else if (enter == ConsoleKey.N)
                            {
                                UI.PrintLineWarning(">>>>> Ignore!");
                                break;
                            }
                        }
                        catch (Exception ex)
                        {

                            if (ex.Message == "13791213")
                                return;
                            UI.PrintLineError(ex.Message);
                        }

                    }
                }
                else if (Item == ConsoleKey.D0 || Item == ConsoleKey.NumPad0)
                {
                    return;
                }
                else UI.PrintLineError(">>> Try again ...");

            }
        }
        void ParenthesisApp()
        {
            Console.Clear();
            Console.Title = "Data Structure Projects - ParenthesisApp- Amirreza Tavakoli";
            UI.PrintLineInformation("> For Exit Press CTRL+C");
            UI.PrintLineTitle(">> Parenthesis : ");
            while (true)
            {
                try
                {
                    UI.PrintQuestion(">> Enter the phrase : ");
                    string input = ReadNewLine();
                    UI.PrintLineAnswer(">>> Result = " + ParenthesisStack.Set(input));
                }
                catch (Exception ex)
                {
                    if (ex.Message == "13791213")
                        return;
                    UI.PrintLineError(ex.Message);
                    ParenthesisApp();
                    return;
                }
            }
        }
        int[] StringArrayToIntArray(string [] collection)
        {
            collection = collection.Where(val => val != "").ToArray();

            int[] collectionInt = new int[collection.Length];
            for (int i = 0; i < collection.Length; i++)
                if(collection[i] != "")
                    collectionInt[i] = Convert.ToInt32(collection[i]);
            return collectionInt;
        }
        void ColoredRingFunc()
        {
            try
            {
            Console.Clear();
                Console.Title = "Data Structure Projects - Colored Ring- Amirreza Tavakoli";
                UI.PrintLineInformation("> For Exit Press CTRL+C");
                UI.PrintLineTitle(">> Colored Ring Select Item: ");
                UI.PrintLine(">>> 1. Auto Test : ");
                UI.PrintLine(">>> 2. Manual Test : ");
                var inputmode = ReadNewKey();
                UI.PrintLineTitle(">>>>  Select  : ");
                UI.PrintLine(">>>>> 1. Ascending : ");
                UI.PrintLine(">>>>> 2. Descending: ");
                UI.PrintLine(">>>>> 3. Back : ");
                if (inputmode == ConsoleKey.D1 || inputmode == ConsoleKey.NumPad1)
                {
                    inputmode = ReadNewKey();
                    while (true)
                    {
                        ColoredRingLinkedList coloredRing = new ColoredRingLinkedList();
                        coloredRing.SetRod(0 , 1, 4);
                        coloredRing.SetRod(1 , 2, 6, 11, 5, 3, 9, 12, 10);
                        coloredRing.SetRod(2 , 7, 15, 13, 8, 14);
                        if (inputmode == ConsoleKey.D1 || inputmode == ConsoleKey.NumPad1)
                        {
                            coloredRing.Ascending(3);
                            UI.PrintLineInformation(">>>>>> For Exit Press ESC");
                            while (true)
                                if (ReadNewKey() == ConsoleKey.Escape)
                                    return;
                        }
                        else if (inputmode == ConsoleKey.D2 || inputmode == ConsoleKey.NumPad2)
                        {
                            coloredRing.Descending(3);
                            UI.PrintLineInformation(">>>>>> For Exit Press ESC");
                            while (true)
                                if (ReadNewKey() == ConsoleKey.Escape)
                                    return;
                        }
                        else if (inputmode == ConsoleKey.D3 || inputmode == ConsoleKey.NumPad3)
                        {
                            break;
                        }
                    }

                }
                else if (inputmode == ConsoleKey.D2 || inputmode == ConsoleKey.NumPad2)
                {
                    inputmode = ReadNewKey();
                    while (true)
                    {
                        ColoredRingLinkedList coloredRing;
                        UI.PrintQuestion(">>>>>> Enter Number of Rods (greater than 3) : ");
                        int rods = Convert.ToInt32(ReadNewLine());
                        UI.PrintQuestion(">>>>>> Enter Number of loops : ");
                        int rings = Convert.ToInt32(ReadNewLine());
                        coloredRing = new ColoredRingLinkedList(rings , rods);
                        UI.PrintLineInformation(">>>>>> Separate Number With Space Then Press Enter for Skip Enter Space ");
                        int[][] reads = new int[rods][];
                        for (int j = 0; j < rods; j++)
                        {
                            UI.PrintQuestion(">>>>>> Enter  Numbers for Rod "+ j.ToString() + ": ");
                            reads[j] = StringArrayToIntArray(ReadNewLine().Split(' '));
                        }

                        int sum = 0;
                        for (int j = 0; j < rods; j++)
                        {
                            sum += reads[j].Length;
                        }
                 

                        if (sum == coloredRing.Length)
                        {
                            int[] readall = new int[coloredRing.Length];
                            int index = 0;
                            for (int j = 0; j < rods; j++)
                            {
                                reads[j].CopyTo(readall, index);
                                index += reads[j].Length;
                            }
                            Array.Sort(readall);
                            int i = readall[0];
                            bool Check = true;
                            foreach (var item in readall)
                            {
                                if (item != i++)
                                {
                                    Check = false;
                                }
                            }
                            if (Check)
                            {
                                for (int j = 0; j < rods; j++)
                                {
                                    if (reads[j].Length != 0)
                                        coloredRing.SetRod(j , reads[j]);
                                }
                                UI.PrintQuestion(">>>>>> In which bar to be placed ?");
                                int rodnum = Convert.ToInt32(ReadNewLine());
                                if (inputmode == ConsoleKey.D1 || inputmode == ConsoleKey.NumPad1)
                                {
                                    coloredRing.Ascending(rodnum);
                                    UI.PrintLineInformation(">>>>>> For Exit Press ESC");
                                    while (true)
                                        if (ReadNewKey() == ConsoleKey.Escape)
                                            return;
                                }
                                else if (inputmode == ConsoleKey.D2 || inputmode == ConsoleKey.NumPad2)
                                {
                                    coloredRing.Descending(rodnum);
                                    UI.PrintLineInformation(">>>>>> For Exit Press ESC");
                                    while (true)
                                        if (ReadNewKey() == ConsoleKey.Escape)
                                            return;
                                }
                                else if (inputmode == ConsoleKey.D3 || inputmode == ConsoleKey.NumPad3)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                UI.PrintLineError(">>>>>>> The number Is Not Sequential Try Again ...");
                            }
                        }


                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "13791213")
                    return;
                UI.PrintLineError(ex.Message);
                ColoredRingFunc();

            }
        }
        void JulietippusPrison()
        {
            try
            {
                var proc = new Process();
                proc.StartInfo.FileName = @"..\..\..\JulietippusPrison\bin\Debug\\JulietippusPrison.exe";
                proc.StartInfo.Arguments = "-l";
                proc.Start();
            }
            catch (Exception ex)
            {
                try
                {
                    var proc = new Process();
                    proc.StartInfo.FileName = @"JulietippusPrison.exe";
                    proc.StartInfo.Arguments = "-l";
                    proc.Start();
                }
                catch (Exception e)
                {
                    UI.PrintLineError("JulietippusPrison.exe Not Found !");
                    Run();
                }
            }
        }
        void AboutMe()
        {
            Console.Clear();
            Console.Title = "Data Structure Projects - About Amirreza Tavakoli";
            UI.PrintLineTitle("Data Structure Projects");
            UI.PrintWarning("Code and Alogrithm :");
            UI.PrintLineInformation("Amirreza Tavakoli");
            UI.PrintLineWarning("Student Number : 982164026");
            UI.PrintLineWarning("Email : AmirrezaTav2@gmail.com");
            UI.PrintLineWarning("Phone : +98 902 888 3854");
            UI.PrintLineWarning("Telegram : Amirrezatav");
            UI.PrintLineWarning("Instagram : Amirrezatav5");
            UI.PrintLineWarning("Twiter : Amirrezatav5");
            UI.PrintLineSuccess("Iran - Tehran");
            UI.PrintLineError(">>>>>> For Exit Press ESC");
            while (true)
                if (ReadNewKey() == ConsoleKey.Escape)
                    return;
        }
        public void Run()
        {
            Console.CancelKeyPress -= Console_CancelKeyPress;
            while (true)
            {
                Console.Clear();
                Console.Title = "Data Structure Projects - Amirreza Tavakoli";
                UI.PrintLineMenu("Choose  : (Enter 1,2,3,4)");
                UI.PrintLine("> 1. Parking");
                UI.PrintLine("> 2. Parenthesis");
                UI.PrintLine("> 3. ColoredRing");
                UI.PrintLine("> 4. Julietippus Prison");
                UI.PrintLine("> 5. About Me");
                UI.PrintLine("> 6. Back");

                try
                {
                    var Item = ReadNewKey();
                    Console.CancelKeyPress += Console_CancelKeyPress;
                    if (Item == ConsoleKey.D1 || Item == ConsoleKey.NumPad1)
                        Parking();
                    else if (Item == ConsoleKey.D2 || Item == ConsoleKey.NumPad2)
                        ParenthesisApp();
                    else if (Item == ConsoleKey.D3 || Item == ConsoleKey.NumPad3)
                        ColoredRingFunc();
                    else if (Item == ConsoleKey.D4 || Item == ConsoleKey.NumPad4)
                        JulietippusPrison();
                    else if (Item == ConsoleKey.D5 || Item == ConsoleKey.NumPad5)
                        AboutMe();
                    else if (Item == ConsoleKey.D6 || Item == ConsoleKey.NumPad6)
                        throw new Exception("0");

                }
                catch (Exception ex)
                {
                    if (ex.Message == "13791213")
                        Run();
                    if (ex.Message == "0")
                        throw new Exception("0");
                    UI.PrintLineError(ex.Message);
                    Run();
                }

            }
        }
    }
}
