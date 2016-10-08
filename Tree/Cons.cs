// Cons -- Parse tree node class for representing a Cons node

using System;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;

        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }

	public override bool isPair() { return true; }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        public void parseList()
        {
	    if(car.isSymbol()) {
	    	
		string name = car.getName();

		if (name == "begin") form = new Begin();

	    	else if (name == "cond") form = new Cond(); 

	    	else if (name == "define") form = new Define(); 
		
	    	else if (name == "if") form = new If(); 
 
 	    	else if (name == "lambda") form = new Lambda(); 

	    	else if (name == "let") form = new Let(); 
		
		else if (name == "'") form = new Quote();

		else if (name == "set!") form = new Set();

		else form = new Regular();
	    }
	    else form = new Regular();
        }

        public override Node getCar(){
            return car;
        }

        public override Node getCdr(){
            return cdr;
        }

        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }
    }
}

