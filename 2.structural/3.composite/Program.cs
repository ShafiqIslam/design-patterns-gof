using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite
{
    interface IResizable
    {
        void Resize();
    }

    class Header : IResizable
    {
        public void Resize()
        {
            Console.WriteLine("Header resized.");
        }
    }

    class Footer : IResizable
    {
        public void Resize()
        {
            Console.WriteLine("Footer resized.");
        }
    }

    class Column : IResizable
    {
        public void Resize()
        {
            Console.WriteLine("Column resized.");
        }
    }

    class Body : IResizable
    {
        protected List<Column> _columns = new List<Column>();

        public Body AddColumn(Column column) 
        {
            this._columns.Add(column);
            return this;
        }

        public void Resize()
        {
            int i = 0;
            foreach (Column column in this._columns)
            {
                Console.Write("Resizing Column " + i++ + ": ");
                column.Resize();
            }
            Console.WriteLine("Body resized.");
        }
    }

    class Layout : IResizable
    {
        protected List<IResizable> _elements = new List<IResizable>();

        public Layout Add(IResizable element) 
        {
            this._elements.Add(element);
            return this;
        }

        public void Resize()
        {
            foreach (IResizable element in this._elements)
            {
                element.Resize();
                Console.WriteLine();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Layout layout = new Layout();

            Header header = new Header();
            Body body = (new Body()).AddColumn(new Column()).AddColumn(new Column()).AddColumn(new Column());
            Footer footer = new Footer();

            layout.Add(header).Add(body).Add(footer);

            layout.Resize();
        }
    }
}