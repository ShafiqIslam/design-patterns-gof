using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Interpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("1 + (2 * 3) = ");
            Expression exp = new Add(
                new Digit(1),
                new Multiply(
                    new Digit(2), 
                    new Digit(3)
                )
            );

            Console.Write(exp.Evaluate());
            Console.WriteLine();


            Console.Write("{(9 / 3) + (2 * 4)} - [{(5 / 1) + (6 * 0)} / (8 - 7)] = ");
            exp = new Subtract(
                new Add(
                    new Divide(
                        new Digit(9), 
                        new Digit(3)
                    ), 
                    new Multiply(
                        new Digit(2), 
                        new Digit(4)
                    )
                ),
                new Divide(
                    new Add(
                        new Divide(
                            new Digit(5), 
                            new Digit(1)
                        ),
                        new Multiply(
                            new Digit(6), 
                            new Digit(0)
                        )
                    ), 
                    new Subtract(
                        new Digit(8),
                        new Digit(7)
                    )
                )
            );

            Console.Write(exp.Evaluate());
            Console.WriteLine();
        }

    }
    
    public abstract class Expression
    {
        public abstract int Evaluate();
    }
    
    public class Digit : Expression
    {
        private int _val;

        public Digit(int val)
        {
            this._val = val;
        }

        public override int Evaluate()
        {
            return _val;
        }
    }
    
    public abstract class BinaryExpression : Expression
    {
        protected Expression _left;
        protected Expression _right;

        public BinaryExpression(Expression left, Expression right)
        {
            this._left = left;
            this._right = right;
        }
    }
    
    public class Add : BinaryExpression
    {

        public Add(Expression left, Expression right): base(left, right)
        {
        }

        public override int Evaluate()
        {
            return _left.Evaluate() + _right.Evaluate();
        }
    }
    
    public class Subtract : BinaryExpression
    {

        public Subtract(Expression left, Expression right): base(left, right)
        {
        }

        public override int Evaluate()
        {
            return _left.Evaluate() - _right.Evaluate();
        }
    }
    
    public class Multiply : BinaryExpression
    {

        public Multiply(Expression left, Expression right): base(left, right)
        {
        }

        public override int Evaluate()
        {
            return _left.Evaluate() * _right.Evaluate();
        }
    }
    
    public class Divide : BinaryExpression
    {

        public Divide(Expression left, Expression right): base(left, right)
        {
        }

        public override int Evaluate()
        {
            return _left.Evaluate() / _right.Evaluate();
        }
    }
}