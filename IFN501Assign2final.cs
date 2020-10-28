// IFN501 Assignment 2
// Name: Malvika Amarnath
// StudentID: N9519661
using System;
using static System.Console;
namespace assignment2
{
    class cashless
    {
        public static void Main(string[] args)

        {

            double totalPrice = 0;
            int totalItems = 0;
            double discountPrice = 0;
            int cardNum;
            string cardNumString;
            const int DIGITS = 4;
            int firstThree;
            int lastOne;
            const int CHECK_FACTOR = 7;
            int remainder;
            string inputString = "";

            //Checking if the name and price entered is valid
            while (inputString != "no")
            {
                double price = -1;

                string nameOfItem;
                int nameOfItemLength = 10;

                inputString = "";
                while (nameOfItemLength >= 8)
                {

                    WriteLine("Enter name of the item");
                    nameOfItem = ReadLine();
                    nameOfItemLength = nameOfItem.Length;
                    if (nameOfItemLength >= 8)
                    {
                        WriteLine("Name of item should be less than 8 characters");
                    }
                }
                while (price <= 0)
                {
                    WriteLine("Enter price of item");
                    price = Convert.ToDouble(ReadLine());
                    if (price <= 0)
                        WriteLine("Price must be a number and greater than 0 ");
                }

                //Calculates the total number of items and its cost
                WriteLine("Valid item name and price");
                totalItems += 1;

                totalPrice += price;




                WriteLine("Enter 'no' to stop adding items or press any key and enter to continue>>");
                inputString = ReadLine();
                if (inputString == "no")
                {
                    WriteLine("Thank you!");
                    WriteLine("Proceed to payments");

                }
            }

            //calculates discounts if the following conditions are true
            if (totalPrice < 100)
                discountPrice = totalPrice;

            else if (totalPrice >= 100 && totalPrice <= 300)
                discountPrice = totalPrice - (0.015 * totalPrice);

            else if (totalPrice > 300)
                discountPrice = totalPrice - (0.025 * totalPrice);

            //payments using credit card and final invoice

            WriteLine("Enter a four-digit credit card number >> ");
            cardNumString = ReadLine();
            if (cardNumString.Length != DIGITS)
                WriteLine($"Credit card number invalid - it must have {DIGITS} digits");
            else
            {
                cardNum = Convert.ToInt32(cardNumString);
                firstThree = cardNum / 10;
                lastOne = cardNum % 10;
                remainder = firstThree % CHECK_FACTOR;
                if (lastOne == remainder)
                {
                    WriteLine($"Credit card is valid. Payment is accepted");

                    WriteLine("............FINAL INVOICE.............");
                    WriteLine("Total number of items purchased is {0}", totalItems);
                    WriteLine("Total cost of items purchased is ${0}", totalPrice);
                    WriteLine("The final discount price is ${0}", discountPrice);
                    WriteLine("The total amount is paid with $0.00 owed");
                }

                else
                {
                    WriteLine("Credit card is invalid. Payment not accepted ");

                    WriteLine("............FINAL INVOICE.............");
                    WriteLine("Total number of items is {0}", totalItems);
                    WriteLine("Total cost of items is ${0}", totalPrice);
                    WriteLine("The final discount price is ${0}", discountPrice);
                    WriteLine("The total amount owed is ${0} owed", discountPrice);
                }

            }


        }// end of main method
    }// end of class

}// end of namespace