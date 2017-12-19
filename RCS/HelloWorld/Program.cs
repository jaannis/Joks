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
            greet.SayHello();
            Console.ReadLine();
        }
    }
}
