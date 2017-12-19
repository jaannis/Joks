using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Test1
    {
        public void SayHello()
        {
            string myName;
            myName = Console.ReadLine();
            Console.WriteLine("NOT hello world" + " " + myName);
        }

    }
}
