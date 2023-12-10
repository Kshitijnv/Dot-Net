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
            while (!exit)
            {
                try

                {
                    Console.WriteLine("Enter the choice:"
                            + "\n1)Open Account \n2)Get Account Sumamry \n3)Withdraw \n4)Deposit \n5)Exit");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Enter your name, account type(Saving/Current), balance(optional)");
                            string name = Console.ReadLine();
                            string type = Console.ReadLine().ToUpper();
                            //Parsing the input string INTO enum type
                            if (!Enum.IsDefined(typeof(AccountType), type))
                                throw new ArgumentException("Invalid Account type");

                            AccountType type1 = (AccountType)Enum.Parse(typeof(AccountType), type);
                            decimal bal = Convert.ToDecimal(Console.ReadLine());
                            BankAccount acc1 = new BankAccount(name, type1, bal);
                            list.Add(acc1.AccountNum, acc1);
                            Console.WriteLine($"Your Account Number is {acc1.AccountNum}");

                            break;
                        case 2:
                            Console.WriteLine("Enter account Number");
                            int num = Convert.ToInt32(Console.ReadLine());
                            //BankAccount acc = list.GetValueOrDefault(num);

                            if (list.ContainsKey(num))
                            {
                                BankAccount bankAccount = list[num];
                                Console.WriteLine(bankAccount);
                            }else
                                Console.WriteLine("No Bank Account available with this Account Number!!!");
                            break;
                        case 3:
                            Console.WriteLine("Enter the Account number to withdraw : ");
                            num = Convert.ToInt32(Console.ReadLine());
                            if (!list.ContainsKey(num))
                                throw new BankAccountException("No Bank Account available with this Account Number!!!");

                             Console.WriteLine("Enter amount to be withdraw : ");
                            decimal amt = Convert.ToDecimal(Console.ReadLine());
                            BankAccount acct = list[num];

                            if (acct.Balance < amt)
                                throw new BankAccountException("Balance is too low!!!");
                            acct.Balance -= amt;
                            
                            Console.WriteLine($"Amount {amt} is withdrawn!!!!");
                            Console.WriteLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter the Account number to deposit : ");
                            num = Convert.ToInt32(Console.ReadLine());
                            if (!list.ContainsKey(num))
                                throw new BankAccountException("No Bank Account available with this Account Number!!!");

                            Console.WriteLine("Enter amount to be deposit : ");
                             amt = Math.Abs(Convert.ToDecimal(Console.ReadLine()));
                             acct = list[num];
                            acct.Balance += amt;
                            Console.WriteLine($"Amount {amt} is deposited!!!!");
                            Console.WriteLine($"Your updated balance is : {acct.Balance}");
                            break;
                        case 5:
                            exit = true;
                            break;
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    public enum AccountType
    {
        SAVING, CURRENT
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
        public BankAccount(string name, AccountType type, decimal bal = 0)
        {
            this.AccountNum = ++idGenerator;
            this.Name = name;
            this.Type = type;
            this.Balance = bal;
        }

        public override string ToString()
        {
            return $"BankAccount[AccountNumber = {AccountNum},Name = {Name},Account type = {Type}, Current Balance = {Balance} ";
        }
    }
}