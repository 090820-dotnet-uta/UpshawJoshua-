using Microsoft.VisualBasic;
using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //your code here
            //ex = example
            sbyte exSbyte = -100;
            Console.WriteLine(exSbyte);
            byte exByte = 18;
            Console.WriteLine(exByte);

            int exInt = 100;
            Console.WriteLine(exInt);
            uint exUint = 4200000000;
            Console.WriteLine(exUint);

            double exDouble = 56.778;
            Console.WriteLine(exDouble);
            float exFloat = -66.5322f;
            Console.WriteLine(exFloat);

            ushort exUshort = 54428;
            Console.WriteLine(exUshort);
            short exShort = -10323;
            Console.WriteLine(exShort);

            bool exBool = false;
            Console.WriteLine(exBool);
            char exChar = 'J';
            Console.WriteLine(exChar);

            string textString = "I control text";
            Console.WriteLine(textString);
            string textNum = "20";
            Console.WriteLine(textNum);

            Console.WriteLine($"String when converted to an Int: {Text2Num(textNum)}");
        }

        public static int Text2Num(string numText)
        {
            return int.Parse(numText);
            throw new NotImplementedException();
        }
    }
}
