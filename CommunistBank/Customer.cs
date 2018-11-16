using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliottCommunistBank
{

    class Customer
    {

        public int balance { get; set; }
        public string name { get; set; }
        public List<Transaction> transactionsList { get; set; } = new List<Transaction>();

        public static void ShowCustomer(int iCount)
        {
            // iCount + 1 because of user interface. List shows first customer as number 0, but we want
            // want the user to see the first customer as number 1
            Console.WriteLine("Customer " + (iCount + 1) + ": " + Program.customerList[iCount].name);
        }

        public static void RegisterTransaction(int money, Customer customer)
        {
            customer.balance += money; // adds the money to customers balance
            Transaction transaction = new Transaction();// creates an transaction object that registers money and time
            transaction.transactionMoney = money;
            transaction.transactionTime = DateTime.Now.ToShortTimeString();
            customer.transactionsList.Add(transaction); // saves the current transaction to the customer transaction list
        }

    }


}
