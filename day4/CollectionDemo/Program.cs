using System.Collections;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace CollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, BankAccount> list = new SortedList<int, BankAccount>();
            Boolean exit = false;
            while (!exit) { 
                try
                {
                    Console.WriteLine("Enter the choice:"
                            + "\n1)Open Account \n2)Get Account Sumamry \n3)Withdraw \n4)Deposit");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Enter your name, account type, ");
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                            case 5:
                            exit = true;
                            break;
                    }
                    
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    public enum AccountType
    {
        SAVING,CURRENT
    }

    internal class BankAccount
    {
        //property1: Bank account number
        public int AccountNum { get; set; }
        //property2: Name
        public string Name { get; set; }

        //property3: Account type
        public AccountType Type { get; set; }

        //property4: Balance
        public decimal Balance { get; set; }
        private static int idGenerator = 0;
        public BankAccount(string name,AccountType type,decimal bal)
        {
            this.AccountNum = ++idGenerator;
            this.Name = name;
            this.Type = type;
            this.Balance = bal;
        } 
    }
}