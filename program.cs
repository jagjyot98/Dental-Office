using System;
using System.Collections;

namespace Assign2_Dental_office
{
    class registration
    {
        //string firstName;
        //string lastName;
        //char gender;
        //string birthDate;

        //string patientNumber; // (10-digit number)
        //string slot;
        static int count=0;//
        string service;

        public registration()
        {
            if (count == 7)
                count = 0;

            string[] slots = { "8am-9am", "9am-10am", "10am-11am", "11am-12noon", "12noon-1pm", "1pm-2pm", "2pm-3pm", "3pm-4pm" };
            this.slot = slots[count];
            count++;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public char gender { get; set; }
        public string birthDate { get; set; }
        public string slot { get; set; }
        public string patientNumber
        {
            get
            {
                string patno = "XXX";
                patno = patno.Insert(4, this.patientNumber.Substring(3, patientNumber.Length));
                return patno;
            }
            set
            { patientNumber = value; }
        }
        /*public string firstName
        {
            get
            {   return firstName; }
            set
            {   firstName = value; }
        }
        public string lastName
        {
            get
            {   return lastName;}
            set
            {   lastName = value; }
        }
        public char gender             
        {
            get
            {   return gender; }
            set
            {   gender = value; }
        }

        public string birthDate
        {
            get
            {   return birthDate; }
            set
            {   birthDate = value; }
        }

        public string slot
        {
            get
            {   return slot; }
            set
            {   slot = value; }
        }*/

    }
    class Seniors : registration
    {
        string firstName;                       // Y having these here ???
        string lastName;                        // They can be taken in registration class. ABOVE
        char gender;
        string birthDate;

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
    }
    class Adults : registration
    {

    }
    class Children : registration
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            registration register = new registration();
            Console.WriteLine("\tDental Clinic");
            Console.WriteLine("1. To List of patients with details");
            Console.WriteLine("2. To Create a Schedule");
            Console.WriteLine("3. To view Day's Schedule and Perform Tasks");
            Console.Write("\tEnter your choice from above: ");
            int mainopt = int.Parse(Console.ReadLine());

            switch (mainopt)
            {
                case 1:
                    {
                        Console.WriteLine("Patient Number: {0}",register.patientNumber);
                        Console.Write("Full Name: {0} ",register.firstName);     //Full Name: First Last (Both in single line)
                        Console.WriteLine(register.lastName);
                        Console.WriteLine("Gender: {0}", (register.gender == 'M' ? "Male" : "Female") );
                        Console.WriteLine("Birth Date: {0}", register.birthDate);
                        Console.WriteLine("Slot: {0}", register.slot);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("4. Veneers Fitted");
                        Console.Write("Select option No: ");
                        int servicetype = int.Parse(Console.ReadLine());

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
        }
    }
}
