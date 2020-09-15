using System;

namespace _5_OperatorsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int num1 = 5;
            int num2 = 3;
            bool test = false;

            Console.WriteLine("Result of Increment: " + Increment(num1));
            Console.WriteLine("Result of Decrement: " + Decrement(num1));
            Console.WriteLine($"Not {test} is " + Not(test));
            Console.WriteLine($"Negative {num1} is "+ Negate(num1));
            Console.WriteLine("Adding num1 to num2 is equal to "+ Sum(num1,num2));
            Console.WriteLine("Subtracting num2 from num1 is equal to: " + Diff(num1, num2));
            Console.WriteLine("Multiplying num1 and num2 is equal to "+ Product(num1,num2));
            Console.WriteLine("Dividing num1 by num2 is equal to " + Quotient(num1,num2));
            Console.WriteLine("Dividing num1 by num2 has a remainder of " + Remainder(num1,num2));
            Console.WriteLine("The statement: num1 is not equal to 0, and in fact it is greater than num2 is " + And(num1,num2));
            Console.WriteLine("The statement: num1 is equal to num2, or num1 is less than 0 is " + Or(num1,num2));
        }
        public static int Increment(int num) 
        { 
            return ++num;
            throw new NotImplementedException(); 
        }
        public static int Decrement(int num) 
        { 
            return --num;
            throw new NotImplementedException(); 
        }        
        public static bool Not(bool input) 
        { 
            if(input == false)
            {
                return input  = true;
            }
            else if(input == true)
            {
                return input = false;
            }
            else
            {
                throw new NotImplementedException(); 
            }
        }
        public static int Negate(int num)
        { 
            return num * -1;
            throw new NotImplementedException(); 
        }
        public static int Sum(int num1, int num2)
        { 
            int num3 = num1 + num2;
            return num3;
            throw new NotImplementedException(); 
        }
        public static int Diff(int num1, int num2)
        { 
            int num3 = num1 - num2;
            return num3;
            throw new NotImplementedException(); 
        }
        public static int Product(int num1, int num2)
        { 
            int num3 = num1*num2;
            return num3;
            throw new NotImplementedException(); 
        }
        public static int Quotient(int num1, int num2)
        { 
            if(num2==0)
            {
                int num3 = num2/num1;
                return num3;
            }
            else if(num2 != 0)
            {
                int num3 = num1/num2;
                return num3;
            }
            else
            {
                throw new NotImplementedException(); 
            }
           
        }
        public static int Remainder(int num1, int num2)
        { 
            int num3;
           if(num2==0)
            {
                Math.DivRem(num2, num1, out num3);
                return num3;
            }
            else if(num2 != 0)
            {
                Math.DivRem(num1, num2, out num3);
                return num3;
            }
            else
            {
                throw new NotImplementedException(); 
            } 
        }
        public static bool And(int num1, int num2)
        { 
            if(num1 != 0 && num1 > num2)
            {
                return true;
            }
            else if(num1 == 0 || num1 <= num2)
            {
                return false;
            }
            else
            {
                throw new NotImplementedException();
            }
             
        }
        public static bool Or(int num1, int num2)
        { 
            if(num1 == num2 || num1 < 0)
            {
                return true;
            }
            else if( num1 != num2 && num1 >= 0)
            {
                return false;
            }
            else
            {
                throw new NotImplementedException();
            }
             
        }
    }
}
