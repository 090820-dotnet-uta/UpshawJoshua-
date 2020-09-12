using System;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UseFor();
            UseDoWhile();
            UseWhile();
        }
        
        public static void UseFor()
        {
            for(int i = 0; i < 51; i++)
            {
                //If the remainder of i/2 is 1 then i must be odd
                if(i %  2 == 1 )
                {
                    Console.Write($" {i}, ");
                    i++;
                }
                else {continue;}
            }
            Console.WriteLine("\n");
        }

        public static void UseDoWhile()
        {
             int numCount = 0;
            do
            {
                if(numCount % 2 == 0)
                {
                    Console.Write($" {numCount}, ");
                    numCount++;
                }
                else if(numCount % 2 == 1)
                {
                    numCount++;
                    continue;
                }
                
            }while(numCount < 101);
            Console.WriteLine("\n");
        }

        public static void UseWhile()
        {
            int numCount = 0;
            while(numCount < 101)
            {
                if(numCount % 3 == 0)
                {
                    if(numCount % 5 == 0)
                    {
                        Console.WriteLine("skipping this number ");
                        numCount++;
                    }
                    else
                    {
                         Console.Write($" {numCount}, ");
                         numCount++;
                    }//end if-else 2
                }
                else{numCount++;}//end if-else 1
                if(numCount >= 101){break;} //break once we hit 100
            }//end of while
        }
    }
}
// 2. create a do/while loop that displays the even integers from 0 to 50.
// 3. create a while loop that displays the multiples of 3 integers from 0 to 100. 
//     1. Design the loop so that when every multiple of 3 and 5 coincide(like 15, 30, etc), you print "skipping this number" instead of the number.
//     2. Design the loop so that when you get above 100 you automatically stop the loop with a break statement.