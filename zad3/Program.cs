using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace zad3
{
    public enum AccountType
    {
        Savings,
        Checking,
        Giro
    }
    class Program
    {
        class BankAccount
        {
            public string IBAN { get; set; }
            public int balance { get; set; }
            public AccountType type { get; set; }


            private static readonly Regex rxNonDigits = new Regex(@"[^\d]+");

            public BankAccount(AccountType accountType)
            {
                IBAN = "HR32" + rxNonDigits.Replace(Guid.NewGuid().ToString("N"), "").Substring(0, 12);
                balance = 0;
                type = accountType;
            }
        }

        static void Main(string[] args)
        {
            List<BankAccount> bankAccountsList = new List<BankAccount>{
                new BankAccount(AccountType.Savings),
                new BankAccount(AccountType.Checking),
                new BankAccount(AccountType.Giro),
                new BankAccount(AccountType.Checking),
                new BankAccount(AccountType.Savings)
            };

            void printBankAccountsDetails (List<BankAccount> baList)
            {
                foreach (BankAccount ba in baList)
                {
                    Console.WriteLine(ba.IBAN);
                    Console.WriteLine(ba.balance.ToString("C0"));
                    Console.WriteLine(ba.type.ToString());
                }
            }

            void addNewBankAccount (List<BankAccount> baList, AccountType accountType)
            {
                baList.Add(new BankAccount(accountType));
                return ;
            }

            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("Unesite A za ispis racuna, B za upis novog i C za izlazak: ");
                
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    printBankAccountsDetails(bankAccountsList);
                }
                else if (Console.ReadKey().Key == ConsoleKey.B)
                {
                    Console.WriteLine("Unesite tip racuna: Giro, Savings, Checking");
                    string type = Console.ReadLine();
                    Enum.TryParse(type, out AccountType accountType);

                    addNewBankAccount(bankAccountsList, accountType);
                }

                else if (Console.ReadKey().Key == ConsoleKey.C)
                {
                    isRunning = false;
                }
            }

            Console.ReadKey();
        }
    }
}
