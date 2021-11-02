using System;
using System.Linq;
using System.Text;
using Xunit;

namespace PigLatinUnitTest
{
    //public class Program
    class Translator

    {
        ////static void Main(string[] args)
        //public string ToPigLatinInput(string userInput)
        //{
        //    string userInput = GetInput("Please input a word or sentence to translate to pig Latin");

        //    string translation = ToPigLatinInput(userInput);
        //    Console.WriteLine(translation);
        //}

        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }


        public bool IsVowel(char c)                                 //override?
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };      //added 'y'

            return c.ToString() == vowels.ToString();
        }

        public string ToPigLatin(string word, string expected)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            word = word.ToLower();
            foreach (char c in specialChars)
            {
                foreach (char w in word)
                {
                    if (w == c)
                    {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        return word;
                    }
                }

            }

            bool noVowels = true;
            foreach (char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false;
                }
            }

            if (noVowels)
            {
                return word;
            }

            char firstLetter = word[0];
            string output;
            if (IsVowel(firstLetter) == true)
            {
                output = (word + "way");              //added "w" to "ay"
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                string sub = word.Substring(vowelIndex + 1);
                string postFix = word.Substring(0, vowelIndex - 1);

                output = sub + postFix + "ay";
            }

            return output;
        }

    }
}


//All but 2 test cases are giving the same error c# assert.equal() failure
//I don't know how to fix this 