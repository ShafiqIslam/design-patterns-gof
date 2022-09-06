using System;

namespace DesignPatterns.Structural.Adapter
{
    class Dingi
    {
        public void Row()
        {
            Console.WriteLine("Row, row, row your boat, Gently down the stream.");
        }
    }

    interface IBoatWithHelm 
    {
        void Steer();
    }

    class PirateShip: IBoatWithHelm
    {
        public void Steer()
        {
            Console.WriteLine("Yo ho ho and a bottle of rum.");
        }
    }

    class Captain 
    {
        public IBoatWithHelm Ship;

        public void Sail() 
        {
            Ship.Steer();
        }
    }

    class DingiAdapter: IBoatWithHelm 
    {
        private Dingi boat = new Dingi();

        public void Steer() 
        {
            boat.Row();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Captain jackSparrow = new Captain();
            PirateShip blackPearl = new PirateShip();
            jackSparrow.Ship = blackPearl;

            Console.WriteLine("Jack Sparrow sailing Black Pearl.");
            jackSparrow.Sail();

            try 
            {
                jackSparrow.Ship = (IBoatWithHelm) new Dingi();
                jackSparrow.Sail();
            }
            catch
            {
                Console.WriteLine("\nJack Sparrow can not sail dingi.\n");
            }

            jackSparrow.Ship = new DingiAdapter();
            jackSparrow.Sail();
            Console.WriteLine("Now he can.");
        }
    }
}