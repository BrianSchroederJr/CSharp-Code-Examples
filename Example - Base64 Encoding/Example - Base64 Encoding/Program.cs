using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___Base64_Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("--- Base 64 Example Encoding Program ---");
            System.Console.WriteLine("");



            //Start version I here
            System.Console.WriteLine("Base64 Encoding - Version 1  (Asking .NET the size of a char)");
            string origMsg = "My original message.";
            System.Console.WriteLine("Input String   : " + origMsg);

            //Create byte array
            byte[] binaryData = new byte[origMsg.Length * sizeof(char)];

            //Put chars from input string into byte array
            System.Buffer.BlockCopy(origMsg.ToCharArray(), 0, binaryData, 0, binaryData.Length);

            //Encode byte array to base64 string
            string base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
            System.Console.WriteLine("Base64 String  : " + base64String);


            //Create char array
            char[] charData = new char[binaryData.Length / sizeof(char)];

            //Put bytes into char array
            System.Buffer.BlockCopy(binaryData, 0, charData, 0, binaryData.Length);

            //Put char array into string
            string retMsg = new string(charData);
            System.Console.WriteLine("Output String  : " + retMsg);



            System.Console.WriteLine("");



            //Start version II here
            System.Console.WriteLine("Base64 Encoding - Version 2  (Specify and use .NET ASCII encoding)");
            string origMsg2 = "My original message.";
            System.Console.WriteLine("Input String 2 : " + origMsg2);

            //Create byte array and put chars from input string into byte array
            byte[] binaryData2 = System.Text.Encoding.ASCII.GetBytes(origMsg2);
            //byte[] binaryData2 = System.Text.Encoding.UTF8.GetBytes(origMsg2);    //This also works
            //byte[] binaryData2 = System.Text.Encoding.Unicode.GetBytes(origMsg2);    //This also works

            //Encode byte array to base64 string
            string base64String2 = System.Convert.ToBase64String(binaryData2, 0, binaryData2.Length);
            System.Console.WriteLine("Base64 String 2: " + base64String2);


            //Create char array and put bytes into char array
            char[] charData2 = System.Text.Encoding.ASCII.GetChars(binaryData2);
            //char[] charData2 = System.Text.Encoding.UTF8.GetChars(binaryData2);   //This also works
            //char[] charData2 = System.Text.Encoding.Unicode.GetChars(binaryData2);   //This also works

            //Put char array into string
            string retMsg2 = new string(charData2);
            System.Console.WriteLine("Output String 2: " + retMsg2);



            System.Console.WriteLine("");



            //Start version III here
            System.Console.WriteLine("Base64 Encoding - Version 3  (Specify and use .NET UTF8 encoding)");
            string origMsg3 = "My original message.";
            System.Console.WriteLine("Input String 3 : " + origMsg3);

            //Create byte array and put chars from input string into byte array
            //byte[] binaryData3 = System.Text.Encoding.ASCII.GetBytes(origMsg3);
            byte[] binaryData3 = System.Text.Encoding.UTF8.GetBytes(origMsg3);    //This also works
            //byte[] binaryData3 = System.Text.Encoding.Unicode.GetBytes(origMsg3);    //This also works

            //Encode byte array to base64 string
            string base64String3 = System.Convert.ToBase64String(binaryData3, 0, binaryData3.Length);
            System.Console.WriteLine("Base64 String 3: " + base64String3);


            //Create char array and put bytes into char array
            //char[] charData3 = System.Text.Encoding.ASCII.GetChars(binaryData3);
            char[] charData3 = System.Text.Encoding.UTF8.GetChars(binaryData3);   //This also works
            //char[] charData3 = System.Text.Encoding.Unicode.GetChars(binaryData3);   //This also works

            //Put char array into string
            string retMsg3 = new string(charData3);
            System.Console.WriteLine("Output String 3: " + retMsg3);



            System.Console.WriteLine("");



            //Start version IIIV here
            System.Console.WriteLine("Base64 Encoding - Version 4  (Specify and use .NET Unicode encoding)");
            string origMsg4 = "My original message.";
            System.Console.WriteLine("Input String 4 : " + origMsg4);

            //Create byte array and put chars from input string into byte array
            //byte[] binaryData4 = System.Text.Encoding.ASCII.GetBytes(origMsg4);
            //byte[] binaryData4 = System.Text.Encoding.UTF8.GetBytes(origMsg4);    //This also works
            byte[] binaryData4 = System.Text.Encoding.Unicode.GetBytes(origMsg4);    //This also works

            //Encode byte array to base64 string
            string base64String4 = System.Convert.ToBase64String(binaryData4, 0, binaryData4.Length);
            System.Console.WriteLine("Base64 String 4: " + base64String4);


            //Create char array and put bytes into char array
            //char[] charData4 = System.Text.Encoding.ASCII.GetChars(binaryData4);
            //char[] charData4 = System.Text.Encoding.UTF8.GetChars(binaryData4);   //This also works
            char[] charData4 = System.Text.Encoding.Unicode.GetChars(binaryData4);   //This also works

            //Put char array into string
            string retMsg4 = new string(charData4);
            System.Console.WriteLine("Output String 4: " + retMsg4);
            


            //Keep console open until a key is pressed:
            Console.ReadKey();
        }
    }
}
