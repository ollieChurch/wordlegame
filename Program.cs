using System;

namespace wordleGame
{
    class Program
    {
        static string secretWord = "FRAME";

        static void Main(string[] args)
        {
            string guess = "";
            int maxAttempt = 6;
            bool gameWon = false;

            for (int i = 1; i < maxAttempt; i++)
            {
                Console.WriteLine("This is attempt " + i + " out of " + maxAttempt);
                Console.Write("Enter A " + secretWord.Length + "-Letter Guess: ");
                guess = Console.ReadLine();
                if (guess.Length > secretWord.Length)
                {
                    Console.WriteLine("I don't think you can count...");
                }
                else
                {
                    string result = CheckAnswer(guess.ToUpper());
                    if (result == "WIN")
                    {
                        gameWon = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                guess = "";
            }

            Console.WriteLine(gameWon ? "Congratulations! You Won!" : "Bad Luck! You Failed!");

            Console.ReadLine();
        }

        static string CheckAnswer(string playerGuess)
        {
            char[] result;
            result = new char[secretWord.Length];
            for (int i = 0; i < secretWord.Length; i++)
            {
                result[i] = '%';
            }

            int guessIndex = 0;
            foreach (char letter in playerGuess)
            {
                int secretIndex = 0;
                foreach (char secretLetter in secretWord)
                {
                    if (letter == secretLetter)
                    {
                        result[guessIndex] = guessIndex == secretIndex ? letter : '/';
                    }
                    secretIndex++;
                }
                guessIndex++;
            }

            string strResult = string.Join("", result);
            return strResult == secretWord ? "WIN" : strResult;
        }
    }
}
