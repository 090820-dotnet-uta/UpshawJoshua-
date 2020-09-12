using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human h1 = new Human(); //Human with default properties
            Human h2 = new Human("Jack", "Kinsey"); //Human with unique properties
            h1.AboutMe();
            h2.AboutMe();

            Human h3 = new Human("Joshua" , "Upshaw", "hazel"); //Setting eye color
            Human h4 = new Human("Billy", "Tamby", 34); //setting age
            Human h5 = new Human("Soap", "MacTavish", "green", 23); //setting everything
            h3.AboutMe();
            h4.AboutMe();
            h5.AboutMe();

            h5.Weight = 50; //valid weight
            h4.Weight =500; //invalid weight

        }
    }
}
