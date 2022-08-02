using System;

namespace DesignPatterns.Creational.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = null;
            Console.Write("Enter the company (1. Hero, 2. Honda): ");
            string companyId = Console.ReadLine();
            switch (companyId.ToLower())
            {
                case "1":
                    factory = new HeroFactory();
                    break;
                case "2":
                    factory = new HondaFactory();
                    break;
                default:
                    break;
            }

            var testRunner = new VehicleTestRunner(factory);

            Console.Write("Enter vehicle type (1. Scooter, 2. Bike): ");
            string vehicleType = Console.ReadLine();

            Console.WriteLine("");

            switch (vehicleType.ToLower())
            {
                case "1":
                    testRunner.RunScooter();
                    break;
                case "2":
                    testRunner.RunBike();
                    break;
                default:
                    break;
            }
        }
    }

    class VehicleTestRunner
    {
        Bike bike;
        Scooter scooter;
        
        public VehicleTestRunner(VehicleFactory factory)
        {
            bike = factory.GetBike();
            scooter = factory.GetScooter();
        }

        public void RunScooter()
        {
            Console.WriteLine("Going in test run: ");
            Console.WriteLine("Model: " + scooter.Model());
            scooter.SelfStart();
            scooter.Go();
        }

        public void RunBike()
        {
            Console.WriteLine("Going in test run: ");
            Console.WriteLine("Model: " + bike.Model());
            bike.KickStart();
            bike.Go();
        }
    }

    interface VehicleFactory
    {
        Bike GetBike();
        Scooter GetScooter();
    }

    class HondaFactory : VehicleFactory
    {
        public Bike GetBike()
        {
            return new HondaBike();
        }

        public Scooter GetScooter()
        {
            return new HondaScooter();
        }
    }

    class HeroFactory : VehicleFactory
    {
        public Bike GetBike()
        {
            return new HeroBike();
        }

        public Scooter GetScooter()
        {
            return new HeroScooter();
        }
    }

    interface Vehicle
    {
        string Model();
        void Go();
    }

    interface Bike: Vehicle
    {
        void KickStart();
    }

    interface Scooter: Vehicle
    {
        void SelfStart();
    }

    class HeroBike : Bike
    {
        public string Model()
        {
            return "Hero Splendor";
        }

        public void KickStart()
        {
            Console.WriteLine("Kick 3 times.");
        }

        public void Go()
        {
            Console.WriteLine("Vot vot vot.");
        }
    }

    class HondaBike : Bike
    {
        public string Model()
        {
            return "Honda CD 110";
        }

        public void KickStart()
        {
            Console.WriteLine("Kick 2 times.");
        }

        public void Go()
        {
            Console.WriteLine("Bot bot bot.");
        }
    }

    class HondaScooter : Scooter
    {
        public string Model()
        {
            return "Honda Dio";
        }

        public void SelfStart()
        {
            Console.WriteLine("Press 3 times.");
        }

        public void Go()
        {
            Console.WriteLine("um. um. um. um.");
        }
    }

    class HeroScooter : Scooter
    {
        public string Model()
        {
            return "Hero Pleasure";
        }

        public void SelfStart()
        {
            Console.WriteLine("Press 2 times.");
        }

        public void Go()
        {
            Console.WriteLine("um. umm. ummm. ummmm. boom.");
        }
    }
}