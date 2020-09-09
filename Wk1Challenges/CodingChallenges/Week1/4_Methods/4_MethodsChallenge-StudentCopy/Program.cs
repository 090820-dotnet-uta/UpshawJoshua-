using System;
using System.IO;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");


        }

        public static string GetName()
        {
            string name;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            return name;
            throw new FormatException();
        }

        public static void GreetFriend(string name)
        {
            Console.WriteLine($"Hello {name}! You are my friend!");
           
        }

        public static double GetNumber()
        {
            double num;
            Console.WriteLine("Enter a number: ");
            string result = Console.ReadLine();     //Store input in temp variable for parsing 
            if(double.TryParse(result, out num))    //Check if the input can be turned into a double, return if true, error if not 
            {
                return num;
            }
            else
            {
                throw new FormatException();
            }
           
        }

        public static int GetAction()
        {
            int calcAction;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1)Add 2)Subtract 3)Multiply 4)Divide");
                string selection = Console.ReadLine();
                int.TryParse(selection, out calcAction);
                if (calcAction > 0 && calcAction < 5)
                {
                    return calcAction;
                }
                else
                {
                    continue;
                }
            } while (calcAction < 1 || calcAction > 4);
            return calcAction;
            //I don't know why but I get an error telling me "not all paths lead to return" if I don't include
            //this separate return statement. Works fine with it though. 
        }

        public static double DoAction(double x, double y, int z)
        {
            double result;
            if(z == 1)
            {
                return result = (x + y);
            }
            else if (z == 2)
            {
                return result = (x - y);
            }
            else if(z == 3)
            {
                return result = (x * y);
            }
            else if (z == 4)
            {
                if (y == 0)
                {
                    return result = (y / x);
                }
                return result = (x / y);
            }
            else
            {
                throw new FormatException();
            }
            
        }
    }
}
