using System;
using System.Collections.Generic;
using System.Text;

namespace assign_2_Hangman
{
    class Program
    {

        public static StringBuilder falseGuess = new StringBuilder();
        public static int health = 0;
        public static string selectedWord = "";
        public static List<HangmanText> showTextList = new List<HangmanText>();

        static void Main(string[] args)
        {
            GetWord();
            SetHideString();


            while (true)
            {
                CheckHealth();
                CheckWord();
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

        public static void GetWord()
        {
            Random rnd = new Random();
            string[] words = new string[3] { "animal", "house", "staircase" };

            int rndLengthWord = rnd.Next(0, words.Length);

            selectedWord =  words[rndLengthWord];
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

        public static void HandleLetter(char letter)
        {
            Boolean checkIfLetterExist = false;

            letter = char.ToLower(letter);

            for (int i = 0; i < falseGuess.Length; i++)
            {
                if (falseGuess[i] == letter)
                {
                    checkIfLetterExist = true;
                }
            }

            if (checkIfLetterExist)
            {
                Console.WriteLine("Letter Does Already Exist!");
            }
            else
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

                falseGuess.Append(new Char[] { letter });

                if (!checkIfIncorrect)
                {
                    health++;
                }
                

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

        public static void CheckWord()
        {
            Boolean checkIfAllCharIsGuess = true;

            foreach (var item in showTextList)
            {
                if (item.showingLetter == '_')
                {
                    checkIfAllCharIsGuess = false;
                }
            }

            if (checkIfAllCharIsGuess)
            {
                GameWon();
            }
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
