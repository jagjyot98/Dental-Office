using System;
using System.Collections;
using System.Collections.Generic;

namespace Assign2_Dental_App
{
    public delegate void Schedule(string str);
    enum serviceType
    {
        serviceCleaning, serviceCavityFill, serviceCheckUp, serviceXRay  //,serviceDentureFitting,serviceVeneerFitting,BraceFitting
    }
    class person                                            // PERSON CLASS
    {
        public string firstName;
        public string lastName;
        public char gender;
        public string birthDate;
        public string patientNumber;
        public string category;
        public int indexNumber;
       
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public char Gender { get => gender; set => gender = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public int IndexNumber { get => indexNumber; set => indexNumber = value; }
        public string PatientNumber { get => patientNumber; set => patientNumber=value; }
        public string Category
        {
            get
            {
                return (this.category == "sen" ? "Senior" : this.category == "adult" ? "Adult" : "Child");
            }
            set
            { category = value; }
        }
        
        public person() { }
        public person(int indexNumber, string firstName, string lastName, char gender, string birthDate, string category, string patientNumber)
        {
            this.indexNumber = indexNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.category = category;
            this.patientNumber = patientNumber;
        }

        public string toPrint()
        {
            return indexNumber + ". Patient Number: XXX" + patientNumber.Substring(3, patientNumber.Length)+ ", Full Name: " + firstName + " " + lastName + ", Gender: " + gender + ", Birthdate: " + birthDate + ", Category: " + category;
        }
    }

    class Seniors : person                                            // SENIORS CLASS
    {
        public Seniors(int indexNumber, string firstName, string lastName, char gender, string birthDate, string category, string patientNumber) 
            :base(indexNumber, firstName, lastName, gender, birthDate, category, patientNumber)
        { }
    }
    class Adults : person                                            // ADULTS CLASS
    {
        public Adults(int indexNumber, string firstName, string lastName, char gender, string birthDate, string category, string patientNumber)
            : base(indexNumber, firstName, lastName, gender, birthDate, category, patientNumber)
        { }
    }
    class Children : person                                            // CHILDREN CLASS
    {
        public Children(int indexNumber, string firstName, string lastName, char gender, string birthDate, string category, string patientNumber)
            : base(indexNumber, firstName, lastName, gender, birthDate, category, patientNumber)
        { }
    }

    

    class services                                                      // SERVICES CLASS
    {
        private serviceType Servicetype;
        public services() {  }
        public services(serviceType serviceName)
        {
            this.Servicetype = serviceName;
        }

        public static void serviceCleaning(string str)
        {
            Console.WriteLine("1. The Cleaning {0} was performed",str);
        }
        public static void serviceCavityFill(string str)
        {
            Console.WriteLine("2. The Cavity Filling {0} was performed",str);
        }
        public static void serviceCheckUp(string str)
        {
            Console.WriteLine("3. The Check Up {0} was performed",str);
        }
        public static void serviceXRay(string str)
        {
            Console.WriteLine("4. The X-Ray {0} was performed",str);
        }

                                                 /////////////////////////////      DENTURE,VENEER,BRACES     ///////////////////////////

        public static void serviceDentureFitting(string str)             // service avialble to Seniors 
        {
            Console.WriteLine("5. The Denture Fitting {0} was performed",str);
        }
        public static void serviceVeneersFitting(string str)             // service avialble to Adults 
        {
            Console.WriteLine("5. The Veneers Fitting {0} was performed",str);
        }
        public static void serviceBracesFitting(string str)             // service avialble to Children 
        {
            Console.WriteLine("5. The Braces Fitting {0} was performed",str);
        }

        public static void printList(ArrayList arr)
        {
            Console.WriteLine("\tServices Available for the Patient:");
            foreach(var x in arr)
                Console.WriteLine("\t"+x);
        }
    }

    internal class person_List
    {
        List<person> personList = new List<person>();
        public person_List() { }
        public static int size = 10;
        public person_List(person Person)
        {
            personList = new List<person>();
        }
        public person this[int index]
        {
            get
            {
                person temp;

                if (index >= 0 && index <= size - 1)
                {
                    temp = personList[index];
                }
                else
                {
                    temp = null;
                }

                return temp;
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    personList[index] = value;
                }
            }
        }
        public List<person> Add(person Person)
        {
            personList.Add(Person);
            return personList;
        }
    }

    class Program                                               // MAIN PROGRAM
    {
        static person_List schedule = new person_List();
        
        static void printlist(ArrayList arr)       //to print list of unique persons
        {
            foreach (person X in arr)
                Console.WriteLine("\t" + X.indexNumber + " " + X.category + " " + X.firstName + " " + X.lastName + " " + X.gender + " " + X.birthDate + " XXX" + X.patientNumber.Substring(3 ));
        }

        static Schedule CreateSchedule(ArrayList people)    // to create  a schedule
        {
            int count = 0;      // Holds count of 8 slots of a Schedule
            Schedule scheduledelegate = null;
            do
            {
                Console.Write("Select a person's Index Number: ");
                int personSelected = int.Parse(Console.ReadLine());

                person selectedperson = (person)people[personSelected]; // OBJECT CREATED, AND SLOT AND DATE APPOINTED

                schedule.Add(selectedperson);   // person added to schedule list
                
                
                ArrayList serveoptns = new ArrayList(Enum.GetValues(typeof(serviceType)));

                int i = 0;
                switch (selectedperson.category)
                {
                    case "Senior":
                        {
                            serveoptns.Add("serviceDentureFitting");
                            i = 0;
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }

                    case "Adult":
                        {
                            serveoptns.Add("serviceVeneersFitting");
                            i = 0;
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }

                    case "Child":
                        {
                            serveoptns.Add("serviceBracesFitting");
                            i = 0;
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }
                }

                Console.Write("Select a service from above: ");             //  DONE    have to insert functin name below....
                var serveOptnSelected = int.Parse(Console.ReadLine());
                                              // ....here with the delegate

                switch (serveOptnSelected)
                {
                    case 1:
                        {
                            scheduledelegate += services.serviceCleaning;
                            break;
                        }
                    case 2:
                        {
                            scheduledelegate += services.serviceCavityFill;
                            break;
                        }
                    case 3:
                        {
                            scheduledelegate += services.serviceCheckUp;
                            break;
                        }
                    case 4:
                        {
                            scheduledelegate += services.serviceXRay;
                            break;
                        }
                    case 5:
                        {
                            switch (selectedperson.category)
                            {
                                case "Senior":
                                    {
                                        scheduledelegate += services.serviceDentureFitting;
                                        break;
                                    }
                                case "Adult":
                                    {
                                        scheduledelegate += services.serviceVeneersFitting;
                                        break;
                                    }
                                case "Child":
                                    {
                                        scheduledelegate += services.serviceBracesFitting;
                                        break;
                                    }
                            }
                            break;
                        }
                }
                count++;        // 1 slot is taken 
            } while (count <= 7);
            return scheduledelegate;
        }
        static void Main(string[] args)
        {

            string[] slots = { "8am-9am", "9am-10am", "10am-11am", "11am-12noon", "12noon-1pm", "1pm-2pm", "2pm-3pm", "3pm-4pm" };
            //string[] dates = { "01-Nov-2022", "02-Nov-2022", "03-Nov-2022", "04-Nov-2022" };
            ArrayList people = new ArrayList();

            Seniors senior1 = new Seniors(1, "ABC", "abc", 'M', "01-Jan-1965", "sen", "1000S01");           // HARD CODE PEOPLE LIST
            Seniors senior2 = new Seniors(2, "CDE", "cde", 'F', "02-Jan-1965", "sen", "1000S02");
            Seniors senior3 = new Seniors(3, "EFG", "efg", 'M', "03-Jan-1965", "sen", "1000S03");
            //Seniors senior4 = new Seniors(4, "GHI", "ghi", 'F', "04-Jan-1965", "sen", "1000S04");
            //Seniors senior5 = new Seniors(5, "IJK", "ijk", 'F', "05-Jan-1965", "sen", "1000S05");

            Adults adult1 = new Adults(4, "KLM", "klm", 'M', "04-Jan-2000", "adult", "2000A01");
            Adults adult2 = new Adults(5, "MNO", "mno", 'F', "04-Jan-2000", "adult", "2000A02");
            Adults adult3 = new Adults(6, "OPQ", "opq", 'M', "04-Jan-2000", "adult", "2000A03");
            //Adults adult4 = new Adults(9, "QRS", "qrs", 'F', "04-Jan-2000", "adult", "2000A04");
            //Adults adult5 = new Adults(10, "STU", "stu", 'M', "04-Jan-2000", "adult", "2000A05");

            Children child1 = new Children(7, "UVW", "uvw", 'F', "04-Jan-2007", "child", "3000C01");
            Children child2 = new Children(8, "WXY", "wxy", 'M', "04-Jan-2007", "child", "3000C02");
            Children child3 = new Children(9, "YZA", "yza", 'F', "04-Jan-2007", "child", "3000C03");
            Children child4 = new Children(10, "ZAB", "zab", 'M', "04-Jan-2007", "child", "3000C04");
            //Children child5 = new Children(15, "ZAC", "zac", 'F', "04-Jan-2007", "child", "3000C05");

            people.Add(senior1);
            people.Add(senior2);
            people.Add(senior3);
            //people.Add(senior4);
            //people.Add(senior5);

            people.Add(adult1);
            people.Add(adult2);
            people.Add(adult3);
            //people.Add(adult4);
            //people.Add(adult5);

            people.Add(child1);
            people.Add(child2);
            people.Add(child3);
            people.Add(child4);
            //people.Add(child5);
            int mainopt;
            do
            {
                Console.WriteLine("\tDental Clinic");                                   // MAIN MENU
                Console.WriteLine("\t*************");
                Console.WriteLine("1. To List all patients with details");
                Console.WriteLine("2. To Create a Schedule");
                Console.WriteLine("3. To view Day's Schedule and Perform Tasks");
                Console.WriteLine("4. Exit ..!!");
                Console.Write("\tEnter your choice from above: ");
                mainopt = int.Parse(Console.ReadLine());
                Schedule scheduledelegate= services.serviceDentureFitting;
                scheduledelegate -= services.serviceDentureFitting;
                switch (mainopt)
                {
                    case 1:
                        {       //************************************ To print all people 
                            printlist(people);
                            break;
                        }

                    case 2:
                        {   //************************************ To craete a schedule                                            
                            //change according to hard code
                            // int personSelected;
                           
                            scheduledelegate = CreateSchedule(people);
                            
                            break;
                        }

                    case 3:
                        {   //************************************ To print the schedule and perform tasks
                            for (int i = 0; i < 8; i++)
                            {
                                var obj = schedule[i];//.toPrint();
                                obj.toPrint();
                                Console.WriteLine("Appointment Slot: " + slots[i]);
                            }
                            Console.WriteLine("Performing all the schedule tasks:");
                            scheduledelegate("service");
                            break;
                        }
                    case 4: break;
                    default:
                        {
                            Console.WriteLine("Invalid entry");
                            break;
                        }
                }

            } while (true);
            }
    }
}
