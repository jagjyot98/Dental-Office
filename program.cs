using System;
using System.Collections;


                                            /*for services we have to create some list of options for services from 
                                              which the chosen ones will be saved in patients services 
                                            list and accordingly made avialable through delegate list of functions.*/




namespace Assign2_Dental_office
{
    public delegate void Senior();              // delgates for different types will contain service functions for each type of patient and individually
    public delegate void Adult();
    public delegate void Child();

    class registration
    {
        //string firstName;
        //string lastName;
        //char gender;
        //string birthDate;

        //string patientNumber; // (10-digit number)
        //string slot;
        //
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public char gender { get; set; }
        public string birthDate { get; set; }
        public string slot { get; set; }
        public string appointdate { get; set; }
        public string category 
        {
            get
            {
                return (this.category == "sen" ? "Senior" : this.category == "adult" ? "Adult" : "Child");
            }
            set
            { category = value; }        
        }
        public string patientNumber
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

                                                // Services funtions AVAILABLE TO ALL
        public void serviceCleaning()
        {
            Console.WriteLine("The Cleaning was performed");
        }
        public void serviceCavityFill()
        {
            Console.WriteLine("The Cavity Filling was performed");
        }
        public void serviceCheckUp()
        {
            Console.WriteLine("The Check Up was performed");
        }
        public void serviceXRay()
        {
            Console.WriteLine("The X-Ray was performed");
        }
    }
    class Seniors : registration
    {

        int selectedService = 0;

        public Seniors()                        
        {
            firstName = "John";
            lastName = "Doe";
            gender = 'M';
            birthDate = "01/01/1955"
        }

        public Seniors(string firstName, string lastName, char gender, string birthDate, int selectedService)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthDate = birthDate;
            this.selectedService = selectedService;
        }
        public void serviceDentureFitting()             // service avialble to Seniors 
        {
            Console.WriteLine("The Denture Fitting was performed");
        }
    }
    class Adults : registration
    {
        public void serviceVeneersFitting()             // service avialble to Adults 
        {
            Console.WriteLine("The Veneers Fitting was performed");
        }
    }
    class Children : registration
    {
        public void serviceBracesFitting()             // service avialble to Children 
        {
            Console.WriteLine("The Braces Fitting was performed");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList register = new ArrayList();
            registration appointment = new registration();
            ArrayList schedule = new ArrayList();

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

                        for(in )        // how to access each elemnet 
                        //Console.WriteLine("Patient Number: {0}",register.patientNumber);
                        Console.WriteLine(register.category);
                        Console.Write("Full Name: {0} ",register.firstName);     //Full Name: First Last (Both in single line)
                        Console.WriteLine(register.lastName);
                        Console.WriteLine("Gender: {0}", (register.gender == 'M' ? "Male" : "Female") );
                        Console.WriteLine("Birth Date: {0}", register.birthDate);
                        //Console.WriteLine("Slot: {0}", register.slot);
                        break;
                    }

                case 2:
                    {   //************************************ To craete a schedule                                            
                        //change according to hard code
                        appointment.category = Console.ReadLine();
                        if(appointment.category == "Senior")
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
                        foreach(var X in schedule)
                        {
                            if(X.GetType() == typeof(Seniors))
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
                            else if(X.GetType() == typeof(Adults))
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













namespace Class_task_Vet
{
    class patient
    {                   // how to get a unique id for an individual patient ?
        string name;
        string problem;
        public void getpatientdetail()
        {
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter problem:");
            problem = Console.ReadLine();

        }
        public void showpatientdetail()
        {
            Console.WriteLine("Name:{0}", name);
            Console.WriteLine("problem:{0}", problem);
        }
    }
    class mammal : patient
    {
        bool pregnancy;
        public void getmammaldetail()
        {
            Console.WriteLine("Enter pregnancy status:(true/false)");
            pregnancy = bool.Parse(Console.ReadLine());
        }
        public void showmammaldetail()
        {
            Console.WriteLine("Pregnancy status:{0}", pregnancy);
        }
    }
    class fish : patient
    {
        bool freshwater;
        public void getfishdetail()
        {
            Console.WriteLine("is fresh water:(true/false)");
            freshwater = bool.Parse(Console.ReadLine());
        }
        public void showfishdetail()
        {
            Console.WriteLine("Is fresh water status:{0}", freshwater);
        }
    }
    class bird : patient
    {
        bool farm;
        public void getbirddetail()
        {
            Console.WriteLine("is farm bird:(true/false)");
            farm = bool.Parse(Console.ReadLine());
        }
        public void showbirddetail()
        {
            Console.WriteLine("Is farm bird status:{0}", farm);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList Patients = new ArrayList();   //how to limit count of patients ?
                                                    //int count = 9;
                                                    //do          // use when entries doneby management at clinic 
                                                    //{
            Console.WriteLine("1. Mammal");
            Console.WriteLine("2. Fish");
            Console.WriteLine("3. Bird");
            Console.WriteLine("Select your patient type from above:");
            int patienttype = int.Parse(Console.ReadLine());


            switch (patienttype)
            {
                case 1:
                    {
                        mammal M = new mammal();
                        count--;
                        M.getpatientdetail();
                        M.getmammaldetail();
                        M.showpatientdetail();
                        M.showmammaldetail();
                        Patients.Add(M);
                        break;
                    }
                case 2:
                    {
                        fish F = new fish();
                        count--;
                        F.getpatientdetail();
                        F.getfishdetail();
                        F.showpatientdetail();
                        F.showfishdetail();
                        Patients.Add(F);
                        break;
                    }
                case 3:
                    {
                        bird B = new bird();
                        count--;
                        B.getpatientdetail();
                        B.getbirddetail();
                        B.showpatientdetail();
                        B.showbirddetail();
                        Patients.Add(B);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid entry");
                        break;
                    }
            }
            // } while (count >= 0);
            //for(int i=0;i<Patients.Count;i++)

        }
    }
}
