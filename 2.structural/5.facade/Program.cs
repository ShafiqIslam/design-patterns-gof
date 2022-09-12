using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            Mortgage mortgage = new Mortgage(bank);

            Customer customer1 = new Customer("John Doe");
            customer1.AddBalance(bank, 100000);
            mortgage.CheckEligibilty(customer1, 125000);

            Console.WriteLine();

            Customer customer2 = new Customer("Jane Doe");
            customer2.AddBalance(bank, 200000);
            mortgage.CheckEligibilty(customer2, 150000);
        }
    }
    
    public class Customer
    {
        private string name;
        
        public Customer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public void AddBalance(Bank bank, int amount)
        {
            bank.AddBalance(this, amount);
        }
    }
    
    public class Mortgage
    {
        Loan loan = new Loan();
        Credit credit = new Credit();
        private Bank _bank;

        public Mortgage(Bank bank)
        {
            this._bank = bank;
        }

        public bool IsEligible(Customer customer, int amount)
        {
            Console.WriteLine("{0} applies for loan amount: {1}", customer.Name, amount);
            
            if (!_bank.HasSufficientSavings(customer, amount))
            {
                return false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                return false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                return false;
            }

            return true;
        }

        public void CheckEligibilty(Customer customer, int amount)
        {
            bool eligible = IsEligible(customer, amount);
            Console.WriteLine(customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }
    
    public class Bank
    {
        private Dictionary<string, int> _balances = new Dictionary <string, int> ();

        public void AddBalance(Customer c, int amount)
        {
            if (_balances.ContainsKey(c.Name)) 
            {
                _balances[c.Name] += amount;
            } 
            else 
            {
                _balances[c.Name] = amount;
            }
        }

        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return _balances[c.Name] >= amount;
        }
    }
    
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }
    
    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }
}