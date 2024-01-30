using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please select one of the following options...");
                Console.WriteLine("(1). Deposit");
                Console.WriteLine("(2). Withdraw");
                Console.WriteLine("(3). Show balance");
                Console.WriteLine("(4). Exit immediatly");
            }

            void deposit(CardHolder CurrentUser)
            {
                Console.WriteLine ("How much $$ would you like to deposit? ");
                double Deposit = Double.Parse(Console.ReadLine());
                CurrentUser .setBalance(Deposit);
                Console.WriteLine("Your current balance is:"+ CurrentUser.getbalance());
            }

            void withdraw(CardHolder CurrentUser)
            {
                Console.WriteLine("How much $$ would you like to withdraw:");
                double Withdraw = Double.Parse(Console.ReadLine());
                //check if the user has enough money.
                if (CurrentUser .getbalance ()> Withdraw)
                {
                    Console.WriteLine("Insufficient balance:");
                }
                   else
                {
                    CurrentUser.setBalance(CurrentUser.getbalance() - Withdraw);
                    Console.WriteLine("You are good to go .Thank You");
                }
            }

            void balance (CardHolder CurrentUser)
            {
                Console.WriteLine("Current balance :" + CurrentUser.getbalance());
            }


            List <CardHolder> CardHolders = new List<CardHolder>();
            CardHolders.Add(new CardHolder("11223344555", 1234, "Belal", "Saied", 150.33));
            CardHolders.Add(new CardHolder("11223344666", 1235, "Hazem", "Yasser", 1560.33));
            CardHolders.Add(new CardHolder("11223344777", 1236, "Mohamed", "Ali", 617.83));
            CardHolders.Add(new CardHolder("11223344888", 1237, "Rawda", "Ashraf", 990.03));
            CardHolders.Add(new CardHolder("11223344999", 1238, "Mariem", "Essam", 810.43));
            //prompt user:

            Console.WriteLine("Welcome to our ATM");
            Console.WriteLine("Please insert your debit card:");
                string debitCardNum = "";
            CardHolder currentUser;

            while (true)
            {
                try
                {
                 debitCardNum = Console.ReadLine();
                    //catch against our db:
                    currentUser = CardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized . please try again"); }
                }
                catch { Console.WriteLine("Card not recognized . please try again"); }
            }


            Console.WriteLine("Please enter your pin:");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin =int . Parse (Console.ReadLine());
                    if (currentUser.getPin() ==userPin){ break; }
                    else { Console.WriteLine("Incorrect Pin . please try again"); }

                }
                catch { Console.WriteLine("Incorrect Pin . please try again"); }
            }

            Console.WriteLine("Welcome" + currentUser.getFirstname() + ":)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
               else if (option==2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option= 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you!have a nice day:");
        }
    }
    public class CardHolder
    {
        string CardNum;
        int pin;
        string firstname;
        string lastname;
        double balance;

        public CardHolder (string CardNum,int pin,string firstname, string lastname ,double balance)
        {
            this.CardNum = CardNum;
            this.pin = pin;
            this.firstname = firstname;
            this.lastname = lastname;
            this.balance = balance;

        }

        public string getNum()
        {
            return CardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public string getLastname()
        {
            return lastname;
        }

        public string getFirstname()
        {
            return firstname;
        }

        public double getbalance()
        {
            return balance;
        }

        public void setNum(string newCardNum)
        {
            CardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName (string newFirstName)
        {
            firstname = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastname = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance =newBalance;
        }


    }
}
