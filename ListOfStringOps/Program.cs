using System;

namespace ListOfStringOps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHALLENGE:  Evaluate a string to determine if it contains a pair of numbers that add up to exactly 10 AND have exactly 3 '?' between them.  Return true if TT, else return false.\n\nExample: de5dd??e?5ds would return true.  5 + 5 = 10 and there are ??? between them.");
            Console.WriteLine();
            Console.Write("Enter a string and press enter: ");
            Console.WriteLine();

            string eval = Console.ReadLine();
            
            string result = EvalString(eval);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string EvalString(string s)
        {
            string result = "false";
            int counter = 0;
            int[,] qMark = new int[s.Length,3];            

            foreach (char c in s)
            {
                if(int.TryParse(c.ToString(), out int num))
                {
                    qMark[counter, 0] = num;
                    qMark[counter, 1] = 0;
                    qMark[counter, 2] = 0;

                    if (counter > 0 && qMark[counter - 1, 0] + num == 10 && qMark[counter - 1, 1] == 3)
                    {
                        result = "true";
                        break;
                    }
                    counter++;
                }
                else if (counter > 0 && c == '?')
                {
                    qMark[counter - 1, 1] += 1;
                }
            }
            return result;
        }
    }
}
