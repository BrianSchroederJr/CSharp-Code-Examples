using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    partial class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        //private int empAge;     //<- This field is not needed since an "Automatic" property was used for Age.



        // Constructors.
        public Employee() { }
        //public Employee(string name, int id, float pay)
        //{
        //    empName = name;
        //    empID = id;
        //    currPay = pay;
        //}

        // Using properties in a constructor insures that any business logic is called
        public Employee(string name, int id, float pay) : this(name, 0, id, pay) { }
        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        public override string ToString()
        {
            return string.Format("ID: {0} Name: {1} Pay: ${2}", empName, empID, currPay);
        }
       
    }
}
