using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator
{
    interface IRequestHandler
    {
        void Handle();
    }

    class Controller : IRequestHandler
    {
        public void Handle()
        {
            Console.WriteLine("Process in controller. Return Response.");
        }
    }

    abstract class RequestMiddleware : IRequestHandler
    {
        protected IRequestHandler _next;

        public RequestMiddleware(IRequestHandler next)
        {
            this._next = next;
        }

        public virtual void Handle()
        {
            if (this._next != null)
            {
                this._next.Handle();
            }
        }
    }

    class LoggingMiddleware : RequestMiddleware
    {
        public LoggingMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("Started Logging.");
            base.Handle();
            Console.WriteLine("Ended Logging.");
        }
    }

    class CachingMiddleware : RequestMiddleware
    {
        public CachingMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("Response cached.");
        }
    }

    class AuthMiddleware : RequestMiddleware
    {
        public AuthMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("Authentication checked.");
            base.Handle();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IRequestHandler handler = new LoggingMiddleware(new CachingMiddleware(new AuthMiddleware(new Controller())));

            handler.Handle();
        }
    }
}