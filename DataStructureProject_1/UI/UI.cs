using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject_1
{
    class UI
    {
        const ConsoleColor ErrorBackGround = ConsoleColor.Red;
        const ConsoleColor ErrorForeGround = ConsoleColor.Yellow;
        const ConsoleColor InformationBackGround = ConsoleColor.Blue;
        const ConsoleColor InformationForeGround = ConsoleColor.Black;
        const ConsoleColor QuestionBackGround = ConsoleColor.White;
        const ConsoleColor QuestionForeGround = ConsoleColor.Black;
        const ConsoleColor AnswerBackGround = ConsoleColor.Black;
        const ConsoleColor AnswerForeGround = ConsoleColor.White;
        const ConsoleColor WarningBackGround = ConsoleColor.Black;
        const ConsoleColor WarningForeGround = ConsoleColor.Yellow;
        const ConsoleColor TitleBackGround = ConsoleColor.Magenta;
        const ConsoleColor TitleForeGround = ConsoleColor.Black;
        const ConsoleColor MenuBackGround = ConsoleColor.DarkCyan;
        const ConsoleColor MenuForeGround = ConsoleColor.Black;
        const ConsoleColor SuccessBackGround = ConsoleColor.Green;
        const ConsoleColor SuccessForeGround = ConsoleColor.Black;

        public static void PrintLine(string meesage, ConsoleColor back = ConsoleColor.Black, ConsoleColor fore = ConsoleColor.White)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.WriteLine(meesage);
            Console.ResetColor();
        }
        public static void Print(string meesage, ConsoleColor back = ConsoleColor.Black, ConsoleColor fore = ConsoleColor.White)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.Write(meesage);
            Console.ResetColor();
        }
        public static void PrintLineError(string meesage)
        {
            PrintLine(meesage, ErrorBackGround, ErrorForeGround);
        }
        public static void PrintLineInformation(string meesage)
        {
            PrintLine(meesage, InformationBackGround, InformationForeGround);
        }
        public static void PrintLineQuestion(string meesage)
        {
            PrintLine(meesage, QuestionBackGround, QuestionForeGround);
        }
        public static void PrintLineAnswer(string meesage)
        {
            PrintLine(meesage, AnswerBackGround, AnswerForeGround);
        }
        public static void PrintLineWarning(string meesage)
        {
            PrintLine(meesage, WarningBackGround,WarningForeGround);
        }
        public static void PrintLineTitle(string meesage)
        {
            PrintLine(meesage, TitleBackGround,TitleForeGround);
        }
        public static void PrintLineMenu(string meesage)
        {
            PrintLine(meesage, MenuBackGround,MenuForeGround);
        }
        public static void PrintLineSuccess(string meesage)
        {
            PrintLine(meesage, SuccessBackGround,SuccessForeGround);
        }
        public static void PrintError(string meesage)
        {
            Print(meesage, ErrorBackGround,ErrorForeGround);
        }
        public static void PrintInformation(string meesage)
        {
            Print(meesage, InformationBackGround,InformationForeGround);
        }
        public static void PrintQuestion(string meesage)
        {
            Print(meesage, QuestionBackGround,QuestionForeGround);
        }
        public static void PrintAnswer(string meesage)
        {
            Print(meesage, AnswerBackGround,AnswerForeGround);
        }
        public static void PrintWarning(string meesage)
        {
            Print(meesage, WarningBackGround,WarningForeGround);
        }
        public static void PrintTitle(string meesage)
        {
            Print(meesage, TitleBackGround,TitleForeGround);
        }
        public static void PrintMenu(string meesage)
        {
            Print(meesage, MenuBackGround,MenuForeGround);
        }
        public static void PrintSuccess(string meesage)
        {
            Print(meesage, SuccessBackGround,SuccessForeGround);
        }

    }
}
