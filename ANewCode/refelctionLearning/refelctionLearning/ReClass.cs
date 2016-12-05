using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace refelctionLearning
{
    class ReClass
    {
        public string name;
        public string Name { get { return name; } set { name = value; } }
        public ReClass(int a)
        {
            Name = a.ToString();
        }
        public void show(int a)
        {
            Console.WriteLine("look me"+a +name);
        }
    }
}
