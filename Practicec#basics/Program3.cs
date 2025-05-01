using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    class MyString
    {

        public string String { get; set; }


        public MyString(string str)
        {

            String = str;
        }
        public int GetLength()
        {
            return String.Length;
        }

        public int TotalVowels()
        {
            int ctr = 0;
            foreach (char c in String)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    ctr++;
                }
            }

            return ctr;
        }
        public int TotalWords()
        {
            int ctr = 0;
            bool inword = false;
            foreach (char c in String)
            {
                if(c!= ' ' &&  c != '\t')
                {
                    if(!inword) {
                        
                        ctr++;
                        inword = true;
                    }
                }
                else
                {
                    inword = false;
                }
            }

            return ctr;
        }
        public void LetterCount()
        {
             Dictionary<char,int> dict = new Dictionary<char,int>();
             foreach(char c in String)
            {
                if (c==' ')
                {
                    continue;
                }
                if (dict.ContainsKey(c))
                { 
                    dict[c]++; 
                }
                else
                {
                    dict[c] = 1;
                }
            }
            Console.WriteLine("\ndictionary\n");
            foreach (var item in dict)
            {
                Console.Write(item.Key+" : "+item.Value+"\t");
            }
             dict = dict.OrderByDescending(x => x.Value).ToDictionary();
            Console.WriteLine("\nsorted dictionary\n");
            foreach (var item in dict)
            {
                Console.Write(item.Key + " : " + item.Value + "\t");
            }

            Console.Write("\nFind Frequency of any character : ");
            while (true)
            {
                char ch = Console.ReadLine()[0];
                if (dict.ContainsKey(ch))
                {
                    Console.Write(ch + " : " + dict[ch]);
                }
                else
                {
                    Console.WriteLine(ch + " not found ");
                }
            }
           // int.TryParse(Console.ReadLine(), out int number);

        }

        public static string RemoveDuplicates(string str)
        {
            string temp = "";
            foreach(char c in str)
            {
                if (!temp.Contains(c))
                {
                    temp = temp + c;
                }
            }
            return temp;
        }
    }

    internal class Program3
    {
        public static void Main(string[] args)
        {
            
            while (true)
            { 
                 Console.WriteLine("enter string : ");
                string str = Console.ReadLine();
                //MyString mystr = new MyString(str);

                Console.WriteLine(MyString.RemoveDuplicates(str));
                //Console.WriteLine("Word : " + mystr.TotalWords());

            }
           
        }
        
       

    }
}
// MyString mystr = new MyString("Hello   World  Everyone");
//// MyString mystr = new MyString("    ");
// Console.WriteLine(mystr.ToString());
// Console.WriteLine(mystr.String);
// Console.WriteLine("Vowels : "+mystr.TotalVowels());
// Console.WriteLine("Size : "+mystr.GetLength());
// Console.WriteLine("Words : "+mystr.TotalWords());
// mystr.LetterCount();
// string str = "printed using extension method";
// str.PrintStringwithInfo(5);

// int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
// Func<int, int,int> aggreagtor = (a,b) => a +b;
// Predicate<int> CheckEvenodd = a =>
// {
//     if (a % 2 == 0)
//     {
//         return true;
//     }
//     return false;
// };
////int sum =  arr.Aggregate(aggreagtor);
//List<int> list = new List<int>();
// list.AddRange([87, 34, 88, 98, 7, 67, 56, 78, 5]);

//// Console.WriteLine(list.Find(CheckEvenodd));
//list.FindAll(CheckEvenodd).PrintList();