using System;
using System.Diagnostics;

namespace ConsoleTypingTest
{

    internal class Game
    {
            private string _initialSentence = @"This is a Japanese doll.
Behind the window was a reflection that only instilled fear.
Despite what your teacher may have told you, there is a wrong way to wield a lasso.
Blue sounded too cold at the time and yet it seemed to work for gin.
The stranger officiates the meal.
Facing his greatest fear, he ate his first marshmallow.";
        // private string _initialSentence = "This is some text to enter";
        static ConsoleColor _uncompleteColor = ConsoleColor.Gray;
        static ConsoleColor _completeColor = ConsoleColor.Magenta;
        static ConsoleColor _currentSymbolColor = ConsoleColor.White;
        static ConsoleColor _errorColor = ConsoleColor.Red;

        public void SetupConsole()
        {
            int screenWidth = 100;
            int screenHeight = 20;

            Console.ResetColor();
            Console.Clear();
            Console.SetWindowSize(screenWidth, screenHeight);
        }
        public void StartGame()
        {
            Console.WriteLine("To start the game type 's'");
            while (true)
            {
                char input = GetConsoleInput();
                if (input == '0')
                    continue;
                if (input == 's')
                {
                    LaunchTypingMode();
                }

                Console.Clear();
                Console.WriteLine("To start the game type 's'");
            }
        }
        public void LaunchTypingMode()
        {
            string sentence = _initialSentence;
            int currentLetter = 0;
            int lettersTyped = 0;

            var stopWatch = Stopwatch.StartNew();

            DrawToConsole(sentence, currentLetter);
            while (true)
            {
                if (currentLetter == sentence.Length)
                    break;
                UpdateConsole(sentence, ref currentLetter, ref lettersTyped);
            }
            stopWatch.Stop();

            OutputResults(stopWatch, sentence.Length, lettersTyped);
            Console.WriteLine("Type 'e' to go to mode choose");

            while (true)
            {
                char input = GetConsoleInput();
                if (input == '0')
                    continue;
                if (input == 'e')
                    break;
            }
        }
        public void OutputResults(Stopwatch stopWatch, int sentenceLength, int lettersTyped)
        {
            double minutesPassed = stopWatch.Elapsed.TotalMinutes;
            int speed = (int)((double)sentenceLength / minutesPassed) / 5;
            double accuracy = (double) sentenceLength * 100.0 / (double)lettersTyped;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your speed is {speed}WPM, and your accuracy was {Math.Round(accuracy, 2)}%");
            Console.ResetColor();
        }
        public void UpdateConsole(string currentSentence, ref int currentLetter, ref int lettersTyped)
        {
            if(currentSentence[currentLetter] == '\r' || currentSentence[currentLetter] == '\n')
            {
                currentLetter++;
                return;
            }
            char key = GetConsoleInput();
            if (key == '0')
                return;
            if (key == currentSentence[currentLetter])
                currentLetter++;
            lettersTyped++;

            DrawToConsole(currentSentence, currentLetter);
            Console.WriteLine(lettersTyped);
        }
        public void DrawToConsole(string currentSentence, int currentLetter)
        {
            Console.Clear();
            Console.ForegroundColor = _completeColor;

            for (int i = 0; i < currentSentence.Length; i++)
            {
                char output = currentSentence[i];
                if (i == currentLetter && currentSentence[currentLetter] == ' ')
                    output = '_';
                if (i == currentLetter)
                    Console.ForegroundColor = _currentSymbolColor;
                else if (i > currentLetter)
                    Console.ForegroundColor = _uncompleteColor;
                Console.Write(output);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public bool IsWordComplete(string currentWord, int currentLetter)
        {
            if (currentWord.Length == currentLetter)
                return true;
            return false;
        }

        public static char GetConsoleInput()
        {
            if (!Console.KeyAvailable)
                return '0';
            ConsoleKeyInfo k = Console.ReadKey();
            return k.KeyChar;
        }
    }
}