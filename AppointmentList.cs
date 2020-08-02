using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class AppointmentList
    {   
        //
        private List<Appointment> appointmentsList = null;

        public AppointmentList()
        {
            appointmentsList = new List<Appointment>();
        }

        //encapsulating collection i.e., by separating the 
        //Add, Remove functionality of the appointments into two functions
        public void Add(Appointment appointment)
        {
            appointmentsList.Add(appointment);
        }

        public void Clear()
        {
            appointmentsList.Clear();
        }

        public int Count
        {
            get { return appointmentsList.Count; }
        }

        public Appointment this[int i]
        {
            get { return appointmentsList[i]; }
            set { appointmentsList[i] = value; }
        }
    }
}
