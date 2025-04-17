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
        private class Node
        {
            public int val;
            public Node next;
            public Node(int val = -1, Node next = null)
            {
                this.val = val;
                this.next = next;
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
    }

    class Executer
    {
        public static void Main(string[] args)
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