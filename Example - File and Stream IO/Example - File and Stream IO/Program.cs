using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            // Needed for these examples
using System.Text;          // Needed for these examples

namespace Example___File_and_Stream_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //UseFileStream();
            //UseStreamWriterReader();
            //UseStringWriterReader();    // Similar to StreamWriterReader except that you work with a block of character data in memory instead of file.
            UseBinaryWriterReader();

            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }


        private static void UseBinaryWriterReader()
        {
            Console.WriteLine("***** Fun with BinaryWriter / BinaryReader *****\n");

            // Open a binary writer for a file.
            FileInfo f = new FileInfo(@"C:\Users\bschroeder\Desktop\BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Print out the type of BaseStream. (System.IO.FileStream in this case.)
                Console.WriteLine("BaseStream is: {0}", bw.BaseStream);

                // Create some data to save in the file.
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A, B, C";

                // Write the data.
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            // Open a binary writer for the same file.
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.WriteLine("Binary writes & reads complete!");
        }


        private static void UseStringWriterReader()
        {
            Console.WriteLine("***** Fun with StringWriter / StringReader *****\n");

            // Create a StringWriter and emit character data to memory.
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump to console.
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);

                // Get the internal StringBuilder.
                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());

                // Read data from the StringWriter.
                using(StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
        }


        private static void UseStreamWriterReader()
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

            // Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText(@"C:\Users\bschroeder\Desktop\reminders.txt"))
            {
                writer.WriteLine("Don't forget birthdays...");
                writer.WriteLine("Don't forget other dates...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; i++)
                    writer.Write(i + " ");

                // Insert a new line.
                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Created reminders.txt file and wrote some data...");

            // Now read data from file.
            Console.WriteLine("Here are your reminders:\n");
            using (StreamReader reader = File.OpenText(@"C:\Users\bschroeder\Desktop\reminders.txt"))
            {
                string input = null;

                while ((input = reader.ReadLine()) != null)     // Read 1 line at a time from file (null means that the End Of File has been reached)
                {
                    Console.WriteLine(input);
                }
            }
        }


        private static void UseFileStream()
        {
            Console.WriteLine("***** Fun with FileStreams *****\n");

            // Obtain a FileStream object.
            using (FileStream fStream = File.Open(@"C:\Users\bschroeder\Desktop\myMessage.dat", FileMode.Create))
            {
                // Encode a string as an array of bytes.
                string msg = "Hello Matrix!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                // Write byte[] to file.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                // Reset internal position of stream. (This is necessary as the stream internal position is at the end of the stream after writing the stream to the file.)
                fStream.Position = 0;

                // Read the bytes from file and display to console.
                Console.Write("Your message as an array of bytes: \n");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length]; // Create a byte[] that equals the length of the message
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();    // Read 1 byte at a time from the file (stream position moves after each byte read to next byte position)
                    Console.WriteLine(bytesFromFile[i]);
                }

                // Display decoded message.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
        }
    }
}
