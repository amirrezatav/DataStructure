using System;

namespace DataStructureProject_1
{
    public class ParenthesisLinkedList
    {
        private static string InsertParenthesis(string input)
        {
            return "(" + input + ")";
        }
        private static string SelectOperand(ref string input)
        {
            if ((input[0] == '.'))
                input = input.Insert(0, "0");
            if (!((input[0] >= '0' && input[0] <= '9')))
                throw new ArgumentNullException("Not Number");
            try
            {
                int i = 0;
                while ((input[i] >= '0' && input[i] <= '9') || (input[i] == '.')) i++;
                //double res = Convert.ToDouble(input.Substring(0,i));
                string res = input.Substring(0, i);
                input = input.Remove(0, i);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Operand Syntax Error !");
            } 
           
        }
        private static char SelectOperator(ref string input)
        {
            try
            {
                char res = Convert.ToChar(input.Substring(0, 1));
                input = input.Remove(0, 1);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Operator Syntax Error !");
            }
        }
        private static bool CheckPriority(StackLinkedList<char>  inputOperatorStack , char input)
        {
            StackLinkedList<char> OperatorStack = new StackLinkedList<char>();
            StackLinkedList<char>.Copy(OperatorStack, inputOperatorStack);
            if (input == ')')
                return true;
            if (input == '(' || input == '*' || input == '/')
                return false;
            if (input == '+' || input == '-')
            {
                while (!(OperatorStack.Peek() == '('))
                {
                    char temp = OperatorStack.Pop();
                    if (temp == '*' || temp == '/')
                        return true;
                }
                return false;
            }
            else
                throw new Exception("Operator Syntax Error !");
        }
        private static void SetParenthesis(ref StackLinkedList<string> OperandStack, ref StackLinkedList<char> OperatorStack)
        {
            while((OperatorStack.Peek()!='('))
            {
                string op2 = OperandStack.Pop();
                string op1 = OperandStack.Pop();
                char oper = OperatorStack.Pop();
                string temp = "(" + op1 + oper + op2 + ")";
                OperandStack.Push(temp);
            }
        }
        private static bool Validate(string input)
        {
            foreach (var target in input)
            {
                bool IsNumber = (target >= '0' && target <= '9')|| target == '.';
                bool IsOperand = target == '(' || target == ')' || target == '/' || target == '*' || target == '+' || target == '/' || target == '-';
                if (!IsNumber && !IsOperand)
                    return false;
            }
            return true;
        }
        public static string Set(string  input)
        {
            if(!Validate(input)) throw new Exception("Syntax Error !");
            string result;
            StackLinkedList<string> OperandStack = new StackLinkedList<string>();
            StackLinkedList<char> OperatorStack = new StackLinkedList<char>();
            input = InsertParenthesis(input);
            string operand = "";
            char Operator = '\0';
            while (input.Length != 0)
            {
                try
                {
                    operand = SelectOperand(ref input);
                    OperandStack.Push(operand);
                }
                catch (ArgumentNullException ex)
                {
                    Operator = SelectOperator(ref input);
                    if (CheckPriority(OperatorStack, Operator))
                        SetParenthesis(ref OperandStack, ref OperatorStack);
                    if (Operator != ')')
                        OperatorStack.Push(Operator);
                    else
                        OperatorStack.Pop();
                }
                
            }
            return OperandStack.Pop();
        }
    }
}
