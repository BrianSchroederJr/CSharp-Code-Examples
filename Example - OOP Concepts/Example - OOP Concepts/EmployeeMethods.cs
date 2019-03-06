using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    //EXAMPLE OF partial CLASS - SIMPLY A DESIGN SPLIT.  LIKE 1 CLASS TO THE COMPILER
    partial class Employee
    {
        // Methods. // Use properties in methods as well
        public void GiveBonus(float amount)
        {
            //currPay += amount;
            Pay += amount;
        }
        public void DisplayStats()
        {
            //Console.WriteLine("Name: {0}", empName);
            //Console.WriteLine("ID: {0}", empID);
            //Console.WriteLine("Pay: {0}", currPay);
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }

        //// Accessor (get method).     //USING PROPERTIES BELOW INSTEAD
        //public string GetName()
        //{
        //    return empName;
        //}
        //// Mutator (set method).
        //public void SetName(string name)
        //{
        //    // Do a check on incoming value
        //    // before making assignment.
        //    if (name.Length > 15)
        //        Console.WriteLine("Error! Name must be less than 16 characters!");
        //    else
        //        empName = name;
        //}

        // Properties!
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                else
                    empName = value;
            }
        }
        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public int Age { get; set; }    //Shorthand/Automatic version of basic property with no logic
    }
}
