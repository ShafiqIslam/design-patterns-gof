using System;
using System.Collections;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Iterator.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracker = new PageVisitTracker();
            
            tracker.Visit("https://refactoring.guru/design-patterns/iterator");
            tracker.Visit("https://learn.microsoft.com/en-us/dotnet/api/system.collections.stack");
            tracker.Visit("https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable");

            printPages(tracker);

            Console.WriteLine();
            Console.WriteLine("Close last page: " + tracker.Undo());
            Console.WriteLine();

            printPages(tracker);
        }

        private static void printPages(PageVisitTracker tracker)
        {
            Console.WriteLine("Current open pages:");
            foreach (var url in tracker)
            {
                Console.WriteLine(url);
            }
        }
    }

    class PageVisitTracker : IEnumerable
    {
        Stack<string> _urls = new Stack<string>();
        
        public void Visit(string url)
        {
            this._urls.Push(url);
        }

        public string Undo()
        {
            return this._urls.Pop();
        }
        
        public IEnumerator GetEnumerator()
        {
            return new HistoryIterator(this._urls);
        }

        public class HistoryIterator : IEnumerator
        {
            private int _position = -1;
            Stack<string> _urls;

            public HistoryIterator(Stack<string> urls)
            {
                this._urls = urls;
            }
            
            public bool MoveNext()
            {
                _position++;
                return _position < this._urls.Count;
            }

            public void Reset()
            {
                _position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public string Current
            {
                get
                {
                    int i = 0;
                    foreach (var item in this._urls)
                    {
                        if (i == _position) return item;
                        i++;
                    }
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}