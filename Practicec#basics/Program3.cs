using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicec_basics
{
    public static class ExtendString
    {
        public static void PrintStringwithInfo(this string s, int n)
        {
            while (n-- > 0)
            {
                Console.WriteLine("your string is : "+s+ " , length : "+ s.Length) ;
            }

        }
        public static void PrintList(this List<int> list) 
        { 
            foreach (int s in list) 
            { 
                Console.WriteLine(s);
            } 
        }
    }

    internal class Program3
    {
        public static void Main(string[] args)
        {
            string str = "printed using extension method";
            str.PrintStringwithInfo(5);

            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Func<int, int,int> aggreagtor = (a,b) => a +b;
            Predicate<int> CheckEvenodd = a =>
            {
                if (a % 2 == 0)
                {
                    return true;
                }
                return false;
            };
           //int sum =  arr.Aggregate(aggreagtor);
           List<int> list = new List<int>();
            list.AddRange([87, 34, 88, 98, 7, 67, 56, 78, 5]);
            
           // Console.WriteLine(list.Find(CheckEvenodd));
           list.FindAll(CheckEvenodd).PrintList();
        }
        
       

    }
}
