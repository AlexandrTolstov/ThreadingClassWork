using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingClassWork
{
    class Program
    {
        public static bool done = false;
        static void Main(string[] args)
        {
            Exmpl08();
        }
        public static void Exmpl08()
        {
            Thread t = new Thread(Exmpl06_02);
            t.Start(true);
            Exmpl06_02(false);
        }
        public static void Exmpl06_02(object upperCase)
        {
            bool upper = (bool)upperCase;
            Console.WriteLine(upper?"HELLO":"hello");
        }

        public static void Exmpl07()
        {
            ThreadPool.QueueUserWorkItem(Exmpl06);
            var th1 = new Thread(Exmpl06);
            th1.Start();

            var th2 = new Thread(Exmpl06);
            th2.IsBackground = true;
            th2.Start();

            Thread.Sleep(500);
            Exmpl06(null);
        }
        public static Object obj = new Object();
        public static void Exmpl06(Object state)
        {
            lock (obj)
            {
                Console.Title = "Информация о главном потоке";

                Thread thread = Thread.CurrentThread;
                thread.Name = "MyThread";

                Console.WriteLine("Имя ДП: {0}", Thread.GetDomain().FriendlyName);
                Console.WriteLine("ID context: {0}", Thread.CurrentContext.ContextID);
                Console.WriteLine("Имя потока: {0}", thread.Name);
                Console.WriteLine("Запущен ли поток: {0}", thread.IsAlive);
                Console.WriteLine("Приоритет потока: {0}", thread.Priority);
                Console.WriteLine("Состояние потока: {0}\n", thread.ThreadState);

                Console.WriteLine("Manage ThreadId: {0}", thread.ManagedThreadId);
                Console.WriteLine("Background: {0}", thread.IsBackground);
                Console.WriteLine("Thread Pool: {0}", thread.IsThreadPoolThread);
                Console.WriteLine("---------------------------------------------------");
            }
        }

        public static void Exmpl04()
        {
            Program tt = new Program();
            new Thread(tt.Go).Start();
        }

        public static void Exmpl03()
        {
            new Thread(ThredProc).Start();
        }

        public static void Exmpl02()
        {
            Console.WriteLine("Main thread: Start a second thred");
            Thread t = new Thread(new ThreadStart(ThredProc));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread");
                Thread.Sleep(0);
            }
            Console.WriteLine("Main thread: Call Join(), to wait untill ThreadProc end");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has return. <Enter>");
            Console.ReadLine();
        }

        private static void Go2()
        {
            if (!done) { done = true; Console.WriteLine("DONE: {0}", Thread.CurrentThread.ManagedThreadId); }
        }

        private void Go()
        {
            if (!done) { done = true; Console.WriteLine("DONE: {0}", Thread.CurrentThread.Name); }
        }

        private static void ThredProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
            }
        }

        public static void Exmpl()
        {
            Thread t = new Thread(WriteY);
            t.Start();//Выполнить

            while (true)
                Console.Write(".");
        }

        private static void WriteY()
        {
            while (true)
                Console.Write("*");
        }
    }
}
