using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.ChainOfResposibility
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequestHandler handler = new LoggingMiddleware(new CachingMiddleware(new AuthMiddleware(new AuthController())));

            Console.WriteLine(handler.Handle(new Request("admin", "private")));
            Console.WriteLine();

            Console.WriteLine(handler.Handle(new Request("guest", "private")));
            Console.WriteLine();

            handler = new LoggingMiddleware(new CachingMiddleware(new GuestController()));

            Console.WriteLine(handler.Handle(new Request("admin", "public")));
            Console.WriteLine();

            Console.WriteLine(handler.Handle(new Request("guest", "public")));
            Console.WriteLine();

            Console.WriteLine(handler.Handle(new Request("admin", "public")));
            Console.WriteLine();

            Console.WriteLine(handler.Handle(new Request("guest", "public")));
        }
    }

    class Request 
    {
        public string User;
        public string Resource;

        public Request(string user, string resource)
        {
            this.User = user;
            this.Resource = resource;
        }

        public override string ToString()
        {
            return "user = " + this.User + ", resource = " + this.Resource;
        }

        public override int GetHashCode() 
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj) 
        {
            return Equals(obj as Request);
        }

        public bool Equals(Request req) 
        {
            return req != null && req.ToString() == this.ToString();
        }
    }
    
    class Response 
    {
        public string Message;

        public Response(string message)
        {
            this.Message = message;
        }

        public override string ToString()
        {
            return this.Message;
        }
    }

    interface IRequestHandler
    {
        Response Handle(Request request);
    }

    class AuthController : IRequestHandler
    {
        public Response Handle(Request request)
        {
            return new Response("Handled auth resource: " + request.Resource);
        }
    }

    class GuestController : IRequestHandler
    {
        public Response Handle(Request request)
        {
            return new Response("Handled guest resource: " + request.Resource);
        }
    }

    abstract class RequestMiddleware : IRequestHandler
    {
        protected IRequestHandler _next;

        public RequestMiddleware(IRequestHandler next)
        {
            this._next = next;
        }

        public virtual Response Handle(Request request)
        {
            if (this._next != null)
            {
                return this._next.Handle(request);
            }

            return new Response("No content");
        }
    }

    class LoggingMiddleware : RequestMiddleware
    {
        public LoggingMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override Response Handle(Request request)
        {
            Console.WriteLine("Started Logging of request: " + request);
            var res = base.Handle(request);
            Console.WriteLine("Ended Logging of request: " + request);
            return res;
        }
    }

    class CachingMiddleware : RequestMiddleware
    {
        Dictionary<Request, Response> cache = new Dictionary<Request, Response>();

        public CachingMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override Response Handle(Request request)
        {
            if (cache.ContainsKey(request))
            {
                Console.WriteLine("Get request: " + request + " from cache.");
                return cache[request];
            }

            var response = base.Handle(request);
            cache[request] = response;
            return response;
        }
    }

    class AuthMiddleware : RequestMiddleware
    {
        public AuthMiddleware(IRequestHandler next) : base(next)
        {
        }

        public override Response Handle(Request request)
        {
            if (request.User == "guest")
            {
                return new Response("Unauthenticated.");
            }

            return base.Handle(request);
        }
    }
}