using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___ConsoleApplication
{
    class Program
    {
        // Main
        static int Main(string[] args)
        {
            //DateTime dateValue = new DateTime(2014, 11, 24);
            //if((int)dateValue.DayOfWeek == 0)
            //Console.WriteLine((int)dateValue.DayOfWeek);
            

            // Plays a series of beeps
            PlayIntroSound();

            // Configure look of initial greeting
            ConfigureCUI();
           
            // Helper method within the Program class.
            ShowEnvironmentDetails();

            // Get User Data method
            GetUserData();

            // Format numbers in console writeline
            //FormatNumericalData();

            // LINQ example showing var being used for LINQ results
            //LinqQueryOverInts();
         
            // Dynamically discover values of enum
            EvaluateEnum(typeof(DayOfWeek));

            // Format number with commas
            //int num = 1000000;
            //Console.WriteLine(string.Format("{0:n0}", num));
            //Console.WriteLine(num.ToString("#,##0"));
            //Console.WriteLine(num.ToString("n0"));      //n gives commas, n# gives # decimal places (default is 2)

            // Wait for a key press before closing the console window
            QuitConsole();

            // Return an arbitrary error code.
            return -1;
        }

        //Methods

        private static void PlayIntroSound()
        {
            // Console tones for application start up
            Console.Beep(3000, 100);
            Console.Beep(3500, 100);
            Console.Beep(4000, 100);
            Console.Beep(4500, 100);
            Console.Beep(5000, 100);
        }

        private static void ConfigureCUI()
        {
            #region ConfigureCUI CDmethod
            // Set up Console UI (CUI)
            Console.Title = "My Console App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Welcome to My Console App *****");
            Console.WriteLine("*************************************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White; 
            #endregion
        }

        private static void ShowEnvironmentDetails()
        {
            // Output user name
            Console.WriteLine("Hello, {0}\\{1}", Environment.UserDomainName, Environment.UserName);
            // Print out the drives on this machine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive);
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }

        private static void GetUserData()
        {
            // Get name and age.
            Console.Write("Please enter your name (and then press Enter): ");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age (and then press Enter): ");
            string userAge = Console.ReadLine();
            // Change echo color, just for fun.
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Echo to the console.
            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);
            // Restore previous color.
            Console.ForegroundColor = prevColor;
        }

        // Now make use of some format tags.
        static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
        }

        // Using var for LINQ query - possibly the only appropriate time to use var
        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // LINQ query!
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            // Hmm...what type is subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }

        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Type e)
        {
            Console.WriteLine("=> Information about {0}", e.Name);
            Console.WriteLine("Underlying storage type: {0}",
            Enum.GetUnderlyingType(e));
            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e);
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                enumData.GetValue(i));
            }
            Console.WriteLine();
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
