using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;        // Needed for File I/O

namespace Example___Simple_File_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File type *****\n");
            string[] myTasks = { "Schedule dentist appointment", "Call Chris", "Prepare for Superbowl 50" };


            // Write out all data to file on C drive.
            File.WriteAllLines(@"C:\Users\bschroeder\Desktop\tasks.txt", myTasks); // You can also call WriteAllBytes() or WriteAllText() here
            

            // Read it all back and print out.
            foreach (string task in File.ReadAllLines(@"C:\Users\bschroeder\Desktop\tasks.txt")) // You can also call ReadAllBytes() or ReadAllText() here
            {
                Console.WriteLine("TODO: {0}", task);
            }

            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
