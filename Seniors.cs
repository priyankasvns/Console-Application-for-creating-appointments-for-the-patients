using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Seniors : Person
    {
        public Seniors(string firstName, string lastName, string gender, string birthDate, string patientNumber) : base(firstName, lastName, gender, birthDate, patientNumber)
        {

        }
        public override void SpecialService()
        {

            Console.WriteLine("The dentures fitting service was performed");
        }
        
    }
}
