using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicec_basics
{
    public delegate void PrinterDelegate(string str, int n);
    internal class Program2
    {
        public static void Printbefore(string str , int n)
        {
            Console.WriteLine(str + " needs to be printed " + n +" times");
        }

        public static void PrinterAfter(string str, int n)
        {
            Console.WriteLine(str + " has been  printed " + n + " times");
        }
        public static void PrintaLine()
        {
            Console.WriteLine("just print a line");
        }
        public static void PrintaLine(int a)
        {
            Console.WriteLine("just print value of  a : "+a);
        }
        public static void DoSomething(Action action)
        {
            Console.WriteLine("Before action");
            action(); // Invoke the passed-in method
            Console.WriteLine("After action");
        }
        public static void DoSomething(Action<int, int> action)
        {
            Console.WriteLine("Before action");
            action(5, 7); // Invoke the passed-in method
            Thread thread = new Thread(()=>PrintaLine(7));
            thread.Name = "my thread123";
           // thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("After action");
        }
        public static void DoSomething(Func<int, int,int> func)
        {
            Console.WriteLine("Before action");
            func(5, 7); // Invoke the passed-in method
            Thread thread = new Thread(() => PrintaLine(7));
            thread.Name = "my thread123";
            // thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("After action");
        }

        public static void DoSomething(PrinterDelegate p)
        {
            Console.WriteLine("Before action for printer delegates");
            p("akm", 7); // Invoke the passed-in method
            //Thread thread = new Thread(() => PrintaLine(7));
            //thread.Name = "my thread123";
            //// thread.IsBackground = true;
            //thread.Start();
            Console.WriteLine("After action");
        }
        public static void Main()
        {
            void f1()
            {
                Console.WriteLine("from f1");
            }
            Action act = () => Console.WriteLine("Hello from lambda");
             act += () => Console.WriteLine("Hello from lambda2");
            act += f1;
            Func<int, int, int> func2 = (a, b) =>
            {

                a = a + 5;
                b = b + 5;
                Console.WriteLine("sum : " + (a + b));
                return a + b;

            };
            DoSomething(act); 
            DoSomething(act);
            act -= f1;
            DoSomething(act);
            //DoSomething((a, b) => Console.WriteLine(a + b));
            //DoSomething(func2);

            PrinterDelegate printerDelegate = Printbefore;
            printerDelegate += PrinterAfter;
            DoSomething(printerDelegate);
            //printerDelegate("ayush", 9);

        }
    }
}
