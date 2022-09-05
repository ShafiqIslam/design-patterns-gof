using System;

namespace DesignPatterns.Creational.Builder 
{

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            Person p2 = (Person) p1.ShallowCopy();
            Person p3 = (Person) p1.DeepCopy();

            Console.WriteLine("Original values:");
            Console.WriteLine("   p1: ");
            Console.WriteLine(p1);
            Console.WriteLine("   p2:");
            Console.WriteLine(p2);
            Console.WriteLine("   p3:");
            Console.WriteLine(p3);

            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues after changes to p1:");
            Console.WriteLine("   p1: ");
            Console.WriteLine(p1);
            Console.WriteLine("   p2 (reference values have changed):");
            Console.WriteLine(p2);
            Console.WriteLine("   p3 (everything was kept the same):");
            Console.WriteLine(p3);
        }
    }

    interface Cloneable
    {
        Object ShallowCopy();
        Object DeepCopy();
    }

    public class Person: Cloneable
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Object ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Object DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }

        public override string ToString()
        {
            string str = "";
            str += $"      ID#: {IdInfo.IdNumber}";
            str += $"\n      Name: {Name}";
            str += $"\n      Age: {Age}";
            str += $"\n      BirthDate: {BirthDate.ToString("MM/dd/yy")}\n";
            return str;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
}