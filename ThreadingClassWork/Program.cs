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
        static void Main(string[] args)
        {
            Exmpl02();
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
