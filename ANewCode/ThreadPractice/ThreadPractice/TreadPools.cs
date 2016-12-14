using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ThreadPractice
{
    public class SomeState
    {
        public int Cookie;
        public SomeState(int iCookie)
        {
            Cookie = iCookie;
        }
    }
    public class Alpha
    {
        public Hashtable HashCount;
        public ManualResetEvent eventX;
        public static int iCount = 0;
        public static int iMaxCount = 0;
        public Alpha(int MaxCount)
        {
            HashCount = new Hashtable(MaxCount);
            iMaxCount = MaxCount;
        }
        public void Beta(Object state)
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode()+((SomeState)state).Cookie);
            Console.WriteLine("HashCount.Count=={0}, Thread.CurrentThread.GetHash Code()=={1}", HashCount.Count,
                Thread.CurrentThread.GetHashCode());
            lock (HashCount)
            {
                // 如果当前的 Hash 表中没有当前线程的 Hash 值，则添加之 
                if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
                    HashCount.Add(Thread.CurrentThread.GetHashCode(), 0);
                HashCount[Thread.CurrentThread.GetHashCode()] = ((int)HashCount[Thread.CurrentThread.GetHashCode()]) + 1;
            }

            Thread.Sleep(2000);

            if (iCount == iMaxCount)
            {
                Console.WriteLine();
                Console.WriteLine("setting eventX");
                eventX.Set();
            }
        }
    }
    public class TreadPools
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Thread Pool Sample:");
            bool W2K = false;
            int MaxCount = 10;
            ManualResetEvent eventX = new ManualResetEvent(false);
            Console.WriteLine("{0} items add to pool",MaxCount);
            Alpha oAlpha = new Alpha(MaxCount);
            oAlpha.eventX = eventX;
            Console.WriteLine("to pool o");
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta),new SomeState(0));
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("These API's may fail when called on a non-Wind ows 2000 system.");
                W2K = false;
            }
            if (W2K) // 如果当前系统支持 ThreadPool 的方法. 
            {
                for (int iItem = 1; iItem < MaxCount; iItem++)
                {
                    // 插入队列元素 
                    Console.WriteLine("Queue to Thread Pool {0}", iItem);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta), new SomeState(iItem));
                }
                Console.WriteLine("Waiting for Thread Pool to drain");

                // 等待事件的完成，即线程调用 ManualResetEvent.Set() 方法 
                eventX.WaitOne(Timeout.Infinite, true);

                // WaitOne() 方法使调用它的线程等待直到 eventX.Set() 方法被调用 
                Console.WriteLine("Thread Pool has been drained (Event fired)");
                Console.WriteLine();
                Console.WriteLine("Load across threads");
                foreach (object o in oAlpha.HashCount.Keys)
                {
                    Console.WriteLine("{0} {1}", o, oAlpha.HashCount[o]);
                }
            }
            Console.ReadLine();
        }
    }
}
