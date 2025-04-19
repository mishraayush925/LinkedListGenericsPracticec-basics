using System.Reflection.Metadata.Ecma335;

namespace Space1
{
    class User
    {
        private readonly int _id;

        public int Id { get { return _id; } }

        public DateTime Created { get;  }
            public User() {
            _id = 10;
            Created = DateTime.Now;
        }

    }

    class Vehicle
    {
        public virtual string VType
        {
            get => "Vehicles";
        }
    }

    class Car : Vehicle
    {
        public new string VType
        {
            get
            {
                Console.WriteLine("Overriding base : "+base.VType); // invokes base
                return "cars";
            }
        }
            
            

    }

    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Product(int x)
        {
            Price = x;
        }

        public static void  PrintParam(string name, int price)
        {
            Console.WriteLine(name);
            Console.WriteLine(price);
        }

        public static void PrintParam(string name)
        {
            Console.WriteLine(name);
          
        }
    }
    public class Person
    {
        public string Name;
        public int Age;

        public Person() : this("Unknown", 5)
        {
            Console.WriteLine("default called");
        } // Calls next constructor



        public Person(string name, int age)
        {
            Console.WriteLine("param called");
            Name = name;
            Age = age;
        }
    }

    //class Base
    //{
    //    public Base(int x)
    //    {
    //        Console.WriteLine("Base constructor : "+x);
    //    }
    //}

    //class Derived : Base
    //{
    //    public Derived(): base(5)
    //    {
    //        Console.WriteLine("Derived constructor");
            
    //    }
        
    //}

    class Base
    {
        static Base() => Console.WriteLine("Base static constructor");
        public Base() => Console.WriteLine("Base public constructor");
    }

    class Derived : Base
    {
        static Derived() => Console.WriteLine("Derived static constructor");
        public Derived() => Console.WriteLine("Derived public constructor");
    }

    // Test:
//linked list codes below
    class CustomLinkedList
    {
        public class Node
        {
            public int data { get; set; }
            public Node nextNode { get; set; }

            public Node(int data)
            {
                this.data = data;
                this.nextNode = null;
            }
        }

        private Node head;
        private int count;
        private Node tail;

        public int Count => count;

        public Node AddNode(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail= newNode;

            }
            else
            {
                tail.nextNode = newNode;
                tail=newNode;

            }
            count++;
            return head;
        }

        public void RemoveNode(int data)
        {
            Node node = head;
            bool found = false;
            while (node != null && node.nextNode!=null)
            {  
               
                if(node.nextNode.data.Equals(data))
                {
                    node.nextNode = node.nextNode.nextNode;
                    count--;
                    found = true;
                    break;
                }
                node = node.nextNode;
            }
            if (!found)
            {
                Console.WriteLine("No such item exists ");
            }
        }
        public void ShowNodes()
        {
            Node node = head;
            Console.WriteLine("shown by base version");
            while (node != null) { 
            Console.Write(node.data+ " " );
            node = node.nextNode;
            }
        }

        public void ShowNodes(Node head)
        {
            Node node = head;
            Console.WriteLine("shown by overloaded version");
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.nextNode;
            }
        }

        public void ReverseList()
        {
           // Node next = head.nextNode; ;
           if(head==null)
            {
                Console.WriteLine("list not found");
                return;
            }
            Node prev = null; //imaginary node 
            Node current = head;
           // head=head.nextNode;
            
            prev.nextNode = null;


            while (head != null)
            {
                head = head.nextNode;
                current.nextNode = prev;
                prev=current;
                current = head;

            }
            head = prev;
            //  tail.nextNode = node;


        }

       public static Node MergeLists(Node list1, Node list2)
        {
            Node current = null;
            if (list1 == null) return list2;
            if(list2 == null) return list1;
            if (list1.data < list2.data)
            {
                current = list1;
                list1=list1.nextNode;
            }
            else
            {
                current=list2;
                list2 = list2.nextNode; 
            }

            Node head = current;
                while (list1 != null && list2 != null)
                {
                    if (list1.data > list2.data)
                    {
                        current.nextNode = list1;
                        current = list1;
                        list1= list1.nextNode;
                    }
                else
                {
                    current.nextNode = list2;
                    current = list2;
                    list2 = list2.nextNode;

                }

                }
            if (list2 != null)
            {
                current.nextNode=list2;
            }
            else if(list1 != null)
            {
                current.nextNode = list1;
            }


                return head;
        }

    }

    public class ListNode
    {
        public int val;
     public ListNode next;
     public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
                 }
    }

    class MyLinkedList
    {
        public class ListInfo
        {
            public int Length;
            public Node Head;
            public Node Tail;
        }
        public class Node
        {
            public int val;
            public Node? next=null;
            public Node(int val = -1, Node next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                string str = "Value : "+val + " Next's value : " + next?.val;
                return str;
            }
        }

        int _nodeCount = 0;
        Node head = null;
        Node tail = null;

        public void AddNode(int val)
        {
            Node node = new Node(val);
            if (_nodeCount == 0)
            {
                head = tail = node;

            }
            else
            {

                tail.next = node;
                tail = tail.next;

            }
            _nodeCount++;
        }

        public ListInfo GetListInfo()
        {
            ListInfo info = new ListInfo();
            info.Length = _nodeCount;
            info.Head = head;

            info.Tail = tail;
            return info;
        }
        public void ShowList()
        {
            Node node = head;
            if (_nodeCount == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }
            while (node != null)
            {
                Console.Write(node.val + " ");
                node = node.next;
            }

        }

        public void Reverse() 
        {
            if (_nodeCount == 0)
            {
                Console.WriteLine("List is empty");
                return ;
            }
            Node current = head;
            Node prev = null;
            Node next = head;

            while (current != null)
            {
               
               //current.next = prev;
               // prev = current;
                next = next.next;
                current.next = prev;
                prev = current;

                current = next;
               // current.next = 

            }
            tail = head;
            tail.next = null;
            head = prev;

        }

        public static void ShowListRecusrive(Node node,int skip=0) //skip n elements
        {
            if (node == null)
                return;
            if(skip<=0)
            Console.Write(node.val + " , ");
            skip--;
            ShowListRecusrive(node.next,skip);

        }

        public void RemoveNode(int val)
        {
            if (_nodeCount < 0) 
            {
                Console.WriteLine("list empty");
                return;
            }
            Node current = head;
            Node prev = null;
            while (current != null)
            {
                if (val == head.val)
                {
                    head = head.next;
                    _nodeCount--;
                    Console.WriteLine("First Node removed");
                    return;
                }
                if (current.next == null && current.val !=val)
                {
                    
                    Console.WriteLine("item not found");
                    return;
                }
                if (current.next.val == val)
                {  
                    current.next = current.next.next;
                    _nodeCount--;
                    Console.WriteLine("node from list removed");
                    return;

                }
                current = current.next;
            }
            Console.WriteLine("Item not found");

        }

        public static Node MergeSortedLists(Node head1, Node head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;
            Node _head1= head1;
            Node _head2= head2;
            Node _current = null , start=null;
            if (head1.val > head2.val)
            {
                _current  = _head2;
              //  start = _current;
                _head2 = _head2.next;
            }
            else
            {
                _current  = _head1;
                _head1 = _head1.next;
                
            }
            start = _current;
            while (_head1!=null && _head2!=null)
            {
                //_current = _current.next;
                if (_head1.val > _head2.val)
                {
                    
                    _current.next = _head2;
                    _current = _current.next;
                    _head2 = _head2.next;
                }
                else
                {

                    _current.next = _head1;
                    _current = _current.next;
                    _head1 =_head1.next;
                }
            }
           // _current = _current.next;
            if (_head1 != null)
            { 
                _current.next = _head1;
            }
            else
            {
                _current.next = _head2;
            }
                return start;

        }

        public static string FindMaxMinSum(Node head)
        {
            string res= "";
            Node _head = head;
            int _max = head.val, _min = head.val;
            int sum = 0;
            while (_head != null)
            {
                if(_head.val > _max)
                {
                    _max = _head.val;
                }
                if(_head.val < _min)
                {
                    _min = _head.val;
                }
                sum += _head.val;
                _head = _head.next;
            }
            res = "max : " + _max + " min : " + _min + " sum : " + sum;


            return res;

        }

        public static Node SortList(Node head)
        {
            Node _head = head;
            Node _start = head;
            bool _sorted=false;
            while (_start != null &&_sorted==false)
            {
                 _sorted = true;
                while (_head != null)
                {
                    if (_head.val > _head.next?.val)
                    {
                        int temp = _head.val;
                        _head.val = _head.next.val;
                        _head.next.val = temp;
                        _sorted = false;
                        // _head = _head.next;
                    }
                    _head = _head.next;
                
                }
                _head = _start;
                //_start = _start.next;
            }
            return head;

        }
    }

    class Executer
    {
        public static void Main1(string[] args)
        {
            CustomLinkedList items = new CustomLinkedList();
            Console.Write("Nodes Count : ");
            int listLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nenter items :");
            while (listLength-- != 0)
            {
               int item = Convert.ToInt32(Console.ReadLine());
                items.AddNode(item);
            }

            var lastadded = items.AddNode(89);

           


            CustomLinkedList items2 = new CustomLinkedList  ();
            Console.Write("Nodes Count : ");
            int listLength2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nenter items :");
            CustomLinkedList.Node lastaddede2 = null;
            while (listLength2-- != 0)
            {
                int item = Convert.ToInt32(Console.ReadLine());
                lastaddede2=items2.AddNode(item);
            }
            Console.Write("Items are : ");
            items.ShowNodes();
            lastadded = items.AddNode(99);
            items.ShowNodes(lastadded);
            items2.ShowNodes();

            var x = CustomLinkedList.MergeLists(lastadded,lastaddede2);
            items2.ShowNodes(x);


        }

        public static void Main(string[] args)
        
        {
            Console.WriteLine("Linked list ");
            MyLinkedList items = new MyLinkedList();
           // MyLinkedList items2 = new MyLinkedList();
            Console.Write("Nodes Count : ");
            int listLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nenter items :");
            while (listLength-- != 0)
            {
                int item = Convert.ToInt32(Console.ReadLine());
                items.AddNode(item);
            }

            Console.Write("Nodes Count : ");
            //int listLength2 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("\nenter items :");
            //while (listLength2-- != 0)
            //{
            //    int item = Convert.ToInt32(Console.ReadLine());
            //    items2.AddNode(item);
            //}

            Console.Write("Items are : ");
            items.ShowList();
            Console.WriteLine("\nItems after sorting : ");
            MyLinkedList.ShowListRecusrive(MyLinkedList.SortList(items.GetListInfo().Head));
            //items2.ShowList();
            //Console.WriteLine("");
            //MyLinkedList.ShowListRecusrive(MyLinkedList.MergeSortedLists(items.GetListInfo().Head, items2.GetListInfo().Head));
            //Console.WriteLine("");
            //Console.Write(MyLinkedList.FindMaxMinSum(items.GetListInfo().Head));

            //Console.WriteLine("Length : " + items.GetListInfo().Length);
            //Console.WriteLine("Head : " + items.GetListInfo().Head.ToString());
            //Console.WriteLine("Tail : " + items.GetListInfo().Tail.ToString());
            ////Console.Write("Node value to remove: ");
            ////int val = Convert.ToInt32(Console.ReadLine());
            ////items.RemoveNode(val);
            //items.Reverse();
            //Console.Write("\nItems reversed : ");
            //items.ShowList();
            //Console.WriteLine("Length : " + items.GetListInfo().Length);
            //Console.WriteLine("Head : " + items.GetListInfo().Head.ToString());
            //Console.WriteLine("Tail : " + items.GetListInfo().Tail.ToString());
            //Console.Write("showing list using recursion : ");
            //MyLinkedList.ShowListRecusrive(items.GetListInfo().Head);
            //Console.WriteLine("\n");
            //MyLinkedList.ShowListRecusrive(items.GetListInfo().Head, 3); //skips first 2 elements 

        }
    }

}

//User user = new User();
//Console.WriteLine(user.Created + " " + user.Id);
//Car c = new Car();
//Vehicle v = new Car();

//Console.WriteLine(c.VType);
//Console.WriteLine(v.VType);
//Product product = new Product(200) { Name = "abc"};
//Product.PrintParam(product.Name, product.Price);
//Product.PrintParam(product.Name);
//Console.WriteLine(product.Name);
//Console.WriteLine(product.Price);

//Person person = new Person("ayush",100);
//Console.WriteLine(person.Name);
//Console.WriteLine(person.Age);
//  Derived d = new Derived(); 

// Console.Write("\nenter item to delete :");
//int data = Convert.ToInt32(Console.ReadLine());
//items.RemoveNode(data);
// items.ShowNodes();
//items.ReverseList();
//Console.Write("\nReversed List : ");
//items.ShowNodes();
