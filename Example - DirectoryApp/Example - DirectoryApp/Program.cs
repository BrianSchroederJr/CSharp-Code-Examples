using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //ShowWindowsDirectoryInfo();
            ShowDrivesInfo();

            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowWindowsDirectoryInfo()
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            // Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");
        }

        static void ShowDrivesInfo()
        {
            Console.WriteLine("***** Fun with DriveInfo *****\n");

            // Get info regarding all drives.
            DriveInfo[] myDrives = DriveInfo.GetDrives();

            // Print drive stats.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);

                // If drive is mounted.
                if (d.IsReady)
                {
                    Console.WriteLine("Total Space: {0}", d.TotalSize);
                    Console.WriteLine("Free Space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
