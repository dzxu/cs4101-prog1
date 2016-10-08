// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {

	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Node cdr = t.getCdr();

            for(int i=0;i<n;i++){
                Console.Write(" ");
            }

            Console.Write("(");
            t.getCar().print(n, true);
            Console.WriteLine();

            n += 4;

            while(!cdr.isNull()){
                for (int i=0; i<n; i++){
                    Console.Write(" ");
                }

                cdr.getCar().print(0, false);
                Console.WriteLine();
                cdr = cdr.getCdr();
            }
            cdr.print(0, true);
            Console.WriteLine();
        }
    }
}


