using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Adults : Person
    {
        public Adults(string firstName, string lastName, string gender, string birthDate, string patientNumber) : base(firstName, lastName, gender, birthDate, patientNumber)
        {

        }
        public override void SpecialService()
        {
            Console.WriteLine("The veeners fitting service was performed");
        }
        
    }
}
