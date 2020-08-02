using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        { 
            AppointmentList appointmentList = new AppointmentList();

            int selection = 0;

            PersonList peopleList = new PersonList();

            Person person1 = new Adults("Priyanka", "Siriki", "Female", "22/1/1993", "1234567891");
            Person person2 = new Seniors("Riya", "Adode", "Female", "24/10/1943", "1234567892");
            Person person3 = new Adults("barry", "Max", "Male", "19/11/1995", "1234567893");
            Person person4 = new Children("Rani", "Devi", "Female", "5/1/2003", "1234567894");
            Person person5 = new Children("Raj", "Kumar", "Male", "2/10/2006", "1234567895");
            Person person6 = new Adults("Ali", "Reza", "Male", "9/12/1994", "1234567896");
            Person person7 = new Seniors("Ravi", "Adode", "Male", "3/12/1942", "1234567897");
            Person person8 = new Adults("Seema", "Patel", "Female", "28/3/1992", "1234567898");
            Person person9 = new Children("Neema", "Ahuja", "Female", "10/4/2004", "1234567899");
            Person person10 = new Seniors("teddy", "Singh", "Male", "05/11/1946", "1234567810");

            peopleList.Add(person1);
            peopleList.Add(person2);
            peopleList.Add(person3);
            peopleList.Add(person4);
            peopleList.Add(person5);
            peopleList.Add(person6);
            peopleList.Add(person7);
            peopleList.Add(person8);
            peopleList.Add(person9);
            peopleList.Add(person10);
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Display patients' details.");
                Console.WriteLine("2. Create a Schedule.");
                Console.WriteLine("3. Display the day's Schedule.");
                Console.WriteLine("4. Exit");
                Console.WriteLine("------------------------------");
                try
                {
                    selection = int.Parse(Console.ReadLine());
                    if (selection == 1 || selection == 2 || selection == 3 || selection == 4)
                    {
                        if (selection == 1)
                        {
                            for (int i = 0; i < peopleList.Count; i++)
                            {
                                Console.WriteLine("Patient-{0}", i + 1);
                                Console.WriteLine("--------------------------------------------");
                                peopleList.displayPatients(i);
                                Console.WriteLine("--------------------------------------------");
                            }
                        }

                        else if (selection == 2)
                        {
                            if (appointmentList.Count == 8)
                            {
                                Console.Clear();
                                Console.WriteLine("All the appointments are booked for the day. Please try again tomorrow.");
                            }
                            else if (appointmentList.Count<8)                           
                            {
                                CreateSchedule(peopleList, appointmentList);
                            }
                            else
                            {
                                Console.WriteLine("The list is already full. You cannot add more appointments.");
                            }
                        }
                        else if (selection == 3)
                        {
                            if (appointmentList.Count != 8)
                            {
                                Console.WriteLine("There are not enough appointments to display. Please consider adding them.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Displaying Today's Schedule:");
                                Console.WriteLine("----------------------------");

                                for (int i = 0; i < appointmentList.Count; i++)
                                {
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"Appointment Number: {i + 1}");
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"FirstName: {appointmentList[i].AppointmentOfPerson.FirstName}");
                                    Console.WriteLine($"LastName: {appointmentList[i].AppointmentOfPerson.LastName}");
                                    Console.WriteLine($"Gender: {appointmentList[i].AppointmentOfPerson.Gender}");
                                    string[] birthDateFormatted = (appointmentList[i].AppointmentOfPerson.BirthDate).Split(' ');
                                    Console.WriteLine("Birth Date: {0}", birthDateFormatted[0]);
                                    var patientNumberFormatted = "XXX" + (appointmentList[i].AppointmentOfPerson.PatientNumber).Substring(3);
                                    Console.WriteLine("Patient Number: {0}", patientNumberFormatted);
                                    appointmentList[i].MyService();
                                }
                                Console.WriteLine("----------------------------------------------------------");
                            }

                        }
                        else if (selection == 4)
                        {
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine("You selected to exit. Thank you!!");
                            Console.WriteLine("---------------------------------");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("Please select the correct input from the below menu options ");
                        System.Environment.Exit(1);
                        Console.WriteLine("------------------------------------------------------------");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Please enter a valid numeric digit from the menu options.");

                    Console.WriteLine("---------------------------------------------------------");

                }

            } while (selection >= 1 || selection <= 4);          
            
            Console.ReadLine();

        }
        public static void CreateSchedule(PersonList peopleList, AppointmentList appointmentList)
        {
            int appointmentCounter = 0;
            int selectedPatient = 0;
            int startTime = 8;
            int endTime = 9;

            do
            {
                for (int i = 0; i < peopleList.Count; i++)
                {
                    Console.WriteLine("Patient-{0}", i + 1);
                    Console.WriteLine("--------------------------------------------");
                    peopleList.displayPatients(i);
                    Console.WriteLine("--------------------------------------------");
                }
                Console.WriteLine("Appointment-{0}          Timing: {1}:00 to {2}:00 ", appointmentCounter + 1, startTime, endTime);
                Console.WriteLine("--------------------------------------------");
                startTime += 1;
                endTime += 1;
                Console.WriteLine("\nPlease select a patient from the above list.");
                try
                {
                    selectedPatient = int.Parse(Console.ReadLine());
                    if (selectedPatient >= 1 && selectedPatient <= 10)
                    {
                        DateTime patientsBirthDate = DateTime.Parse(peopleList[selectedPatient - 1].BirthDate);
                        TimeSpan age = DateTime.Today - patientsBirthDate;
                        double selectedPatientAge = Math.Floor(age.Days / 365.255);
                        int selectedServiceByPatient = 0;

                        if (selectedPatientAge >= 60)
                        {
                            Console.WriteLine("\nHello\nPlease select a service from the following services for Seniors:");
                            Console.WriteLine(" 1- Cleaning\n 2 - Cavity Fill\n 3 - Check-up\n 4 - X-ray\n 5 - Dentures Fitting");
                            try
                            {
                                selectedServiceByPatient = int.Parse(Console.ReadLine());
                                CreateScheduleForSelectedPatient(peopleList[selectedPatient - 1], selectedServiceByPatient, appointmentCounter + 1, appointmentList);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\nSorry your input is incorrect\nSelect the appropriate service in numeric digits only and try again");
                                System.Environment.Exit(1);
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                break;
                            }

                        }

                        else if (selectedPatientAge > 18 && selectedPatientAge < 60)
                        {
                            Console.WriteLine("\nHello\nPlease select a service from the following services for Adults:");
                            Console.WriteLine(" 1- Cleaning\n 2 - Cavity Fill\n 3 - Check-up\n 4 - X-ray\n 5 - Veeners Fitting");
                            try
                            {
                                selectedServiceByPatient = int.Parse(Console.ReadLine());
                                CreateScheduleForSelectedPatient(peopleList[selectedPatient - 1], selectedServiceByPatient, appointmentCounter + 1, appointmentList);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\nSorry your input is incorrect\nSelect the appropriate service in numeric digits only and try again");
                                System.Environment.Exit(1);
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                break;
                            }
                        }

                        else if (selectedPatientAge <= 18)
                        {
                            Console.WriteLine("\nHello\nPlease select a service from the following services for children:");
                            Console.WriteLine(" 1- Cleaning\n 2 - Cavity Fill\n 3 - Check-up\n 4 - X-ray\n 5 - Braces Fitting");
                            try
                            {
                                selectedServiceByPatient = int.Parse(Console.ReadLine());
                                CreateScheduleForSelectedPatient(peopleList[selectedPatient - 1], selectedServiceByPatient, appointmentCounter + 1, appointmentList);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                Console.WriteLine("\nSorry your input is incorrect\nSelect the appropriate service in numeric digits only and try again");
                                System.Environment.Exit(1);
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                                break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("Patient number is not between 1 and 10. Please try again");
                        System.Environment.Exit(1);
                        Console.WriteLine("--------------------------------------------------------");
                        break;
                    }
                    appointmentCounter = appointmentCounter + 1;


                }
                catch (Exception)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Sorry your input is incorrect\nSelect the appropriate patient number in numeric digits only and try again");
                    System.Environment.Exit(1);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                    break;
                }

                
            } while (appointmentCounter < 8);

        }
        public static void CreateScheduleForSelectedPatient(Person patientDetails, int serviceSelectedByPatient, int appointmentNumber, AppointmentList appointmentList)
        {
            Appointment appendPatients = null;
            Service patientService = null;

            if (serviceSelectedByPatient > 0 && serviceSelectedByPatient <= 5)
            {
                switch (serviceSelectedByPatient)
                {
                    case 1:
                        patientService += patientDetails.Cleaning;
                        break;
                    case 2:
                        patientService += patientDetails.CavityFill;
                        break;
                    case 3:
                        patientService += patientDetails.Checkup;
                        break;
                    case 4:
                        patientService += patientDetails.Xray;
                        break;
                    case 5:
                        patientService += patientDetails.SpecialService;
                        break;
                    default:
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Improper service selection. Please try again!!");
                        System.Environment.Exit(1);
                        Console.WriteLine("----------------------------------------------");
                        break;
                }


                if (appointmentList.Count >= 8)
                {
                    appointmentList.Clear();
                    appendPatients = new Appointment(patientDetails, patientService, appointmentNumber);
                    appointmentList.Add(appendPatients);
                }
                    appendPatients = new Appointment(patientDetails, patientService, appointmentNumber);
                    appointmentList.Add(appendPatients);
                
                
            }
            else
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Improper service selection. Please try again!!");
                Console.WriteLine("----------------------------------------------");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
        }

    }
}
