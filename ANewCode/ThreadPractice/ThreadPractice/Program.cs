using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPractice
{
    public class Message
    {
        public void ShowMessage()
        {
            string message = string.Format("Async  is :{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
            for (int n = 0; n < 10; n++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The num" + n.ToString());
            }

        }
    }
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
    }
    public class MessageTwo
    {
        public void ShowMessage(object person)
        {
            if (person != null)
            {
                Person _person = (Person)person;
                string message = string.Format("\n{0}'s age is {1}!\nAsync threadId is:{2}", _person.Name, _person.Age, Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(message);
            }
            for (int n = 0; n < 10; n++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The number is:" + n.ToString());
            }
        }
    }
    public class MessageThree
    {
        public void ShowMessage()
        {
            string message = string.Format("\nAsync threadId is:{0}",
                                           Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
            for (int n = 0; n < 10; n++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The number is:" + n.ToString());
            }
        }
    }

    class Program
    {
        public static void AsyncOne()
        {
            Console.WriteLine("Main threadId is:" + Thread.CurrentThread.ManagedThreadId);

            Message message = new Message();
            Thread thread = new Thread(new ThreadStart(message.ShowMessage));
            thread.Start();
            //Thread thread = Thread.CurrentThread;
            //thread.Abort();
            thread.Name = "Main Thread";
            //string threadMessage = string.Format("Thread ID:{0}\n  Current AppDomainId:{1}"+"Current ContextId:{2}\n  Thread Name:{3}"+"Thread state:{4}\n    Thread Priority:{5}\n",thread.ManagedThreadId,Thread.GetDomainID(),Thread.CurrentContext.ContextID,thread.Name,thread.ThreadState,thread.Priority);
            //Console.WriteLine(threadMessage);
            Console.WriteLine("DO SOMEthing");
            Console.ReadKey();
        }
        public static void AsyncTwo()
        {
            Console.WriteLine("Main ThreadId is " + Thread.CurrentThread.ManagedThreadId);
            MessageTwo mT = new MessageTwo();
            Thread thread = new Thread(new ParameterizedThreadStart(mT.ShowMessage));
            Person p = new Person();
            p.Name = "Jack";
            p.Age = 21;
            thread.Start(p);
            Console.WriteLine("gogo faster");
        }
        public static void AsyncThree()
        {
            Console.WriteLine("Main threadId is:" + Thread.CurrentThread.ManagedThreadId);
            MessageThree message = new MessageThree();
            Thread thread = new Thread(new ThreadStart(message.ShowMessage));
            thread.IsBackground = true;
            thread.Start();

            Console.WriteLine("Do ada");
            thread.Join();
            Thread.Sleep(100);
            Console.ReadKey();
        }
        public static void AsyncPool()
        {
            ThreadPool.SetMaxThreads(1000, 1000);
            ThreadMessage("start");
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncPoolCallBack));
            Console.ReadKey();
        }
        public static void AsyncPoolCallBack(object state)
        {
            Thread.Sleep(200);
            ThreadMessage("AsyncCallBack");
            Console.WriteLine("async thread do work");
        }
        public static void ThreadMessage(string data)
        {
            string message = string.Format("{0}\n  CurrentThreadId is {1}",
                   data, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
        }
        //static void Main(string[] args)
        //{
        //    //AsyncOne();
        //    //AsyncTwo();
        //   // AsyncThree();
        //    AsyncPool();
        //}
    }
}
