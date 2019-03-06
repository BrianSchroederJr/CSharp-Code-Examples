using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___LINQ
{
    class Program
    {


        // Main Program
        static void Main(string[] args)
        {
            Console.WriteLine("***** Exploring LINQ *****");
            Console.WriteLine();
            LINQOverStrings();
            Console.WriteLine();
            LINQOverGenericCollections();
            Console.WriteLine();
            LINQOverNonGenericCollections();
            Console.WriteLine();
            LINQExpressions();
            Console.WriteLine();
            // Quit console - wait for key press
            QuitConsole();
        }



        //METHODS
        private static void LINQExpressions()
        {
            Console.WriteLine("***** LINQ Expressions *****\n");

            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
            };

            //SelectEverything(itemsInStock);
            //GetOverstock(itemsInStock);
            //GetNamesAndDescriptions(itemsInStock);

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o); // Calls ToString() on each anonymous object.
            }

        }

        static void SelectEverything(ProductInfo[] products)
        {
            // Get everything!
            Console.WriteLine("All product details:");

            var allProducts = from p in products select p;      //Similar to SELECT * in SQL

            foreach (var prod in allProducts)
            {
                //Console.WriteLine(prod.ToString());           //All details
                Console.WriteLine("Name: {0}", prod);           //Name only
            }
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");
            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }

        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };     //The "new" here creates a brand new data set
            foreach (var item in nameDesc)
            {
                // Could also use Name and Description properties directly.
                Console.WriteLine(item.ToString());
            }
        }

        // Return value is now an Array.
        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // Map set of anonymous objects to an Array object.
            return nameDesc.ToArray();
        }



        private static void LINQOverNonGenericCollections()
        {
            Console.WriteLine("***** LINQ over NonGeneric Collections (ArrayList) *****\n");

            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
                            
            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();

            //An example of .OfType being used to filter int objects from an ArrayList (which can contain different object types)
            /*
            static void OfTypeAsFilter()
            {
                // Extract the ints from the ArrayList.
                ArrayList myStuff = new ArrayList();
                myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
                var myInts = myStuff.OfType<int>();
                // Prints out 10, 400, and 8.
                foreach (int i in myInts)
                {
                    Console.WriteLine("Int value: {0}", i);
                }
            }
            */

            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }



        private static void LINQOverGenericCollections()
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "Toyota"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            GetFastBMWCars(myCars);
        }

        private static void GetFastBMWCars(List<Car> myCars)
        {
            // Find all BMW Car objects in the List<>, where the Speed is
            // greater than 55.
            var fastBMWs = from c in myCars where c.Speed > 55 && c.Make == "BMW" select c;

            foreach (var car in fastBMWs)
            {
                Console.WriteLine("BMW({0}) is going faster than 55 ({1})!", car.PetName, car.Speed);
            }
        }

        private static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<>, where the Speed is
            // greater than 55.
            var fastCars = from c in myCars where c.Speed > 55 select c;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going faster than 55 ({1})!", car.PetName, car.Speed);
            }
        }



        private static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Info about your query *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }



        private static void LINQOverStrings()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression to find the items in the array
            // that have an embedded space.
            //IEnumerable<string> subset = from gameTitle in currentVideoGames            // gameTitle can be any legal C# variable name (i.e. g, game, c, etc.)
            //                             where gameTitle.Contains(" ")
            //                             orderby gameTitle
            //                             select gameTitle;
            // Using Implicit typing
            var subset = from gameTitle in currentVideoGames            // gameTitle can be any legal C# variable name (i.e. g, game, c, etc.)
                                         where gameTitle.Contains(" ")  // Where title contains a single white space
                                         orderby gameTitle
                                         select gameTitle;

            // 

            // Print out the results
            //foreach (string s in subset)
            //    Console.WriteLine("Item: {0}", s);
            // Using Implicit typing
            foreach (var s in subset)
                Console.WriteLine("Item: {0}", s);

            ReflectOverQueryResults(subset);
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
