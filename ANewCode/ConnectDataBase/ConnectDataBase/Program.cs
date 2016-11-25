using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectDataBase
{
    class Program
    {
        //DbOprClass db = new DbOprClass();
        static void Main(string[] args)
        {
            
            DbOprClass db = new DbOprClass();
            if (db != null)
            {
                Console.WriteLine(db.GetData().Tables[0].Rows[0][0]);
            }
            
            Console.ReadKey();
        }
    }
}
