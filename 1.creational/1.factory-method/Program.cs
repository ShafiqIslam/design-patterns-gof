using System;

namespace DesignPatterns.Creational.FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = null;
            Console.Write("Enter your department (1. Finance, 2. IT): ");
            string departmentId = Console.ReadLine();
            switch (departmentId.ToLower())
            {
                case "1":
                    department = new FinanceDepartment();
                    break;
                case "2":
                    department = new ITDepartment();
                    break;
                default:
                    break;
            }

            Console.Write("Enter your ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            department.fire(employeeId);
        }
    }

    abstract class Employee 
    {
        public abstract void paySalary();
        public abstract void dismiss();
    }

    class Programmer : Employee 
    {
        public Programmer(int id) { }

        public override void paySalary()
        {
            Console.WriteLine("Your due salary is: 20000");
        }

        public override void dismiss()
        {
            Console.WriteLine("You make shit. You are fired.");
        }
    }

    class Accountant : Employee 
    {
        public Accountant(int id) { }

        public override void paySalary()
        {
            Console.WriteLine("Your due salary is: 100000");
        }

        public override void dismiss()
        {
            Console.WriteLine("You can't clean shit. You are fired.");
        }
    }

    abstract class Department 
    {
        public abstract Employee createEmployee(int id);

        public void fire(int id) 
        {
            var employee = this.createEmployee(id);
            employee.paySalary();
            employee.dismiss();
        }
    }

    class ITDepartment : Department 
    {
        public override Employee createEmployee(int id)
        {
            return new Programmer(id);
        }
    }

    class FinanceDepartment : Department 
    {
        public override Employee createEmployee(int id)
        {
            return new Accountant(id);
        }
    }
}