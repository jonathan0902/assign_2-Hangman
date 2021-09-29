using System;

public class HangmanText
{
	public char existingLetter;
	public char showingLetter;

	public HangmanText(char existingLetter, char showingLetter)
	{
		this.existingLetter = existingLetter;
		this.showingLetter = showingLetter;
	}

	public char ExistingLetter {
		get {
			return existingLetter;
		}
	}

	public char ShowingLetter
	{
		get
		{
			return showingLetter;
		}
	}
}
