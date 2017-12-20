using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1 greet;
            greet = new Test1();
            greet.HelloText = "Hello world";
            greet.SayHello();

            Test1 seaGreet;
            seaGreet = new Test1();
            seaGreet.HelloText = "Ahoy world";
            seaGreet.SayHello();


            Console.ReadLine();
        }
    }
}
