using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Program
    {

        public static StringBuilder falseGuess = new StringBuilder();
        public static int health = 0;
        public static string selectedWord = "";
        public static List<HangmanText> showTextList = new List<HangmanText>();

        static void Main(string[] args)
        {
            selectedWord = GetWord();
            SetHideString();


            while (true)
            {
                CheckHealth();
                if (CheckWord())
                {
                    GameWon();
                }
                PrintHealth();
                Console.WriteLine();
                PrintWord();
                Console.WriteLine("\n");
                PrintUsedLetters();
                Console.Write("\n");
                Console.Write("Enter Letter: ");
                string str = Console.ReadLine();


                Guess(str);

                Console.Clear();
            }

        }

        public static string GetWord()
        {

            FileHandler file = new FileHandler();

            string text = file.GetText("words.txt");

            string[] words = file.SeperateCommas(text);
            string word = file.RandomWord(words);

            return word;
        }

        public static void Guess(String str)  {

            char[] letters = str.ToCharArray();

            if (letters.Length == 1)
            {
                HandleLetter(letters[0]);
            } 
            else
            {
                HandleWord(str);
            }

            Console.WriteLine(falseGuess);
        }

        public static Boolean checkLetterAlreadyExist(char letter)
        {
            Boolean checkIfLetterExist = false;
            for (int i = 0; i < falseGuess.Length; i++)
            {
                if (falseGuess[i] == letter)
                {
                    checkIfLetterExist = true;
                }
            }

            return checkIfLetterExist;
        }

        public static Boolean CheckIfLetterExistInWord(char letter)
        {
            Boolean checkIfIncorrect = false;

            foreach (var letters in showTextList)
            {

                if (letters.existingLetter == letter && letters.showingLetter != letter)
                {
                    letters.showingLetter = letter;
                    checkIfIncorrect = true;
                }
            }

            return checkIfIncorrect;
        }

        public static void HandleLetter(char letter)
        {
            letter = char.ToLower(letter);

            Boolean checkIfLetterExist = checkLetterAlreadyExist(letter);

            if (!checkIfLetterExist)
            {
                Boolean checkIfIncorrect = CheckIfLetterExistInWord(letter);

                falseGuess.Append(new Char[] { letter });

                if (!checkIfIncorrect)
                {
                    health++;
                }
            }
            else
            {
                Console.WriteLine("Letter Does Already Exist!");
            }
            
        }

        public static void SetHideString()
        {
            char[] charArr = selectedWord.ToCharArray();

            foreach (char ch in charArr)
            {
                showTextList.Add(new HangmanText(ch, '_'));
            }
            
        }

        public static void CheckHealth()
        {
            if (health > 9)
            {
                GameOver();
            }
        }

        public static Boolean CheckWord()
        {
            Boolean checkIfAllCharIsGuess = true;

            foreach (var item in showTextList)
            {
                if (item.showingLetter == '_')
                {
                    checkIfAllCharIsGuess = false;
                }
            }

            return checkIfAllCharIsGuess;
        }

        public static void PrintHealth()
        {
            Console.Write("\n Health: " + health + "\n");
        }

        public static void PrintWord()
        {
            foreach (var letter in showTextList)
            {
                Console.Write(letter.showingLetter);
            }
        }

        public static void PrintUsedLetters()
        {
            Console.WriteLine("Guessed Letters!");

            for (int i = 0; i < falseGuess.Length; i++)
            {
                Console.Write(falseGuess[i]);
            }
        }

        public static void GameOver()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine("Word was: " + selectedWord);
            Environment.Exit(0);
        }

        public static void GameWon()
        {
            Console.WriteLine("Correct Answer!");
            Console.WriteLine("Word was: " + selectedWord);
            Environment.Exit(0);
        }

        public static void HandleWord(string word)
        {
            if(selectedWord == word)
            {
                GameWon();
            } else
            {
                Console.WriteLine("Wrong Answer!");
            }
            
        }
    }
}
