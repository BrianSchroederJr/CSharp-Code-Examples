using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    class Triangle : IShape
    {
        public int GetNumberOfSides()
        {
            return 3;
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Drawing Triangle to printer");
        }

        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing Triangle to screen");
        }

        public void Print()
        {
            Console.WriteLine("Printing Triangle");
        }
    }
}
