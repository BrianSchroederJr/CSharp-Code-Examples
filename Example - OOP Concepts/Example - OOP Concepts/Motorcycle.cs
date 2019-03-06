using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        // Constructor chaining example - C# 4.0+ Constructors can also use optional parameters to accomplish the below construct
        public Motorcycle() { }
        public Motorcycle(int intensity) : this(intensity, "Unknown") { }
        public Motorcycle(string name) : this(0, name) { }

        // This is the 'master' constructor that does all the real work.
        public Motorcycle(int intensity, string name)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }

    }
}
