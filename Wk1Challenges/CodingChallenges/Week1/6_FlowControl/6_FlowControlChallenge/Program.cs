using System;

namespace _6_FlowControl
{
    public class Program
    {
        //create global variables to hold users login data.
        public static string username;
        public static string password;
        

        static void Main(string[] args)
        {
            bool login = false;
            Register();
            //Use login bool to make sure that they enter the correct user and pass
            while(login != true)
            {
                login = Login();
            }
            int validTemperature = GetValidTemperature();
            GetTemperatureTernary(validTemperature);
            GiveActivityAdvice(validTemperature);
            
        }

        // This method gets a valid temperaturebetween -40 asnd 135 inclusive 
        // and returns the valid int.
        public static int GetValidTemperature()
        {
            
            int validTemp;
            int userTemp;
            do
            {
                string userInput;
                //Stay in loop till the input is an int 
                do 
                {
                    Console.WriteLine("What's the temperature?");
                    userInput = Console.ReadLine();
                    if(!int.TryParse(userInput, out userTemp))
                    {
                        Console.WriteLine("Not a valid temperature");
                        continue;
                    }
                    else {break;}
                }while(!int.TryParse(userInput, out userTemp)); //end first loop
                //After breaking, parse into our int variable 
                int.TryParse(userInput, out userTemp);
                //Check the amount of the int to make sure it is valid
                if(userTemp < -40 || userTemp > 130)
                {
                    Console.WriteLine("Not a valid temperature");
                    continue;
                }
                else
                {
                    validTemp = userTemp;
                    break;
                }
            }while(userTemp < -40 || userTemp > 130);
            //Once the userInt is truly a verified value, store it in validInt and return it
            validTemp = userTemp;
            return validTemp;
        }//End validtemp func

        // This method has one int parameter
        // It gives outdoor activity advice and temperature opinion based on 20 degree
        // increments starting at -20 and ending at 135 
        // n < -20 = hella cold
        // -20 <= n < 0 = pretty cold
        //  0 <= n < 20 = cold
        // 20 <= n < 40 = thawed out
        // 40 <= n < 60 = feels like Autumn
        // 60 <= n < 80 = perfect outdoor workout temperature
        // 80 <= n < 90 = niiice
        // 90 <= n < 100 = hella hot
        // 100 <= n < 135 = hottest
        public static void GiveActivityAdvice(int temp)
        {
            if(temp < -20)
            {
                Console.WriteLine("hella cold");
                return;
            }
            else if(-20 <= temp && temp < 0)
            {
                Console.WriteLine("pretty cold");
                return;
            }
            else if(0 <= temp && temp < 20)
            {
                Console.WriteLine("cold");
                return;
            }
             else if( 20 <= temp && temp < 40)
            {
                Console.WriteLine("thawed out");
                return;
            }
             else if(40 <= temp && temp < 60)
            {
                Console.WriteLine("feels like Autumn");
                return;
            }
             else if(60 <= temp && temp < 80)
            {
                Console.WriteLine("perfect outdoor workout temperature");
                return;
            }
             else if(80 <= temp && temp < 90)
            {
                Console.WriteLine("niiice");
                return;
            }
             else if(90 <= temp && temp < 100)
            {
                Console.WriteLine("hella hot");
                return;
            }
             else if(100 <= temp && temp < 135)
            {
                Console.WriteLine("hottest");
                return;
            }
        }

        // This method gets a username and password from the user
        // and stores that data in the global variables of the 
        // names in the method.
        public static void Register()
        {
            Console.WriteLine("Enter a valid username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter a valid password: ");
            password = Console.ReadLine();
            Console.WriteLine("saved your username and password");
        }

        // This method gets username and password from the user and
        // compares them with the username and password global variables
        // or the names provided. If the password and username match,
        // the method returns true. If they do not match, the user is 
        // prompted again for the username and password.
        public static bool Login()
        {
            string tempUsername, tempPass;
            Console.WriteLine("Please enter your username: ");
            tempUsername = Console.ReadLine();
            if(tempUsername != username)
            {
                return false;
            }
            Console.WriteLine("Please enter your password: ");

            tempPass = Console.ReadLine();
            if(tempPass != password)
            {
                return false;
            }
            return true;
        }

        // This method as one int parameter.
        // It chack is the int is <=42, between 
        // 43 and 78 inclusive, or > 78.
        // For each temperature range, a different 
        // advice is given. 
        public static void GetTemperatureTernary(int temp)
        {
            string tooCold = $"{temp} is too cold!";
            string justRight = $"{temp} is an ok temperature";
            string tooHot = $"{temp} is too hot";

            string msg = (temp<=42)? tooCold : (temp<=78)? justRight : tooHot;
            Console.WriteLine(msg);
            return;
        }
    }//end of Program()
}
