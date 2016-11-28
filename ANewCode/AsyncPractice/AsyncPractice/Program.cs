using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace AsyncPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("同步调用！");
            AddHandler handler = new AddHandler(AddClass.Add);
            int result = handler.Invoke(1, 2);
            Console.WriteLine(result);

            Console.WriteLine("异步调用！");
            //1 在类里面定义一个委托先。这里把Add方法注入进去
            AddHandler AsyncHandler = new AddHandler(AddClass.Add);
            //2 设置各种参数和回调函数与调用异步开始
            IAsyncResult asyncResult=AsyncHandler.BeginInvoke(1,2, new AsyncCallback(GetResult),"AsyncState:OK");
            Console.WriteLine("异步中做其他事!");
            //Console.WriteLine(AsyncHandler.EndInvoke(asyncResult));
           // Action<int,int> action = (e,c) => AddClass.Add(e,c);
           //Console.WriteLine( action.BeginInvoke( 1,2,ar =>{Console.WriteLine(action.EndInvoke( action.EndInvoke(ar)))}, null));
            Console.ReadKey();
        }
        //3 异步调用的回调函数，这里面对结果进行操作
        private static void GetResult(IAsyncResult result)
        {
            AddHandler handler=(AddHandler)((AsyncResult)result).AsyncDelegate;
            int i=handler.EndInvoke(result);// 获取到 原本函数的返回值
            Console.WriteLine(i);
           
        }
    }
}
