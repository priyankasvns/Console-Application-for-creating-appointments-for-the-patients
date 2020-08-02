using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PersonList
    {
        //
        List<Person> personList = null;

        public PersonList()
        {
            personList = new List<Person>();
        }

        public void Add(Person patient)
        {
            personList.Add(patient);
        }

        public int Count
        {
            get { return personList.Count; }
        }

        public Person this[int i]
        {
            get { return personList[i]; }
            set { personList[i] = value; }
        }

        //renamed this method to displayPatient list 
        //and also changed the signature from int i to int personListIndex
        public void displayPatients(int personListIndex)
        {
            Console.WriteLine("First Name: {0} ", personList[personListIndex].FirstName);
            Console.WriteLine("Last Name: {0} ",  personList[personListIndex].LastName);
            Console.WriteLine("Gender: {0}", personList[personListIndex].Gender);
            string[] birthDateFormatted = (personList[personListIndex].BirthDate).Split(' ');
            Console.WriteLine("Birth Date: {0}", birthDateFormatted[0]);
            var patientNumberFormatted = "XXX" + (personList[personListIndex].PatientNumber).Substring(3);
            Console.WriteLine("Patient Number: {0}", patientNumberFormatted);
        }

    }
}
