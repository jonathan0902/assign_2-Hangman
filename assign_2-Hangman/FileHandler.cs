using System;
using System.IO;
namespace Hangman
{
	public class FileHandler
	{
		private string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent + "/../txt/";

		public string GetText(string filename)
		{
			return File.ReadAllText(path + filename);
		}

		public string[] SeperateCommas(string text)
		{
			return text.Split(',');
		}

		public string RandomWord(string[] words)
		{
			Random rnd = new Random();
			int rndLengthWord = rnd.Next(0, words.Length);

			return words[rndLengthWord];
		}
	}
}
