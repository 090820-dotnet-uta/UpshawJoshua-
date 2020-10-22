using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Calculator_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator
    {
        public double Add(double x, double y)
        {
            double z = x + y;
            Console.WriteLine($"In calculator service, received {x} and {y}.");
            Console.WriteLine($"{x} + {y} = {z}");
            return z;
            throw new NotImplementedException();
        }

        public double Divide(double x, double y)
        {
            double z;
            if(y==0)
            {
                z = y / x;
                Console.WriteLine($"In calculator service, received {x} and {y}.");
                Console.WriteLine($"{y} / {x} = {z}");
                return z = y / x;
            }
            else
            {
                z = y / x;
                Console.WriteLine($"In calculator service, received {x} and {y}.");
                Console.WriteLine($"{x} / {y} = {z}");
                return z = x / y;
            }
            throw new NotImplementedException();
        }

        public double Multiply(double x, double y)
        {
            double z = x*y;
            Console.WriteLine($"In calculator service, received {x} and {y}.");
            Console.WriteLine($"{x} / {y} = {z}");
            return z;
            throw new NotImplementedException();
        }

        public double Subtract(double x, double y)
        {
            double z = x - y;
            Console.WriteLine($"In calculator service, received {x} and {y}.");
            Console.WriteLine($"{x} - {y} = {z}");
            return z;
            throw new NotImplementedException();
        }
    }
}
