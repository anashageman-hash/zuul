using System.Collections.Generic;

class CommandLibrary
{
	// A List that holds all valid command words
	private readonly List<string> validCommands;

	// Constructor
	public CommandLibrary()
	{
		validCommands = new List<string>();

		validCommands.Add("help");
		validCommands.Add("go");
		validCommands.Add("look");
		validCommands.Add("quit");
		validCommands.Add("status"); 
		validCommands.Add("take"); // <-- TOEGEVOEGD
        validCommands.Add("drop"); // <-- TOEGEVOEGD

	}

	// Check whether a given string is a valid command word
	public bool IsValidCommandWord(string instring)
	{
		return validCommands.Contains(instring);
	}

	// returns a list of valid command words as a comma separated string.
	public string GetCommandsString()
	{
		return String.Join(", ", validCommands);
	}
}