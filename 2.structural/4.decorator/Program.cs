using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator
{
    interface IStringDecorator
    {
        string Decorate(string s);
    }

    abstract class StringDecorator : IStringDecorator
    {
        protected IStringDecorator _next;

        public StringDecorator(IStringDecorator next)
        {
            this._next = next;
        }
        
        public StringDecorator()
        {
        }

        public virtual string Decorate(string s)
        {
            if (this._next != null)
            {
                return this._next.Decorate(s);
            }

            return s;
        }
    }

    class BoldDecorator : StringDecorator
    {
        public BoldDecorator(IStringDecorator next) : base(next)
        {
        }

        public BoldDecorator()
        {
        }

        public override string Decorate(string s)
        {
            return "<b>" + base.Decorate(s) + "</b>";
        }
    }

    class ItalicDecorator : StringDecorator
    {
        public ItalicDecorator(IStringDecorator next) : base(next)
        {
        }

        public ItalicDecorator()
        {
        }

        public override string Decorate(string s)
        {
            return "<i>" + base.Decorate(s) + "</i>";
        }
    }

    class UnderlineDecorator : StringDecorator
    {
        public UnderlineDecorator(IStringDecorator next) : base(next)
        {
        }

        public UnderlineDecorator()
        {
        }

        public override string Decorate(string s)
        {
            return "<u>" + base.Decorate(s) + "</u>";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((new BoldDecorator(new ItalicDecorator(new UnderlineDecorator()))).Decorate("String One"));

            Console.WriteLine((new ItalicDecorator(new BoldDecorator(new UnderlineDecorator()))).Decorate("String Two"));

            Console.WriteLine((new UnderlineDecorator(new BoldDecorator(new ItalicDecorator()))).Decorate("String Three"));

            Console.WriteLine((new ItalicDecorator(new BoldDecorator())).Decorate("String Four"));

            Console.WriteLine((new ItalicDecorator()).Decorate("String Five"));
        }
    }
}