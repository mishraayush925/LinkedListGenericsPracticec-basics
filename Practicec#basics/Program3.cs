using Practicec_basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practicec_basics
{
    enum E1
    {
        None = 0,
        first = 1,
        second = 2,
        third = 3,
        fourth = 4
    }

    public class Array2d
    {
          int _r, _c;
        public Array2d(int r, int c)
        {
            _r = r;
            _c = c;
            myArray =  new int[_r, _c];

        }
        int[,] myArray;

        public void BuildArray()
        {
            Console.WriteLine("Enter elements");
            for(int i=0;i< _r; i++)
            {
                for(int  j=0;j < _c; j++)
                {
                    int x;
                    string str = Console.ReadLine();
                    Int32.TryParse(str, out x);
                    myArray[i,j] = x;
                }
            }
        }
        public int[,] PrintArray()
        {
            for (int i = 0; i < _r; i++)
            {
                for (int j = 0; j < _c; j++)
                {
                    Console.Write(myArray[i,j]+" ");
                }
                Console.WriteLine("");
            }
            return myArray;
        }
        public int[,] GetArray()
        {
            return myArray;
        }
        public static int[] FlattenArray(int[,] array)
        {
            int[] res= new int[array.GetLength(0)*array.GetLength(1)];
            //int s = array.GetLength(0) * array.GetLength(1);
            int k = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    res[k++] = array[i,j];
                }
                //Console.WriteLine("");
            }
            return res;
        }

        public static int[] RotateByNth(int[] arr , int n , bool left=true)
        {
            if (n >= arr.Length)
            {
                throw new Exception("Array cannot be rotated");
            }
            else if(left) 
            {
                while (n-- > 0) 
                {
                    arr = ShiftLeft(arr);
                
                }
            }
            else if (!left)
            {
                //call shift right 
            }
                foreach (int i in arr)
                {
                    Console.WriteLine(i + " ");
                }
            return arr;
        }

        public static int[] ShiftLeft(int[] arr)
        {
            int temp = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //temp = arr[i];
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = temp;
            foreach (int i in arr)
            {
               // Console.WriteLine(i + " ");
            }
            return arr;
        }

        public static int[] ReverseFirstKElementsOfArray(int [] arr, int k=0)
        {
            if(k == 0)
            {
                k = arr.Length;
            }
            if(arr.Length < k)
            {
                throw new Exception("k should be less than array's size");
            }
            else
            {
                int temp = arr[0];
                for(int i=0;i<(arr.Length/2) - 1; i++)
                {
                    arr[i] = arr[k - i - 1];
                    arr[k - i - 1] = temp;
                    temp = arr[i + 1];
                }
            }
            foreach (int i in arr)
            {
                 Console.WriteLine(i + " ");
            }
            return arr;
        }
    }

    public class MyExceptions : Exception
    {
        public MyExceptions(string msg):base(msg) { }

        public override string Message
        {
            get
            {
                return "custom exception thrown ";
            }

        }

    }
    public class TestInbuiltExceptions
    {
       static  int[] x = { 1, 2, 3, 4, 5 };

        public static void A(int i)
        {
            B(i);
            Console.WriteLine("in A");

        }
        public static void B(int j)
        {
            C(j);
            Console.WriteLine("in B");

        }
        public static void C(int k)
        {
           // if (k > 10) throw new ArgumentOutOfRangeException();
           // Console.WriteLine(x[k]);
            try
            {

                if (k > 10) throw new ArgumentOutOfRangeException();
                Console.WriteLine(x[k]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("1st : "+e.Message);
            }
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("2nd : " + e.Message);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            Console.WriteLine("in C");

        }
    }
    public class IndexerDemo
    {
        string[] _str = new string[10];

        public string this[ int i] 
        {
            get
            {
                return _str[i];

            }
            set
            {
                _str[i] = value;
            }
        
        
        }

        public int CountWords(int i)
        {
            return this._str[i].Length * 2;
        }
        public static string ClassName { get; set; }
    }

    public class IndexerDemo2
    {
        int[] _lst = new int[100];

        public int this[int i]
        {
             get
            {
                return _lst[i];
            }
            set
            {
                _lst[i] = value;
            }
        }

        public void PrintIthElement(int i)
        {
            Console.WriteLine(_lst[i]);
        }
    }
    public static class ExtendInt
    {
        public static int Square(this int x)
        {
            return x * x;
        }
        public static int cube(this int x)
        {
            return x * x * x;
        }
    }
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
        public static void printObj(this object obj)
        {
            Console.WriteLine("Your obj : " + obj);
        }
        public static void printObjStr(this object obj)
        {
            Console.WriteLine("Your obj : " + obj);
        }

        public static int TrySquare(this string str)
        {
            int x = 0;
            if(Int32.TryParse(str,  out x))
            {
                Console.WriteLine("res : " + x * x);
                return x * x;
            }
            Console.WriteLine("Cannot be parsed");
            return 0;
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
           HashSet<char> uniq = new HashSet<char>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in str)
            {
                if (!uniq.Contains(c))
                {
                    uniq.Add(c);
                    stringBuilder.Append(c);
                }
            }
            
          

            return stringBuilder.ToString();
        }

        public static string RetainOnlylastOccurence(string str)
        {
            HashSet<char> uniq = new HashSet<char>();
            StringBuilder stringBuilder = new StringBuilder();
           
            for(int i = str.Length - 1; i >= 0; i--)
            {
                if (!uniq.Contains(str[i]))
                {
                    uniq.Add(str[i]);
                    stringBuilder.Insert(0, str[i]);
                }
            }


            return stringBuilder.ToString();
        }

        public static string ReverseStr(StringBuilder str)
        {
            char temp;
            for(int i = 0; i < str.Length/2; i++)
            {
                temp=str[i];
                str[i] = str[str.Length-1-i];
                str[str.Length - 1 - i]= temp;
            }
            return str.ToString();
        }

        public static bool CheckIfOnlyUniqChars(string str)
        {
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in str) 
            { 
                if (!chars.Contains(c))
                {
                    chars.Add(c);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    internal class Program3
    {
        public static void Main(string[] args)
        {


           Array2d array2D = new Array2d(4,2);

            array2D.BuildArray();
            array2D.PrintArray();
            // Array2d.RotateByNth(Array2d.FlattenArray(array2D.GetArray()),3);
            //Array2d.ShiftLeft(Array2d.FlattenArray(array2D.GetArray()));
            Array2d.ReverseFirstKElementsOfArray(Array2d.FlattenArray(array2D.GetArray()));


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


//while (true)
//{ 
//     Console.WriteLine("enter string : ");
//    string str = Console.ReadLine();
//    StringBuilder stringBuilder = new StringBuilder();
//    stringBuilder.Append(str);
//    //MyString mystr = new MyString(str);

//    //Console.WriteLine(MyString.RemoveDuplicates(str));
//    //Console.WriteLine(MyString.RetainOnlylastOccurence(str));
//    //Console.WriteLine(MyString.ReverseStr(stringBuilder));
//    Console.WriteLine(MyString.CheckIfOnlyUniqChars(str));
//    //Console.WriteLine("Word : " + mystr.TotalWords());

//}
//int x = 5;
//int y = 7;
//int z = 7.Square()+ 5.cube();
//object obj = x;
//string str1 = "55";
//string str2 = "ayush";
//obj.printObj();
//object obj2 = (object)y;
//Console.WriteLine(obj);
//obj.ToString();

//IndexerDemo indexerDemo = new IndexerDemo();
//indexerDemo[7] = "ayush";
//Console.WriteLine(indexerDemo.CountWords(7));
//indexerDemo[8] = "mishra";
//Console.WriteLine(indexerDemo.CountWords(8));
//IndexerDemo2 indexerDemo2 = new IndexerDemo2();
//for(int i = 0; i < 20; i++)
//{
//    indexerDemo2[i] = i * 1000;
//}
////for(int i = 0; i < 20; i++)
////{
////    // indexerDemo2.PrintIthElement(i);
////    E1 e;


////}

//// int x=  indexerDemo2[8];
//Array values = Enum.GetValues(typeof(E1));
//Array values2 = Enum.GetNames(typeof(E1));

//try
//{
//    TestInbuiltExceptions.A(5);
//}
//catch (Exception ex)
//{
//    Console.WriteLine("from main : "+ex.Message);
//}
//MyExceptions myExceptions = new MyExceptions("this msg");
//try
//{
//    string str = Console.ReadLine();
//    int x = 0;
//    if (Int32.TryParse(str, out x))
//    {
//        throw new MyExceptions("could be parsed sucessfully");
//    }
//    else
//    {
//        throw new MyExceptions("could not be parsed");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}