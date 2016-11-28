using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncPractice
{
    public delegate int AddHandler(int a,int b);
    class AddClass
    {
        public static int Add(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
