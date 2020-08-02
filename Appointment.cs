using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public delegate void Service();
    public class Appointment
    {
        private Person appointmentOfPerson;
        public Person AppointmentOfPerson { get => appointmentOfPerson; set => appointmentOfPerson = value;}
        
        private int appointmentNumber;

        public int AppointmentNumber { get => appointmentNumber; set => appointmentNumber = value;}


        private Service myService;
        public Service MyService { get => myService; set => myService = value; }

        
        public Appointment(Person person, Service patientService, int appointmentNumber)
        {
            this.AppointmentNumber = appointmentNumber;
            this.MyService = patientService;
            this.AppointmentOfPerson = person;
        }
    }
}
