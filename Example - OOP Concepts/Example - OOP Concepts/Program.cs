using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Example___OOP_Concepts
{
    class Program
    {


        // This delegate can point to any method,                               FOR SIMPLE DELEGATE EXAMPLE
        // taking two integers and returning an integer.
        public delegate int BinaryOp(int x, int y);


        // Main Program
        static void Main(string[] args)
        {
            Console.WriteLine("***** Exploring OOP Concepts *****");

            // Constructor Chaining Example
            ExploreConstructorChaining();

            ExploreEmployeeClass();

            ExploreMultipleInheritanceWithInterfaces();

            ExploreGenerics();

            ExploreGenericsSortedSet();

            ExploreObservableCollection();

            ExploreCustomGenericMethods();

            ExploreDelegates();

            ExploreCarDelegates();

            ExploreGenericDelegates();

            ExploreEvents();

            ExploreLambdaExpressions();

            int[] myIntArray = new int[]{};

            int i = AddUpIntArrayValues2(myIntArray);

            Console.Write("Answer is: {0}", i);

            // Quit console - wait for key press
            QuitConsole();
        }

        private static int AddUpIntArrayValues(int[] myIntArray)
        {
            int answer = 0;
            foreach (int i in myIntArray)
                answer += i;
            return answer;
        }

        private static int AddUpIntArrayValues2(int[] myIntArray)
        {
            int answer = 0;
            for (int i = 0; i < myIntArray.Length; i++)
                answer += myIntArray[i];
            return answer;
        }






        //METHODS

        private static void ExploreLambdaExpressions()
        {
            TraditionalDelegateSyntax();
            Console.WriteLine();
            AnonymousMethodSyntax();
            Console.WriteLine();
            LambdaExpressionSyntax();
            Console.WriteLine();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44});

            //// Call FinadAll() using traditional delegate syntax.
            Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("(Traditional Delegate) Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        private static bool IsEvenNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            //// Call FinadAll() using traditional delegate syntax.
            //Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            //List<int> evenNumbers = list.FindAll(callback);

            // Now, use an anonymouns method.
            List<int> evenNumbers = list.FindAll(delegate(int i)
                                                 { return (i % 2) == 0; });

            Console.WriteLine("(AnonymousMethod) Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            //// Call FinadAll() using traditional delegate syntax.
            //Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            //List<int> evenNumbers = list.FindAll(callback);

            // Now, use an anonymouns method.
            //List<int> evenNumbers = list.FindAll(delegate(int i)
            //                                     { return (i % 2) == 0; });

            // Now, use a C# LAMBDA EXPRESSION.
            List<int> evenNumbers = list.FindAll((i) => (i % 2) == 0);
            
            // Syntax with curly brackets
            //List<int> evenNumbers = list.FindAll((i) => { return (i % 2) == 0;});

            Console.WriteLine("(Lambda Expression) Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();

            // Build anon type using incoming args.
            var car = new { Make = "Ford", Color = "Blue", Speed = 65 };
            // Note you can now use this type to get the property data!
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
            // Anon types have custom implementations of each virtual
            // method of System.Object. For example:
            Console.WriteLine("ToString() == {0}", car.ToString());

            // Reflect over what the compiler generated.
            ReflectOverAnonymousType(car);

            unsafe
            {
                PrintValueAndAddress();
            }


        }

        unsafe static void PrintValueAndAddress()
        {
            int myInt;
            // Define an int pointer, and
            // assign it the address of myInt.
            int* ptrToMyInt = &myInt;

            // Assign value of myInt using pointer indirection.
            *ptrToMyInt = 123;
            // Print some stats.
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
            obj.GetType().Name,
            obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }



        private static void ExploreEvents()
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car2 c1 = new Car2("SlugBug", 100, 10);

            // Register event handlers.
            //c1.AboutToBlow += new Car2.CarEngineHandler(CarIsAlmostDoomed);
            //c1.AboutToBlow += new Car2.CarEngineHandler(CarAboutToBlow);

            // Register event handlers. -   Method Group Conversion syntax
            //c1.AboutToBlow += CarIsAlmostDoomed;

            // Using Anonymous Method pattern here - no need to define a method (CarIsAlmostDoomed) just for this event.
            c1.AboutToBlow += delegate(object sender, CarEventArgs e)   //Parameters are optional the () and args inside may be omitted if not needed.
                                {
                                    if (sender is Car2)
                                    {
                                        Car2 c = (Car2)sender;
                                        Console.WriteLine("=> Critical Message from {0}: {1}", c.PetName, e.msg);
                                    }
                                };
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            // Using Lambda Expression pattern here
            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };

            //Car2.CarEngineHandler d = new Car2.CarEngineHandler(CarExploded);
            //or - using Generic EventHandler
            //EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            //c1.Exploded += d;
            
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            // Remove CarExploded method
            // from invocation list.
            //c1.Exploded -= d;
            c1.Exploded -= CarExploded;

            // Fix car
            c1.FixCar();            //Created this myself
            c1.CurrentSpeed = 10;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

        }

        //public static void CarAboutToBlow(string msg)
        public static void CarAboutToBlow(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }

        //public static void CarIsAlmostDoomed(string msg)
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            if (sender is Car2)
            {
                Car2 c = (Car2)sender;
                Console.WriteLine("=> Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }     
        
        //public static void CarExploded(string msg)
        public static void CarExploded(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }



        private static void ExploreGenericDelegates()
        {
            Console.WriteLine("***** Fun with Action and Func *****");
            // Use the Action<> delegate to point to DisplayMessage.        NOTE: Action<> only works with methods that return void
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);

            // Use the Func<> delegate to point to Add and SumToString.     NOTE: The last type parameter is the return type.
            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        // This is a target for the Action<> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }



        private static void ExploreCarDelegates()
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            // First, make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);

            // Now, tell the car which method to call when it wants to send us messages.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            // This time, hold onto the delegate object,
            // so we can unregister later.
            //Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            //c1.RegisterWithCarEngine(handler2);
            // OR USE method group conversion C# SHORTCUT TO SIMPLY PASS IN THE METHOD NAME WITH NO DELEGATE INSTANCE
            c1.RegisterWithCarEngine(OnCarEngineEvent2);

            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            // Unregister from the second handler.
            //c1.UnRegisterWithCarEngine(handler2);
            c1.UnRegisterWithCarEngine(OnCarEngineEvent2);

            // Fix car
            c1.FixCar();            //Created this myself
            c1.CurrentSpeed = 10;

            // We won't see the "uppercase" message anymore!
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
        }

        // This is the target for incoming events.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}\n", msg.ToUpper());
        }



        private static void ExploreDelegates()
        {
            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            SimpleMath m = new SimpleMath();
            BinaryOp b = new BinaryOp(m.Add);
            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 + 10 is {0}", b(10, 10));
            Console.WriteLine();

            // Print the names of each member in the
            // delegate's invocation list.
            foreach (Delegate d in b.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }



        private static void ExploreCustomGenericMethods()
        {
            // Swap 2 ints.
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();

            // Swap 2 strings.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}!", s1, s2);
            MyGenericMethods.Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}!", s1, s2);

            Console.WriteLine();

            // the method does not take params.
            MyGenericMethods.DisplayBaseClass<int>();
            MyGenericMethods.DisplayBaseClass<string>();
        }



        private static void ExploreObservableCollection()
        {
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
            new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
            new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // Wire up the CollectionChanged event.
            people.CollectionChanged += people_CollectionChanged;           // This adds our custom event handler to the events called when the collection changes

            people.Add(new Person { FirstName = "Brian", LastName = "King", Age = 37 });    //Add someone to ObservableCollection
            people.Remove(people[0]);                                                       //Remove first item in the ObservableCollection
        }

        private static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Console.WriteLine("Action for this event: {0}", e.Action);
            // They removed something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
            // They added something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
        }



        private static void ExploreGenericsSortedSet()
        {
            //***************************************************************************************************
            // NOTE:    Interesting example of a class being created to implement interface functionality needed
            //          by the Generic Type - SortedSet.  Also, multiple classes can provide different sorts for
            //          the Person class.
            //***************************************************************************************************

            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByFirstName())// Sort by First Name  //(new SortPeopleByAge()) //Sort by Age
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            // Still sorted -Reverse
            foreach (Person p in setOfPeople.Reverse())
            {
                Console.WriteLine(p);
            }
        }



        private static void ExploreGenerics()
        {
            
            //***************************************************************************************************
            // NOTE:    Generics are much faster than the non-Generic equivilants.
            //          This is due to the fact that the non-Generic Types must box and unbox EVERY item.
            //***************************************************************************************************


            // Make a List of Person objects, filled with collection/object init syntax.
            List<Person> people = new List<Person>()
            {
                new Person{FirstName= "Doug", LastName="Smith", Age=47},
                new Person {FirstName= "Marge", LastName="Tyler", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9}
            };
            // Tradiational add syntax
            people.Add(new Person { FirstName = "Victor", LastName = "Lane", Age = 29 });           // Add to the end of the List

            // Print out # of items in List.
            Console.WriteLine("Items in list: {0}", people.Count);

            // Enumerate over list.
            foreach (Person p in people)
                Console.WriteLine(p);

            // Insert a new person.
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });   // Add to specified index in the List
            Console.WriteLine("Items in list: {0}", people.Count);

            // Copy data into a new array (For Example only - no real need to do this).
            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine("First Names: {0}", arrayOfPeople[i].FirstName);
            }
        }



        private static void ExploreMultipleInheritanceWithInterfaces()
        {
            Square s = new Square();
            Console.WriteLine("Square has {0} sides.", s.GetNumberOfSides());
            s.Draw();

            Console.WriteLine("");

            Triangle t = new Triangle();
            Console.WriteLine("Triangle has {0} sides.", t.GetNumberOfSides());

            IPrintable tp = (IPrintable)t;
            tp.Draw();                      // Call the explicitly defined IPrintable.Draw()
            IDrawable td = (IDrawable)t;
            td.Draw();                      // Call the explicitly defined IDrawable.Draw()
        }



        private static void ExploreEmployeeClass()
        {
            System.Console.WriteLine("***** Fun with Encapsulation *****\n");
            Employee emp = new Employee("Marvin", 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            // Use the get/set methods to interact with the object's name.
            //emp.SetName("Marv");
            //Console.WriteLine("Employee is named: {0}", emp.GetName());

            // Set and get the Name property. - Notice how the .NET property looks to the calling
            // code like it is setting field data directly but the get and set functions are being
            // called on the back end.
            emp.Name = "Marv";
            Console.WriteLine("Employee is named: {0}", emp.Name);
        }



        private static void ExploreConstructorChaining()
        {
            Motorcycle a = new Motorcycle(5);
            Motorcycle b = new Motorcycle("Dan");
            Motorcycle c = new Motorcycle(8, "Van");
            Motorcycle d = new Motorcycle();

            Console.WriteLine("{0} is riding with intensity {1}", a.driverName, a.driverIntensity);
            Console.WriteLine("{0} is riding with intensity {1}", b.driverName, b.driverIntensity);
            Console.WriteLine("{0} is riding with intensity {1}", c.driverName, c.driverIntensity);
            Console.WriteLine("{0} is riding with intensity {1}", d.driverName, d.driverIntensity);
        }



        private static void QuitConsole()
        {
            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }



    }
}
