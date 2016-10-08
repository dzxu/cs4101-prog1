// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {

        public Regular() { }

        public override void print(Node t, int n, bool p)
        {

            for (int i=0;i<n;i++){
                Console.Write(" ");
            }

            if(!p)
            Console.Write("(");
            
            if (t.getCar().isNull())
            Console.Write("()");
            else
            t.getCar().print(n, false);

            if(!t.getCdr().isNull()){
                Console.Write(" ");
            }

            t.getCdr().print(n, true);

            // if(t.getCdr().isNull()){
            //     Console.WriteLine();
            // }


            // if(t.isPair() && !t.getCdr().isNull()){
            //     if(t.getCar().isPair())
            //     t.getCar().print(n, false);
            //     else
            //     t.getCar().print(n, true);
            //     // t.getCar().print(n, true);
            //     Console.Write(" ");
            //     // t.getCdr().print(0, true);
            //     if(t.getCdr().getCar().isPair())
            //     t.getCdr().print(0, false);
            //     else
            //     t.getCdr().print(0, true);
            // }
            // else if(t.getCdr().isNull()){
            //     t.getCar().print(0, true);
            //     t.getCdr().print(0, true);
            // }
            
            // else if(!t.isPair()){
            //     t.print(0, true);
            // }

        }
    }
}


