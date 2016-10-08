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


            Console.Write("\'");
            // if(t.getCdr().isNull()){
            //     t.getCdr().print(0, true);
            //     return;
            // }


            // if (t.getCar().isPair()){
            //     Console.Write("(");
            // }

            t.getCar().print(0, false);

            if (!t.getCdr().isNull()){
                Console.Write(" ");
            }
            t.getCdr().print(0, true);

            // if (t.getCar()!=null){
            //     t.getCar().print(n, true);
            // }
        }
    }
}

