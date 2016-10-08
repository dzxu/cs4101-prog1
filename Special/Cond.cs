// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {

	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            for (int i=0;i<n;i++){
                Console.Write(" ");
            }

            Node cdr = t.getCdr();

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


