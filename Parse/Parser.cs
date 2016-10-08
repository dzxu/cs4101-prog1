// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }

	public Node falseNode = new BoolLit(false);
	public Node trueNode = new BoolLit(true);
	public Node nilNode = new Nil();
  
        public Node parseExp()
        {
            return parseExpWithVal(scanner.getNextToken());
        }

        public Node parseExpWithVal(Token token)
        {
            TokenType type = token.getType();

            //EOF
            if (token == null) return null;

            else if (type == TokenType.LPAREN) return parseRest();

            else if (type == TokenType.FALSE) return falseNode;

            else if (type == TokenType.TRUE) return trueNode;

            else if (type == TokenType.QUOTE) return new Cons(new Ident("'"), parseExp());

            else if (type == TokenType.INT) return new IntLit(token.getIntVal());

            else if (type == TokenType.STRING) return new StringLit(token.getStringVal());

            else if(type == TokenType.IDENT) return new Ident(token.getName());

            else if (type == TokenType.RPAREN)
            {
                Console.WriteLine("Unexpected Token: ')'");
                return parseExp();
            }

            else //type == TokenType.DOT
            {
                Console.WriteLine("Unexpected Token: '.'");
                return parseExp();
            }
        }
  
        protected Node parseRest()
        {
            Token token = scanner.getNextToken();
            TokenType type = token.getType();

            //EOF
            if (token == null) return null;

            else if (type == TokenType.RPAREN) return nilNode;

            else if (type == TokenType.DOT) return new Cons(parseExp(), parseExp());

            else return new Cons(parseExpWithVal(token), parseRest()); 
        }
    }
}

