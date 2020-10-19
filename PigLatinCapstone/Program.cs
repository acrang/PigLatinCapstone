using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PigLatinCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!"); //welcome message

            bool userContinue = true;
            while (userContinue)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a word you would like translated: "); //user prompt

                bool emptyCheck = true;
                while (emptyCheck)
                {
                    string userInput = Console.ReadLine();
                    string lowerInput = userInput.ToLower().Trim(); //makes input lowercase and trims any extra spaces

                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Looks like you did not enter anything. Please try again."); //error message if no input
                        continue;
                    }
                    else if (IsVowel(lowerInput[0]) == true)
                    {
                        emptyCheck = false;
                        Console.WriteLine();
                        Console.WriteLine(lowerInput + "way"); //if first character in input is a vowel adds "way"
                    }
                    else
                    {
                        emptyCheck = false;
                        int arrayPosition = 0;

                        for (int i = 0; i < lowerInput.Length; i++)
                        {
                            char letter = lowerInput[i];

                            if (IsVowel(letter) == false)
                            {
                                arrayPosition += 1;
                            }
                            else
                            {
                                Console.WriteLine();
                                string newWord = lowerInput.Substring(0, arrayPosition); //creates new word from user input up to the first vowel
                                for (int j = arrayPosition; j < lowerInput.Length; j++)
                                {
                                    Console.Write(lowerInput[j]);
                                }
                                Console.WriteLine(newWord + "ay"); //adds "ay" to new word
                                break;
                            }
                        }
                    }
                }
                bool response = true;
                Console.WriteLine();
                Console.WriteLine("Would you like to translate another word? (y/n)"); //asks user if they would like to continue

                while (response)
                {
                    string continueInput = Console.ReadLine();

                    if (continueInput == "n")
                    {
                        userContinue = false;
                        Console.WriteLine();
                        Console.WriteLine("Thank you, goodbye."); //goodbye message
                        break;
                    }
                    else if (continueInput == "y")
                    {
                        response = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error. Please enter either 'y' or 'n'."); //yes/no checker error message
                    }
                }
            }
        }
        public static bool IsVowel(char letter) //checks if selected character is a vowel
        {
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
