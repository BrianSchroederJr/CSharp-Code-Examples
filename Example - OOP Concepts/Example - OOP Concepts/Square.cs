using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    class Square : IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Square");
        }

        public void Print()
        {
            Console.WriteLine("Printing Square");
        }
    }
}
