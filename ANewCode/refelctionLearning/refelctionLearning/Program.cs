using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace refelctionLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            //string n = "worm";
            //Type t = n.GetType();
            //Console.WriteLine(t);
            //ReClass rc = new ReClass(1);
            //ConstructorInfo[] ci = rc.GetType().GetConstructors();
            //foreach (ConstructorInfo c in ci)
            //{
            //    ParameterInfo[] ps = c.GetParameters();
            //    foreach (ParameterInfo pi in ps)
            //    {
            //        Console.Write(pi.ParameterType.ToString() + pi.Name);
            //    }
            //    Console.WriteLine();
            //}

            ////用构造函数动态生成对象
            //Type re = typeof(ReClass);
            //Type[] pt = new Type[1];
            //pt[0] = typeof(int);
            //ConstructorInfo con = re.GetConstructor(pt);
            //object[] obj = new object[1] { 1 };
            //object o = con.Invoke(obj);
            //((ReClass)o).show(21);

            ////用Activator生成对象
            //Type t2=typeof(ReClass);
            //object[] obj2 = new object[1] { 212 };
            //object o2 = Activator.CreateInstance(t2,222);
            //((ReClass)o2).show(2121);

            ////查看类中的属性
            //ReClass re3 = new ReClass(12);
            //Type t3 = re3.GetType();
            //PropertyInfo[] pis = t.GetProperties();
            //foreach (PropertyInfo pi in pis)
            //{
            //    Console.WriteLine(pi.Name);
            //}

            ////查看类中的Public字段
            //ReClass re4 = new ReClass(12);
            //Type t4 = re4.GetType();
            //FieldInfo[] fis = t4.GetFields();
            //foreach (FieldInfo fi in fis)
            //{
            //    Console.WriteLine(fi.Name);
            //}

            //用反射生成对象，，并调用属性，方法，字段进行操作
            ReClass re5 = new ReClass(41);
            Type t5 = re5.GetType();
            object obj5 = Activator.CreateInstance(t5,911);//构造函数
            FieldInfo fi5 = t5.GetField("name");
            fi5.SetValue(obj5, "212");
            PropertyInfo pi5 = t5.GetProperty("Name");
            pi5.SetValue(obj5,"2name2121",null);//set方法
            MethodInfo mi = t5.GetMethod("show");
            object[] objj = new object[1] { 999 };//传入参数
            mi.Invoke(obj5,objj);//方法参数

            //Assembly ass = Assembly.Load("Huike.Core");
            Assembly ass = Assembly.LoadFrom("Huike.Core.dll");
            Type tc = ass.GetType("Huike.Core.Dao.BaseDao");
            Type[] tcs = ass.GetTypes();
            foreach (Type t in tcs)
            {
                Console.WriteLine(t);
            }
            Assembly reass = Assembly.LoadFrom("Huike.Core.dll");
            Type ret = reass.GetType("Huike.Core.Dao.BaseDao");
            object o = Activator.CreateInstance(ret);
            MethodInfo[] mire = ret.GetMethods();
            foreach (MethodInfo m in mire)
            {
                Console.WriteLine(m);
            }

            //通过dll文件全名反射其中的所有类型
            Assembly assembly = Assembly.LoadFrom("Huike.Core.dll");
            Type[] aa = assembly.GetTypes();
            foreach (Type t in aa)
            {
                if (t.FullName == "acas")
                {
                    object oo = Activator.CreateInstance(t);
                }
                
            }

            Console.ReadKey();
        }
    }
}
