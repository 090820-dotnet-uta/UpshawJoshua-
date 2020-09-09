using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //
            //
            //implement the required code here and within the methods below.
            //
            //
            string Message;
            int userNum;
            char searchChar;
            string fullName;
            string firstName;
            string lastName;

            Console.WriteLine("Please enter your message and press enter...");
            Message = Console.ReadLine();
           

            Console.WriteLine("Please enter a number LESS than the length of your string and press enter...");
            string string2 = Console.ReadLine();
            userNum = int.Parse(string2);
            Console.WriteLine($"Your substring is:   {Message.Substring(userNum)}");

            
            Console.WriteLine($"Your message in all UpperCase is...  {StringToUpper(Message)}");
            Console.WriteLine($"Your message in all lowercase is...  {StringToLower(Message)}");

            Console.WriteLine($"Let's trim your message...   {Message.Trim()}");

            Console.WriteLine("For which character should I search your initial message?");
            searchChar =  Console.ReadKey().KeyChar;
            //Console.WriteLine($" The input key is: {s}");
           
            Console.WriteLine($"We found the char here:   {SearchChar(Message, searchChar)}");
            

            Console.WriteLine("What is your first name?");
            firstName = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            lastName = Console.ReadLine();
            fullName = ConcatNames(firstName, lastName);
            Console.WriteLine($"Your full name is: {fullName}");

        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x)
        {
            return x.ToUpper();
            throw new NotImplementedException("StringToUpper method not implemented.");
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x)
        {
            return x.ToLower();
            throw new NotImplementedException("StringToUpper method not implemented.");

        }
        
        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x)
        {
            return x.Trim();
            throw new NotImplementedException("StringTrim method not implemented.");

        }
        
        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum)
        {
            return x.Substring(elementNum);
            throw new NotImplementedException("StringSubstring method not implemented.");

        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x)
        {
            return userInputString.IndexOf(x);
            throw new NotImplementedException("SearchChar method not implemented.");
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName)
        {
            string concatName;
            concatName = fName + " " + lName;
            return concatName;
            throw new NotImplementedException("ConcatNames method not implemented.");
        }



    }//end of program
}
