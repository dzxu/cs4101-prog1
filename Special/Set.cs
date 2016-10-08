// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            for(int i=0;i<n;i++){
                Console.Write(" ");
            }
            if (!p)
                Console.Write("(");

            t.getCar().print(n, true);
            Console.Write(" ");

            t.getCdr().getCar().print(n, true);
            Console.Write(" ");

            t.getCdr().getCdr().getCar().print(n, false);

            t.getCdr().getCdr().getCdr().print(n, true);

            Console.WriteLine();
        }
    }
}

