using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace alignToBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!argumentsCheck(args))
            {
                Console.WriteLine("Argument Error");
                return;
            }

            char[] separators = new char[] { ' ', '\t', '\n', '\r' };

            blockAlign(args[0], args[1], int.Parse(args[2]), separators);



        }

        static bool argumentsCheck(string[] args)
        {
            if (args.Length != 3)
            {
                return false;
            }
            if (!(int.TryParse(args[2], out int bin)) || !(int.Parse(args[2]) > 0))
            {
                return false;
            }
            return true;
        }

        static void blockAlign(string fileIn, string fileOut, int length, char[] separators)
        {
            try
            {
                using (var sr = new StreamReader(fileIn))
                {

                    using (var sw = new StreamWriter(fileOut, true))
                    {
                        string word = "";
                        List<string> words = new List<string>();
                        bool first = true;
                        bool doubleLine = false;

                        while (sr.Peek() >= 0)
                        {
                            char c = (char)sr.Read();
                            if (Array.IndexOf(separators, c) >= 0)
                            {
                                if (word != "")
                                {
                                    words.Add(word);
                                }
                                else
                                {
                                    if (words.Count > 0 && (doubleLine && c == '\n'))
                                    {
                                        block(words, length, fileOut, first, sw);
                                        first = false;
                                        words.Clear();
                                    }
                                }
                                if (c == '\n')
                                    doubleLine = true;
                                word = "";
                            }
                            else
                            {
                                word += c;
                                doubleLine = false;
                            }

                        }

                        if (word != "")
                        {
                            words.Add(word);
                        }

                        block(words, length, fileOut, first, sw);

                        words.Clear();

                    }
                }
            }
            catch
            {
                Console.WriteLine("File Error");
            }
        }

        static void block(List<string> words, int length, string fileOut, bool first, StreamWriter Console)
        {
            if (words.Count == 0) return;
            List<string> actual = new List<string>();
            int actualLength = 0;
            int counter = 0;
            if (!first)
                Console.Write('\n');

            while (counter < words.Count)
            {
                do
                {
                    actual.Add(words.ElementAt(counter));
                    actualLength += words.ElementAt(counter).Length + 1;
                    counter++;
                } while (counter < words.Count && actualLength + words.ElementAt(counter).Length <= length);
                actualLength--;



                int spaces = actual.Count - 1;
                if (spaces != 0)
                {
                    int count = length - actualLength;
                    int countInOne = count / spaces + 1;
                    int countOfLonger = count % spaces;


                    for (int i = 0; i < actual.Count - 1; i++)
                    {
                        int number = 0;
                        if (counter == words.Count)
                            number = 1;
                        else if (i < countOfLonger)
                            number = countInOne + 1;
                        else
                            number = countInOne;
                        Console.Write(actual.ElementAt(i) + new String(' ', number));
                    }
                }
                Console.Write(actual.ElementAt(actual.Count - 1));




                Console.Write('\n');
                actual.Clear();
                actualLength = 0;
            }







        }
    }
}
