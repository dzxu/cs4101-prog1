// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
        
        // TODO: Add any other methods you need

        public bool isLegalIdentChar(char ch){
            if ((ch >= 'A' && ch <= 'Z') || (ch>='a' && ch<='z') || (ch >= '0' && ch <= '9') || ch == '+' || ch == '-'|| ch == '!' || ch == '$' || ch == '.' || ch == '@'
                || ch == '%' || ch == '&' || ch == '*' || ch == '/' || ch == ':' || ch == '<' || ch == '>' || ch == '=' || ch == '?' || ch == '^' || ch == '_' || ch == '~' 
                ){
                return true;
            }

            return false;
        }

        public Token getNextToken()
        {
            char ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = (char)In.Read();
                
                //comments
                if (ch == ';') {
                    In.ReadLine();
                    return getNextToken();
                }

                //whitespace
                if (ch == 1 || ch == 32 || ch == 9 || ch == 10 || ch == 11 || ch ==  12 || 
                    ch == 13) {
                    return getNextToken();
                }

                if ((int)ch == -1)
                return null;
                
                // Special characters
                else if (ch == '\'')    
                return new Token(TokenType.QUOTE);
                else if (ch == '(')
                return new Token(TokenType.LPAREN);
                else if (ch == ')')
                return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = (char)In.Read();

                    if (ch == 't')
                    return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                    return new Token(TokenType.FALSE);
                    else if ((int)ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                            (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '\"')
                {
                    int size = 0;
                    while((char)In.Peek()!='\"'){
                        buf[size++] = (char)In.Read();
                    }
                    In.Read();
                    String str = new String(buf, 0, 1);
                    buf = new char[BUFSIZE];
                    return new StringToken(str);
                }

                
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int size = 0;
                    buf[size] = ch;
                    while((char)In.Peek()>= '0' && (char)In.Peek()<='9'){
                        buf[++size] = (char)In.Read();
                    }
                    int i = int.Parse(new String(buf, 0, 1));
                    buf = new char[BUFSIZE];
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
                
                // Identifiers
                else if ((ch >= 'A' && ch <= 'Z') || (ch>='a' && ch<='z') || ch == '+' || ch == '-'|| ch == '!' || ch == '$' 
                    || ch == '%' || ch == '&' || ch == '*' || ch == '/' || ch == ':' || ch == '<' || ch == '>' || ch == '=' || ch == '?' || ch == '^' || ch == '_' || ch == '~' 
                    ) {
                    if(ch == '+' || ch == '-'){
                        return new IdentToken("" + ch);
                    }

                    int size = 0;
                    buf[size] = ch;
                    while (isLegalIdentChar((char)In.Peek())){
                        buf[++size] = (char)In.Read();
                    }
                    String str = new String(buf);
                    str.ToLower();
                    buf = new char[BUFSIZE];

                    return new IdentToken(str);
                }
                
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                        + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

