using System;
using System.Collections;

namespace Assign2_Dental_App
{
    public delegate void Schedule();
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

        public string Category
        {
            get
            {
                return (this.category == "sen" ? "Senior" : this.category == "adult" ? "Adult" : "Child");
            }
            set
            { category = value; }
        }
        public string PatientNumber
        {
            get
            {
                string patno = "XXX";                               // to hide 1st 3 letters in patient no
                patno = patno.Insert(4, this.patientNumber.Substring(3, patientNumber.Length));
                return patno;
            }
            set
            { patientNumber = value; }
        }

        public person() { }
        public person(int indexNumber, string firstName, string lastName, char gender, string birthDate, string category, string patientNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.category = category;
            this.patientNumber = patientNumber;
        }

        public string toPrint()
        {
            return indexNumber + ". Patient Number: " + patientNumber + ", Full Name: " + firstName + " " + lastName + ", Gender: " + gender + ", Birthdate: " + birthDate + ", Category: " + category;
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

    class registration : person                                            // REGISTRATION CLASS
    {
        string slot;
        string appointdate;

        static int count = 0, datecount = 0;               // Slots and appointment date handling
        string[] slots = { "8am-9am", "9am-10am", "10am-11am", "11am-12noon", "12noon-1pm", "1pm-2pm", "2pm-3pm", "3pm-4pm" };
        string[] dates = { "01-Nov-2022", "02-Nov-2022", "03-Nov-2022", "04-Nov-2022" };
        
        public registration()
        {
            if (count == 7)
            {
                datecount++;
                count = 0;
            }
            this.slot = slots[count++];
            this.appointdate = dates[datecount];
        }

        public /*override*/ string toPrint()
        {
            return  "Slot: " + slot +", Appintment date: "+appointdate ;
        }
    }
    class services                                              // SERVICES CLASS
    {
        private serviceType Servicetype;
        public services() {  }
        public services(serviceType serviceName)
        {
            this.Servicetype = serviceName;
        }

        public static void serviceCleaning()
        {
            Console.WriteLine("1. The Cleaning was performed");
        }
        public static void serviceCavityFill()
        {
            Console.WriteLine("2. The Cavity Filling was performed");
        }
        public static void serviceCheckUp()
        {
            Console.WriteLine("3. The Check Up was performed");
        }
        public static void serviceXRay()
        {
            Console.WriteLine("4. The X-Ray was performed");
        }

                                 /////////////////////////////      DENTURE,VENEER,BRACES     ///////////////////////////

        public static void serviceDentureFitting()             // service avialble to Seniors 
        {
            Console.WriteLine("5. The Denture Fitting was performed");
        }
        public static void serviceVeneersFitting()             // service avialble to Adults 
        {
            Console.WriteLine("5. The Veneers Fitting was performed");
        }
        public static void serviceBracesFitting()             // service avialble to Children 
        {
            Console.WriteLine("5. The Braces Fitting was performed");
        }

        public static void printList(ArrayList arr)
        {
            Console.WriteLine("\tServices Available for the Patient:");
            foreach(var x in arr)
                Console.WriteLine("\t"+x);
        }
    }



    class Program                                               // MAIN PROGRAM
    {
        static ArrayList schedule = new ArrayList();
        static void printlist(ArrayList arr)       //to print list of unique persons
        {
            foreach (person X in arr)
                Console.WriteLine("\t" + X.indexNumber + " " + X.category + " " + X.firstName + " " + X.lastName + " " + X.gender + " " + X.birthDate + " " + X.patientNumber);
        }

        static void CreateSchedule(ArrayList people)    // to create  a schedule
        {
            int count = 0;      // Holds count of 8 slots of a Schedule
            do
            {
                Console.Write("Select a person's Index Number: ");
                int personSelected = int.Parse(Console.ReadLine());

                registration selectedperson = (registration)people[personSelected]; // OBJECT CREATED, AND SLOT AND DATE APPOINTED

                schedule.Add(selectedperson);
                
                ArrayList serveoptns = new ArrayList(Enum.GetValues(typeof(services)));

                int i = 0;
                switch (selectedperson.)        // WORKING HERE RIGHT NOW......
                {
                    case "Senior":
                        {
                            serveoptns.Add("serviceDentureFitting");
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }

                    case "Adult":
                        {
                            serveoptns.Add("serviceVeneersFitting");
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }

                    case "Child":
                        {
                            serveoptns.Add("serviceBracesFitting");
                            foreach (var x in serveoptns)
                                Console.WriteLine(i++ + " " + x);
                            break;
                        }
                }

                Console.Write("Select a service from above: ");             //  DONE    have to insert functin name below....
                var serveOptnSelected = int.Parse(Console.ReadLine());
                Schedule scheduledelegate = null;                              // ....here with the delegate

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
        }
        static void Main(string[] args)
        {
            ArrayList people = new ArrayList();

            Seniors senior1 = new Seniors(1, "ABC", "abc", 'M', "01-Jan-1965", "sen", "1000S01");
            Seniors senior2 = new Seniors(2, "CDE", "cde", 'F', "02-Jan-1965", "sen", "1000S02");
            Seniors senior3 = new Seniors(3, "EFG", "efg", 'M', "03-Jan-1965", "sen", "1000S03");
            Seniors senior4 = new Seniors(4, "GHI", "ghi", 'F', "04-Jan-1965", "sen", "1000S04");
            Seniors senior5 = new Seniors(5, "IJK", "ijk", 'F', "05-Jan-1965", "sen", "1000S05");
            
            Adults adult1 = new Adults(6, "KLM", "klm", 'M', "04-Jan-2000", "adult", "2000A01");
            Adults adult2 = new Adults(7, "MNO", "mno", 'F', "04-Jan-2000", "adult", "2000A02");
            Adults adult3 = new Adults(8, "OPQ", "opq", 'M', "04-Jan-2000", "adult", "2000A03");
            Adults adult4 = new Adults(9, "QRS", "qrs", 'F', "04-Jan-2000", "adult", "2000A04");
            Adults adult5 = new Adults(10, "STU", "stu", 'M', "04-Jan-2000", "adult", "2000A05");

            Children child1 = new Children(11, "UVW", "uvw", 'F', "04-Jan-2007", "child", "3000C01");
            Children child2 = new Children(12, "WXY", "wxy", 'M', "04-Jan-2007", "child", "3000C02");
            Children child3 = new Children(13, "YZA", "yza", 'F', "04-Jan-2007", "child", "3000C03");
            Children child4 = new Children(14, "ZAB", "zab", 'M', "04-Jan-2007", "child", "3000C04");
            Children child5 = new Children(15, "ZAC", "zac", 'F', "04-Jan-2007", "child", "3000C05");

            people.Add(senior1);
            people.Add(senior2);
            people.Add(senior3);
            people.Add(senior4);
            people.Add(senior5);

            people.Add(adult1);
            people.Add(adult2);
            people.Add(adult3);
            people.Add(adult4);
            people.Add(adult5);

            people.Add(child1);
            people.Add(child2);
            people.Add(child3);
            people.Add(child4);
            people.Add(child5);

            

            Console.WriteLine("\tDental Clinic");
            Console.WriteLine("\t*************");
            Console.WriteLine("1. To List all patients with details");
            Console.WriteLine("2. To Create a Schedule");
            Console.WriteLine("3. To view Day's Schedule and Perform Tasks");
            Console.Write("\tEnter your choice from above: ");
            int mainopt = int.Parse(Console.ReadLine());


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
                        CreateSchedule(people);
                        break;
                    }
                    
                case 3:
                    {   //************************************ To print the schedule and perform tasks
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid entry");
                        break;
                    }
            }
        }
    }
}

