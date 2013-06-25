using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautifulStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "nlhthgrfdnnlprjtecpdrthigjoqdejsfkasoctjijaoebqlrgaiakfsbljmpibkidjsrtkgrdnqsknbarpabgokbsrfhmeklrle";
            //string input = "abab";
            string output = string.Empty;

            //the index of the verified character in the input string
            int order = 0;

            foreach (var ch in input)
            {
                if (!output.Contains(ch))
                {
                    output = string.Concat(output, ch);
                }
                else
                {
                    //Search for an element lexicographically greater than the character, after the first occurrence
                    int p1 = output.IndexOf(ch);

                    //if p1 = -1, character not found
                    if (p1 >= 0)
                    {
                        //search in the output string after the position of the current character
                        string stringToSearchIn = output.Substring(p1+1);
                        foreach (var testChar in stringToSearchIn)
                        {
                            //test for lexicographically greater
                            if (testChar > ch)
                            {
                                //the position of the character that is lexicographically greater than the current character
                                int p2 = output.IndexOf(testChar);

                                //all the characters from the output string, between the position of the current char
                                //and the position of the character lexicographically greater(inclusive), must be found in the input string after the current verified character
                                //In other words, if the characters that are lexicographically smaller than the current char, and the next char that is greater, are found
                                //after in the input string after the current char, this means it will be analyzed in the future and replaced, so it is ok to remove the first occurrence of the character and append it to the end.
                                string repetedChars = output.Substring(p1, p2 - p1);
                                bool repeated = true;
                                foreach (var repeatedChar in repetedChars)
                                {
                                    string inputStringToSearch = input.Substring(order);
                                    if(!inputStringToSearch.Contains(repeatedChar))
                                    {
                                        repeated = false;
                                    }
                                }
                                if (repeated)
                                {
                                    //remove the first occurrence of the current char in the input string and append the character at output.
                                    output = output.Remove(p1, 1);
                                    output = string.Concat(output, ch);
                                }
                                break;
                            }
                        }
                    }
                }
                order ++;
            }

            Console.WriteLine(output);
        }
    }
}
