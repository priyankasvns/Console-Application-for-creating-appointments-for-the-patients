using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Person
    {
        //encapsulating variables
        private string firstName;
        private string lastName;
        private string gender;
        private string birthDate;
        private string patientNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string PatientNumber { get => patientNumber; set => patientNumber = value; }

        public Person(string firstName, string lastName, string gender, string birthDate, string patientNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.PatientNumber = patientNumber;
        }

        public void Cleaning()
        {
            Console.WriteLine("The cleaning service was performed");
        }

        public void CavityFill()
        {
            Console.WriteLine("The CavityFill service was performed");
        }

        public void Checkup()
        {
            Console.WriteLine("The Checkup service was performed");
        }

        public void Xray()
        {
            Console.WriteLine("The Xray service was performed");
        }

        public virtual void SpecialService()
        {
            Console.WriteLine("The Special service was performed");
        }
    }
}
