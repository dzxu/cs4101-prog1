// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {

	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            for(int i=0;i<n;i++){
                Console.Write(" ");
            }

            t.getCar().print(0, false);

            if (t.getCdr().isPair()){
                Console.Write("(");
            }

            t.getCdr().print(0, true);

            Console.WriteLine();
        }
    }
}

