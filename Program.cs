using System;

namespace freeCodeCamp
{
    class Program
    {
        static string secretWord = "frame";

        static void Main(string[] args)
        {
            string guess = "";
            int maxAttempt = 6;
            bool gameOver = false;

            for (int i=1; i <maxAttempt; i++)
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
                    string result = CheckAnswer(guess);
                    if (result == "WIN")
                    {
                        Console.WriteLine("Congratulations! You Won!");
                        gameOver = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                guess = "";
            }

            if (!gameOver)
            {
                Console.WriteLine("Bad Luck! You Failed!");
            }

            Console.ReadLine();
        }

        static string CheckAnswer(string playerGuess)
        {
            char[] result;
            result = new char[secretWord.Length];
            for (int i=0; i < secretWord.Length; i++)
            {
                result[i] = 'X';
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
