using System.Collections;

/*DONE             for services we have to create some list of options for services from 
                 which the chosen ones will be saved in patients services 
               list and accordingly made avialable through delegate list of functions.*/

enum services
{
    serviceCleaning, serviceCavityFill, serviceCheckUp, serviceXRay  //,serviceDentureFitting,serviceVeneerFitting,BraceFitting
}   


namespace Assign2_Dental_office
{
    public delegate void Schedule();              // delgates for different types will contain service functions for each type of patient and individually
                                                  //public delegate void Adult();
                                                  //public delegate void Child();

    class registration
    {
        //string firstName;
        //string lastName;
        //char gender;
        //string birthDate;

        //string patientNumber; // (10-digit number)
        //string slot;
        //
        public int indexNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public char gender { get; set; }
        public string birthDate { get; set; }
        public string slot { get; set; }
        public string appointdate { get; set; }
        private string setCategory;
        private string setPatientNumber;
        public string category
        {
            get
            {
                return (setCategory == "sen" ? "Senior" : setCategory == "adult" ? "Adult" : "Child");
            }
            set
            { setCategory = value; }
        }
        const string patno = "XXX";
        public string patientNumber
        {
            get
            {
                return (patno + setPatientNumber.Substring(3));
            }
            set
            { setPatientNumber = value; }
        }

        // Services funtions AVAILABLE TO ALL  serviceCleaning serviceCavityFill serviceCheckUp serviceXRay
        public static void serviceCleaning()
        {
            Console.WriteLine("The Cleaning was performed");
        }
        public static void serviceCavityFill()
        {
            Console.WriteLine("The Cavity Filling was performed");
        }
        public static void serviceCheckUp()
        {
            Console.WriteLine("The Check Up was performed");
        }
        public static void serviceXRay()
        {
            Console.WriteLine("The X-Ray was performed");
        }
    }

    class schedulelist
    {
        static int count = 0, datecount = 0;               // Slots and appointment date handling

        string[] slots = { "8am-9am", "9am-10am", "10am-11am", "11am-12noon", "12noon-1pm", "1pm-2pm", "2pm-3pm", "3pm-4pm" };
        string[] dates = { "01-Nov-2022", "02-Nov-2022", "03-Nov-2022", "04-Nov-2022" };

        private registration[] schedule = new registration[8];
        public registration this[int index]
        {
            set
            {
                if (index % 8 == 0)
                {
                    datecount++;
                    count = 0;
                }
                schedule[index].slot = slots[count++];
                schedule[index].appointdate = dates[datecount];
            }
        }
    }

    class Seniors : registration
    {
        public Seniors() { }
        int selectedService = 0;

        /*public Seniors()                        
        {
            firstName = "John";
            lastName = "Doe";
            gender = 'M';
            birthDate = "01/01/1955"
        }
        */
        public Seniors(int indexNumber, string category, string firstName, string lastName, char gender, string birthDate, string patientNumber)//, int selectedService)
        {
            this.indexNumber = indexNumber;
            this.category = category;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.patientNumber = patientNumber;
            //this.selectedService = selectedService;
        }
        public static void serviceDentureFitting()             // service avialble to Seniors 
        {
            Console.WriteLine("The Denture Fitting was performed");
        }
    }
    class Adults : registration
    {
        public Adults() { }
        public Adults(int indexNumber, string category, string firstName, string lastName, char gender, string birthDate, string patientNumber)//, int selectedService)
        {
            this.indexNumber = indexNumber;
            this.category = category;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.patientNumber = patientNumber;
            //this.selectedService = selectedService;
        }
        public static void serviceVeneersFitting()             // service avialble to Adults 
        {
            Console.WriteLine("The Veneers Fitting was performed");
        }
    }
    class Children : registration
    {
        public Children() { }
        public Children(int indexNumber, string category, string firstName, string lastName, char gender, string birthDate, string patientNumber)//, int selectedService)
        {
            this.indexNumber = indexNumber;
            this.category = category;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.patientNumber = patientNumber;
            //this.selectedService = selectedService;
        }
        public static void serviceBracesFitting()             // service avialble to Children 
        {
            Console.WriteLine("The Braces Fitting was performed");
        }
    }
    class Program
    {
        static void printlist(ArrayList arr)       //to print list of unique persons
        {
            foreach (registration X in arr)
                Console.WriteLine("\t" + X.indexNumber + " " + X.category + " " + X.firstName + " " + X.lastName + " " + X.gender + " " + X.birthDate + " " + X.patientNumber);
        }
        static void Main(string[] args)
        {
            ArrayList people = new ArrayList();

            Seniors senior1 = new Seniors(1, "sen", "ABC", "abc", 'M', "01-Jan-1965", "1000001");
            Seniors senior2 = new Seniors(2, "sen", "CDE", "cde", 'F', "02-Jan-1965", "1000002");
            Seniors senior3 = new Seniors(3, "sen", "EFG", "efg", 'M', "03-Jan-1965", "1000003");
            Seniors senior4 = new Seniors(4, "sen", "GHI", "ghi", 'F', "04-Jan-1965", "1000004");

            Adults adult1 = new Adults(5, "adult", "IJK", "ijk", 'F', "0-Jan-2000", "2000001");
            Adults adult2 = new Adults(6, "adult", "KLM", "klm", 'M', "04-Jan-2000", "2000002");
            Adults adult3 = new Adults(7, "adult", "MNO", "mno", 'F', "04-Jan-2000", "2000003");
            Adults adult4 = new Adults(8, "adult", "OPQ", "opq", 'M', "04-Jan-2000", "2000004");

            Children child1 = new Children(9, "child", "QRS", "qrs", 'F', "04-Jan-2007", "3000001");
            Children child2 = new Children(10, "child", "STU", "stu", 'M', "04-Jan-2007", "3000002");
            Children child3 = new Children(11, "child", "UVW", "uvw", 'F', "04-Jan-2007", "3000003");
            Children child4 = new Children(12, "child", "WXY", "wxy", 'M', "04-Jan-2007", "3000004");

            people.Add(senior1);
            people.Add(senior2);
            people.Add(senior3);
            people.Add(senior4);

            people.Add(adult1);
            people.Add(adult2);
            people.Add(adult3);
            people.Add(adult4);

            people.Add(child1);
            people.Add(child2);
            people.Add(child3);
            people.Add(child4);

            ArrayList register = new ArrayList();
            registration appointment = new registration();
            ArrayList schedule = new ArrayList();

            //var bagoptions = Enum.GetValues(typeof(Bags));

            int count = 0, datecount = 0;               // Slots and appointment date handling

            string[] slots = { "8am-9am", "9am-10am", "10am-11am", "11am-12noon", "12noon-1pm", "1pm-2pm", "2pm-3pm", "3pm-4pm" };
            string[] dates = { "01-Nov-2022", "02-Nov-2022", "03-Nov-2022", "04-Nov-2022" };


            Console.WriteLine("\tDental Clinic");
            Console.WriteLine("1. To List all patients with details");
            Console.WriteLine("2. To Create a Schedule");
            Console.WriteLine("3. To view Day's Schedule and Perform Tasks");
            Console.Write("\tEnter your choice from above: ");
            int mainopt = int.Parse(Console.ReadLine());


            switch (mainopt)
            {
                case 1:
                    {       //************************************ To print all people ( THEY ARE NOT PATIENTS !!)
                        printlist(people);
                        //Console.WriteLine("Patient Number: {0}",register.patientNumber);
                        //Console.WriteLine(X.category);
                        //Console.Write("Full Name: {0} ",register.firstName);     //Full Name: First Last (Both in single line)
                        //Console.WriteLine(register.lastName);
                        //Console.WriteLine("Gender: {0}", (register.gender == 'M' ? "Male" : "Female") );
                        //Console.WriteLine("Birth Date: {0}", register.birthDate);
                        //Console.WriteLine("Slot: {0}", register.slot);
                        break;
                    }

                case 2:
                    {   //************************************ To craete a schedule                                            
                        //change according to hard code
                        // int personSelected;
                        Console.Write("Select a person's Index Number: ");
                        int personSelected = int.Parse(Console.ReadLine());
                        registration selectedperson = (registration)people[personSelected];
                        ArrayList serveoptns = new ArrayList(Enum.GetValues(typeof(services)));
                        int i = 0;
                        switch (selectedperson.category)
                        {
                            case "Senior":
                                serveoptns.Add("serviceDentureFitting");
                                foreach (var x in serveoptns)
                                    Console.WriteLine(i++ + " " + x);
                                /*Senior seniordelegate = Seniors.serviceDentureFitting;  //seniors service
                                //general services
                                seniordelegate += registration.serviceCleaning;         
                                seniordelegate += registration.serviceCavityFill;
                                seniordelegate += registration.serviceCheckUp;
                                seniordelegate += registration.serviceXRay;*/
                                break;

                            case "Adult":
                                serveoptns.Add("serviceVeneersFitting");
                                foreach (var x in serveoptns)
                                    Console.WriteLine(i++ + " " + x);
                                /*Adult adultdelegate = Adults.serviceVeneersFitting;  //adults service
                                //general services
                                adultdelegate += registration.serviceCleaning;
                                adultdelegate += registration.serviceCavityFill;
                                adultdelegate += registration.serviceCheckUp;
                                adultdelegate += registration.serviceXRay;*/
                                break;

                            case "Child":
                                serveoptns.Add("serviceBracesFitting");
                                foreach (var x in serveoptns)
                                    Console.WriteLine(i++ + " " + x);
                                /*Child childdelegate = Children.serviceBracesFitting;  //children service
                                //general services
                                childdelegate += registration.serviceCleaning;
                                childdelegate += registration.serviceCavityFill;
                                childdelegate += registration.serviceCheckUp;
                                childdelegate += registration.serviceXRay;*/
                                break;
                        }

                        Console.Write("Select a service from above: ");             //have to insert functin name below....
                        var serveOptnSelected = int.Parse(Console.ReadLine());
                        Schedule scheduledelegate;// = Schedule.serveOptnSelected;     // ....here with the delegate

                        appointment.category = Console.ReadLine();
                        if (appointment.category == "Senior")
                        {
                            if (count == 7)
                            {
                                count = 0;
                                datecount++;
                            }
                            Seniors senior = new Seniors();
                            senior.firstName = Console.ReadLine();
                            senior.lastName = Console.ReadLine();
                            senior.gender = char.Parse(Console.ReadLine());
                            senior.birthDate = Console.ReadLine();
                            //senior.appointdate = Console.ReadLine();
                            // services ?
                            senior.slot = slots[count];
                            senior.appointdate = dates[datecount];
                            count++;
                            schedule.Add(senior);
                        }
                        else if (appointment.category == "Adult")
                        {
                            if (count == 7)
                            {
                                count = 0;
                                datecount++;
                            }
                            Adults adult = new Adults();
                            adult.firstName = Console.ReadLine();
                            adult.lastName = Console.ReadLine();
                            adult.gender = char.Parse(Console.ReadLine());
                            adult.birthDate = Console.ReadLine();
                            //adult.appointdate = Console.ReadLine();
                            // services
                            adult.slot = slots[count];
                            adult.appointdate = dates[datecount];
                            count++;
                            schedule.Add(adult);
                        }
                        else
                        {
                            if (count == 7)
                            {
                                count = 0;
                                datecount++;
                            }
                            Children child = new Children();
                            child.firstName = Console.ReadLine();
                            child.lastName = Console.ReadLine();
                            child.gender = char.Parse(Console.ReadLine());
                            child.birthDate = Console.ReadLine();
                            //child.appointdate = Console.ReadLine();
                            // services
                            child.slot = slots[count];
                            child.appointdate = dates[datecount];
                            count++;
                            schedule.Add(child);
                        }
                        break;
                    }

                case 3:
                    {   //************************************ To print the schedule and perform tasks
                        foreach (var X in schedule)
                        {
                            if (X.GetType() == typeof(Seniors))
                            {
                                var senior = new Seniors();
                                Console.WriteLine("Patient No: {0}", senior.patientNumber);
                                Console.WriteLine("Full Name: {0} {1}", senior.firstName, senior.lastName);
                                Console.WriteLine("Gender: {0}", senior.gender);
                                Console.WriteLine("Birth Date: {0}", senior.birthDate);
                                Console.WriteLine("Patient No: {0}", senior.patientNumber);
                                Console.WriteLine("Appointment Date: {0}", senior.appointdate);
                                Console.WriteLine("Slot: {0}", senior.slot);
                                // Services
                            }
                            else if (X.GetType() == typeof(Adults))
                            {
                                var adult = new Adults();
                                Console.WriteLine("Patient No: {0}", adult.patientNumber);
                                Console.WriteLine("Full Name: {0} {1}", adult.firstName, adult.lastName);
                                Console.WriteLine("Gender: {0}", adult.gender);
                                Console.WriteLine("Birth Date: {0}", adult.birthDate);
                                Console.WriteLine("Patient No: {0}", adult.patientNumber);
                                Console.WriteLine("Appointment Date: {0}", adult.appointdate);
                                Console.WriteLine("Slot: {0}", adult.slot);
                                // Services
                            }
                            else
                            {
                                var child = new Children();
                                Console.WriteLine("Patient No: {0}", child.patientNumber);
                                Console.WriteLine("Full Name: {0} {1}", child.firstName, child.lastName);
                                Console.WriteLine("Gender: {0}", child.gender);
                                Console.WriteLine("Birth Date: {0}", child.birthDate);
                                Console.WriteLine("Patient No: {0}", child.patientNumber);
                                Console.WriteLine("Appointment Date: {0}", child.appointdate);
                                Console.WriteLine("Slot: {0}", child.slot);
                                // Services
                            }
                        }
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