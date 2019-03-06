using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    class SortPeopleByFirstName : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return String.Compare(firstPerson.FirstName, secondPerson.FirstName);
        }
    }
}
