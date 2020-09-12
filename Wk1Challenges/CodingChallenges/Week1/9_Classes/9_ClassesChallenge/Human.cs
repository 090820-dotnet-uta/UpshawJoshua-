using System;

namespace _9_ClassesChallenge
{
    public class Human
    {
        public string firstName = "Pat";
        public string lastName = "Smyth";
        public string eyeColor;
        public int age;
        private int weight;

        public int Weight 
        { 
            get { return weight; }
            set
            {
                if(value < 400 && value > 0)
                    this.weight = value;
                else
                    throw new Exception("The weight of a Human must be between 0 and 400.");
            }
        }

        //default constructor is needed when you create a parameterized constructor.
        public Human() {}
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Human(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }
        public Human(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        //parameterized constructor
        public Human(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        public void AboutMe()
        {
            if(this.age == 0 && this.eyeColor == null)
                Console.WriteLine($"My name is {firstName} {lastName}.");
            else if(this.age == 0)
                Console.WriteLine($"My name is {firstName} {lastName}. My eye color is {this.eyeColor}.");
            else if (this.eyeColor == null)
                Console.WriteLine($"My name is {firstName} {lastName}. My age is {this.age}.");
            else
                Console.WriteLine($"My name is {firstName} {lastName}. My eye color is {this.eyeColor} and my age is {this.age}.");
        }

    }//end of class
}//end of namespace