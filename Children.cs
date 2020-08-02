using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Children : Person
    {
        public Children(string firstName, string lastName, string gender, string birthDate, string patientNumber) : base(firstName, lastName, gender, birthDate, patientNumber)
        {

        }

        public override void SpecialService()
        {
            Console.WriteLine("The braces fitting service was performed");
        }
        
    }
}
