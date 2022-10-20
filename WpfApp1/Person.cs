using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public Person(int iD, string firstName, string lastName, DateTime dOB)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DOB = dOB;
        }

        public override string ToString()
        {
            return $"[{ID}] {FirstName} {LastName} - ({DOB.Year})";
        }
    }

  
}
