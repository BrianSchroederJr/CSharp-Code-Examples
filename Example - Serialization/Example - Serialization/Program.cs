using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                                        // Needed for this example
using System.Runtime.Serialization.Formatters.Binary;   // Needed for this example
using System.Runtime.Serialization.Formatters.Soap;     // Needed for this example
using System.Xml.Serialization;

namespace Example___Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleSerializeToFile();
            SimpleSerialize();

            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SimpleSerialize()
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");

            // Make a JamesBondCar and set state.
            JamesBondCar jbCar = new JamesBondCar();
            jbCar.canFly = true;
            jbCar.canSubmerge = false;
            jbCar.theRadio.stationPresets = new double[] {89.3, 105.1, 97.1 };
            jbCar.theRadio.hasTweeters = true;

            // Now save the car to a specific file in a binary format.
            SaveAsBinaryFormat(jbCar, @"C:\Users\bschroeder\Desktop\CarData.dat");
            // Then load the car from the binary file.
            LoadFromBinaryFile(@"C:\Users\bschroeder\Desktop\CarData.dat");
            // Now save the car to a specific file in a soap format.
            SaveAsSoapFormat(jbCar, @"C:\Users\bschroeder\Desktop\CarDataSOAP.dat");
            // Then load the car from the SOAP file.
            LoadFromSOAPFile(@"C:\Users\bschroeder\Desktop\CarDataSOAP.dat");
            // Now save the car to a specific file in a xml format.
            SaveAsXmlFormat(jbCar, @"C:\Users\bschroeder\Desktop\CarDataXML.dat");
            // Then load the car from the XML file.
            LoadFromXmlFile(@"C:\Users\bschroeder\Desktop\CarDataXML.dat");
        }

        private static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in XML format.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }

        private static void LoadFromXmlFile(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));

            // Read the JamesBondCar from the XML file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)xmlFormat.Deserialize(fStream);
                Console.WriteLine("Does this car's radio have a Sub Woofer? : {0}", carFromDisk.theRadio.hasSubWoofers);
            }
            
        }

        private static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in SOAP format.
            SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in SOAP format!");
        }

        private static void LoadFromSOAPFile(string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();

            // Read the JamesBondCar from the SOAP file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)soapFormat.Deserialize(fStream);
                Console.WriteLine("Can this car submerge? : {0}", carFromDisk.canSubmerge);
            }
        }

        private static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Save object to a file named CarData.dat in binary format.
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!");
        }

        private static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly? : {0}", carFromDisk.canFly);
            }
        }



        private static void SimpleSerializeToFile()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Green";
            userData.FontSize = 42;

            // The BinaryFormatter persists state data in a binary format.
            // You would need to import System.Runtime.Serialization.Formatters.Binary
            // to gain access to BinaryFormatter.
            BinaryFormatter binFormat = new BinaryFormatter();

            // Store object in a local file.
            using (Stream fStream = new FileStream(@"C:\Users\bschroeder\Desktop\user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }
        }
    }


    // ADDITIONAL CLASSES

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;
    }
}
