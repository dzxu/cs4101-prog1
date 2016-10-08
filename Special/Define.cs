// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {

	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i=0;i<n;i++) {
                Console.Write(" ");
            }

            Console.Write("(");
            t.getCar().print(0, true);
            Console.Write(" ");

            t.getCdr().getCar().print(0, false);

            if(t.getCdr().getCar().isPair()){
                n += 4;
                t.getCdr().getCdr().getCar().print(n, false);
                n -= 4;
            }
            else{
                Console.Write(" ");
                t.getCdr().getCdr().getCar().print(0, false);
            }

            t.getCdr().getCdr().getCdr().print(n, true);
            Console.WriteLine();
        }
    }
}


