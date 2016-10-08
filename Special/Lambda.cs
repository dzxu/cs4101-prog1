// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {

	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i=0;i<n;i++){
                Console.Write(" ");
            }

            Console.Write("(");
            t.getCar().print(0, true);
            Console.Write(" ");

            t.getCdr().getCar().print(0, false);
            n += 4;

            for (int i=0;i<n;i++){
                Console.Write(" ");
            }

            t.getCdr().getCdr().getCar().print(n, false);
            n -= 4;

            for (int i=0;i<n;i++){
                Console.Write(" ");
            }
            t.getCdr().getCdr().getCdr().print(n, true);
            Console.WriteLine();
        }
    }
}

