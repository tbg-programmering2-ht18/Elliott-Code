using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliottCommunistBank
{


    class Program
    {

        public static List<Customer> customerList = new List<Customer>(); // The list that contains all customers
        static void Main(string[] args)
        {
            var arr = new[]
{
                    @" __      __             .__                                  ",
                    @"/  \    /  \ ____  ____ |  |   ____  ____   _____   ____     ",
                    @"\   \/\/   // __ \/  _ \|  | _/ ___\/  _ \ /     \_/ __ \    ",
                    @" \        /\  ___(  <_> )  |_\  \__(  <_> )  Y Y  \  ___ /    ",
                    @"  \__/\  /  \___  >____/|____/\___  >____/|__|_|  /\___  >     ",
                    @"       \/       \/                \/            \/     \/      ",
            };

            foreach (string line in arr)
                Console.WriteLine(line);
            Console.WriteLine("                   To ElliottCommunistBank");


            bool exitLoop = false;
            // This loop contains the whole program, break it and the program ends sara knasar
            while (exitLoop == false)
            {
                try
                {
                    ShowMeny();
                    int tempIntAns = int.Parse(Console.ReadLine()); // User selects action
                    Console.Clear();

                    switch (tempIntAns)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("- A D D  C U S T O M E R -");
                                Console.WriteLine("--------------------------");

                                AddCustomer();
                                Console.WriteLine("Would you like to add another customer [Y]es or [N]o?");
                                string tempStringAns = Console.ReadLine();
                                if (tempStringAns == "Y" || tempStringAns == "y")
                                {
                                    // Continue the loop
                                }
                                else if (tempStringAns == "N" || tempStringAns == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Pleas enter a correct answer [Y] or [N]");
                                    break;
                                }
                                Console.Clear();
                            }

                            break;
                        case 2:
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("- S H O W  C U S T O M E R -");
                            Console.WriteLine("----------------------------");

                            ShowAlCustomers();
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("- S H O W  B A L A N C E -");
                            Console.WriteLine("--------------------------");

                            ShowAlCustomers();
                            Console.WriteLine("For what customer would you like to see the balance, pleas enter a numerical answer");
                            tempIntAns = int.Parse(Console.ReadLine());
                            // If the customer has no money on it's account then tell that to the user
                            if (customerList[tempIntAns - 1].balance == 0)
                            {
                                Console.WriteLine("The customer has no money in their account");
                            }
                            else
                            {
                                // Show the balance for the desired customer
                                Console.WriteLine("The customer has " + customerList[tempIntAns - 1].balance + " on their account");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("- M A K E  A  D E P O S I T -");
                            Console.WriteLine("-----------------------------");

                            ShowAlCustomers();
                            Console.Write("for what customer? Pleas enter a numerical answer");
                            tempIntAns = int.Parse(Console.ReadLine());
                            // Now we can call the desired customer for "customer" rather than it's index
                            Customer customer = customerList[tempIntAns - 1];
                            Console.Write("How much money?... ");
                            tempIntAns = int.Parse(Console.ReadLine());

                            // Only register transaction if the sum is bigger or smaller then 0, for that is no transaction.
                            if (tempIntAns == 0)
                            {
                                Console.WriteLine("That's no sum");
                                // Program will jump to finally statement and then user can try again
                            }

                            else if (tempIntAns > 0)
                            {
                                Customer.RegisterTransaction(tempIntAns, customer);
                                Console.WriteLine("The depostit was succesfull");

                            }

                            else if (tempIntAns < 0)
                            {
                                Customer.RegisterTransaction(tempIntAns, customer);
                                Console.WriteLine("You made an extraction of " + tempIntAns + "from the customer " + customer.name);
                            }
                            break;

                        case 5:
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("- S H O W  T R A N S A C T I O N S -");
                            Console.WriteLine("------------------------------------");

                            ShowAlCustomers();
                            Console.Write("For what customer would you like to see the transactions? Pleas enter a numerical answer");
                            tempIntAns = int.Parse(Console.ReadLine());
                            // Now we can call the desired customer for simply "customer" rather than it's index
                            customer = customerList[tempIntAns - 1];
                            // The amount of transaction that the customer has
                            int n = customer.transactionsList.Count();
                            if(n == 0)
                            {
                                Console.WriteLine("This customer has made no transactions");
                                break;
                            }
                            // Let's show all of the "transaction" objects and its attributes (money and time) for the current customer 
                            for (int i = 0; i <= n - 1; i++)//it will loop as many times as the customer has done an transactions
                            {
                                //Writes the registered amount of money and the register time in the transaction list fot the selected customer
                                Console.WriteLine(customer.transactionsList[i].transactionMoney + " $ at time " + customer.transactionsList[i].transactionTime);
                            }
                            Console.ReadLine();

                            break;
                        case 6:
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("- D E L E T E  C U S T O M E R -");
                            Console.WriteLine("--------------------------------");
                            ShowAlCustomers();
                            Console.WriteLine("what customer would you like to remove, pleas write a numerical answer");
                            tempIntAns = int.Parse(Console.ReadLine());
                            string tempNameHolder = customerList[tempIntAns - 1].name; // The Name of the customer will be used after the removal... so let's save it
                            customerList.RemoveAt(tempIntAns - 1);
                            Console.WriteLine("The removal of the customer " + tempNameHolder + " was succesful"); // Here we are using the name we temporarily saved
                            Console.ReadLine();
                            break;
                        case 7:
                            exitLoop = true; // this will break the loop and end the program
                            Console.WriteLine("Thank you for visiting");
                            System.Threading.Thread.Sleep(1000);

                            break;


                    }
                }

                // Exception Handling
                catch (FormatException e)
                {
                    // The format is wrong
                    Console.Write("Pleas enter a numerical answer ");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    // User has writen a numerical number that is to big/small, does not exist
                    Console.Write("Pleas enter an existing customer number ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    // This will always be seen, unless the user wants to exit the program
                    if (exitLoop != true)
                    { 
                        Console.Write("You will be returned to the starting meny");
                        ProgramWait();
                        Console.Clear();
                    }

                }

            }




        }
        // Functions...

        // Function 1: creates a customer object and gives it
        // a name. Then adds it to the customerlist
        public static void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter customers name: ");
            string customerName = Console.ReadLine();
            customer.name = customerName; // deklaring it's name
            customerList.Add(customer);
            Console.Write("");

        }

        // Function 2: uses the funktion "ShowCustomer" in the Customer Class and 
        // repeats it until it has shown all customer in the customerList has been showed
        public static void ShowAlCustomers()
        {
            int iCount = 0;
            foreach (var Customer in customerList)
            {
                Customer.ShowCustomer(iCount);
                iCount++;
            }
        }

        // Function : Makes the program wait for 6 seconds, while playing a simple animation
        public static void ProgramWait()
        {
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }



        // Function 4: Shows the main meny
        public static void ShowMeny()
        {
            string time = DateTime.Now.ToShortTimeString();
            Console.WriteLine(time);
            Console.WriteLine("");
            Console.WriteLine("1: Add customer");
            Console.WriteLine("2: Show customer");
            Console.WriteLine("3: Show balance for a customer");
            Console.WriteLine("4: Make a deposit to a customer");
            Console.WriteLine("5: Show transactions for a customer");
            Console.WriteLine("6: Delete a customer");
            Console.WriteLine("7: Exit Bank");
            Console.WriteLine("");
            Console.Write("Choose an option, pleas enter a numerical answer: ");
        }


    }
}
