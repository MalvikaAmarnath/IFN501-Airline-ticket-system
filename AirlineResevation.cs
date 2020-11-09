using System;
using static System.Console;

namespace Passengers
{
    class Passenger
    {
        static Passenger[] passenger = new Passenger[40];
        int security_number;
        string name;
        int seat_number;
        DateTime timeStamp;
        static int count = 0;

        public Passenger()
        {

        }

        static void Main(string[] args)
        {
            DisplayInstructions();
            GetPassengerDetails();
            DisplayResults();
        }

        public static void DisplayInstructions()
        {
            Console.WriteLine("Welcome to Passenger reservation system!!!!");
            Console.WriteLine("This is an application to book tickets!!!");
        }

        public static void GetPassengerDetails()
        {

            Console.WriteLine("Please enter the number of passengers: ");
            string str = ReadLine();
            int num = Convert.ToInt32(str);
            string str1 = "";

            if (num <= (40 - count))
            {
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("Enter name of " + (i + 1) + " passenger:");
                    str1 = Console.ReadLine();
                    while (str1.Length > 5)
                    {
                        Console.WriteLine("Name must not be longer than 5 characters!!!");
                        Console.WriteLine("Enter name of " + (i + 1) + " passenger:");
                        str1 = Console.ReadLine();
                    }
                    Random random = new Random();
                    passenger[count] = new Passenger();
                    passenger[count].name = str1;
                    passenger[count].seat_number = count + 1;
                    passenger[count].timeStamp = DateTime.Now;
                    passenger[count].security_number = random.Next(30000, 999999);
                    count = count + 1;
                }
                Console.WriteLine("Remaining seats: " + (40 - count));
                GetPassengerDetails();
                Console.ReadKey();
            }
            else if (count < 40)
            {
                Console.WriteLine("Please select seats lesser than the available seats!");
                GetPassengerDetails();
            }
            else
            {
                Console.WriteLine("No seats are available!");
                Console.WriteLine("check-in is completed!!");
            }
        }

        public static void DisplayResults()
        {
            for (int j = 0; j < 40; j++)
            {
                Console.WriteLine("Passenger details: ");
                Console.WriteLine("Name of Passenger: " + passenger[j].name);
                Console.WriteLine("Seat Number: " + passenger[j].seat_number);
                Console.WriteLine("Date and Time of Reservation: " + passenger[j].timeStamp);
                Console.WriteLine("Security Number: " + passenger[j].security_number);
            }
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

