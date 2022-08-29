using System;

namespace DesignPatterns.Creational.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            GordonRamsey waiter = new GordonRamsey();

            Console.Write("Enter pizza type (1. Hawaiian, 2. Spicy): ");
            string pizzaType = Console.ReadLine();

            Console.WriteLine("");

            switch (pizzaType.ToLower())
            {
                case "1":
                    Console.WriteLine(waiter.MakePizza(new HawaiianPizzaBuilder()));
                    break;
                case "2":
                    Console.WriteLine(waiter.MakePizza(new SpicyPizzaBuilder()));
                    break;
                default:
                    break;
            }
        }
    }

    class GordonRamsey 
    {
        public Pizza MakePizza(PizzaBuilder pb) 
        {
            pb.BuildDough();
            pb.BuildSauce();
            pb.BuildTopping();
            return pb.GetPizza();
        }
    }

    class Pizza 
    {
        private String _Type;
        public String Dough { get; set; }
        public String Sauce { get; set; }
        public String Topping { get; set; }

        public Pizza(string type) 
        {
            _Type = type;
        }

        public override string ToString()
        {
            return _Type + " pizza built with: " + Dough + ", " + Sauce + ", " + Topping;
        }
    }

    abstract class PizzaBuilder 
    {
        protected Pizza pizza;
        
        public PizzaBuilder(string type)
        {
            pizza = new Pizza(type);
        }

        public Pizza GetPizza() 
        {
            return pizza;
        }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }
    
    class HawaiianPizzaBuilder: PizzaBuilder 
    {
        public HawaiianPizzaBuilder() : base("Hawaiian")
        {
        }

        public override void BuildDough() 
        {
            pizza.Dough = "cross";
        }

        public override void BuildSauce() 
        {
            pizza.Sauce = "mild";
        }

        public override void BuildTopping()
         {
            pizza.Topping = "ham+pineapple";
        }
    }

    class SpicyPizzaBuilder: PizzaBuilder 
    {
        public SpicyPizzaBuilder() : base("Spicy")
        {
        }

        public override void BuildDough() 
        {
            pizza.Dough = "pan baked";
        }

        public override void BuildSauce() 
        {
            pizza.Sauce = "hot";
        }

        public override void BuildTopping() 
        {
            pizza.Topping = "pepperoni+salami";
        }
    }
}