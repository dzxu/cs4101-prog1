// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {

	public If() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i=0;i<n;i++){
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Node cddr = cdr.getCdr();
            Node cdddr = cddr.getCdr();
            Node cddddr = cdddr.getCdr();

            Console.Write("(if ");
            cdr.getCar().print(0, false);
            n+=4;
            for (int i=0;i<n;i++){
                Console.Write(" ");
            }
            cddr.getCar().print(0, false);
            if (!cddr.getCar().isPair()){
                Console.WriteLine();
            }

            for (int i=0;i<n;i++){
                Console.Write(" ");
            }
            cdddr.getCar().print(0, false);
            n-=4;
            Console.WriteLine();

            for (int i=0;i<n;i++){
                Console.Write(" ");
            }
            cddddr.print(n, true);
            Console.WriteLine();


        }
    }
}

