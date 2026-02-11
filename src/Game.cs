using System;

class Game
{
	// Private fields
	private Parser parser;
	private Player player;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms
	private void CreateRooms()
	{
		Room classroom = new Room("You are in a classroom.");
		Room hallway = new Room("You are in a long hallway.");
		Room cafeteria = new Room("You are in the cafeteria.");
		Room library = new Room("You are in the library.");
		Room computerRoom = new Room("You are in the computer room.");
		Room janitorRoom = new Room("You are in the janitor room.");
		Room exit = new Room("You are at the school exit.");

		classroom.AddExit("east", hallway);

		hallway.AddExit("west", classroom);
		hallway.AddExit("south", cafeteria);
		hallway.AddExit("north", library);

		cafeteria.AddExit("east", computerRoom);
		computerRoom.AddExit("west", cafeteria);

		library.AddExit("west", janitorRoom);
		janitorRoom.AddExit("south", exit);

		player.CurrentRoom = classroom;
	}

	// Main play routine
	public void Play()
	{
		PrintWelcome();

		bool finished = false;
		while (!finished)
		{
			if (player.Health <= 0)
			{
				Console.WriteLine("You are dead. Game over!");
				break;
			}

			if (player.HasWon)
			{
				Console.WriteLine("You escaped the school! You win!");
				break;
			}

			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}

		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to School Escape!");
		Console.WriteLine("Try to find the exit.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if (command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit;
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "quit":
				wantToQuit = true;
				break;
			case "look":
				PrintLook();
				break;
			case "status":
				PrintStatus();
				break;
		}

		return wantToQuit;
	}

	private void PrintHelp()
	{
		Console.WriteLine("You are trying to escape the school.");
		Console.WriteLine("Move by typing: go north, go south, go east, go west.");
		Console.WriteLine();
		parser.PrintValidCommands();
	}

	private void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;
		Room nextRoom = player.CurrentRoom.GetExit(direction);

		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}

		player.CurrentRoom = nextRoom;

		player.Health -= 10;
		Console.WriteLine("Health: " + player.Health);

		Console.WriteLine(player.CurrentRoom.GetLongDescription());

		if (player.CurrentRoom.GetLongDescription().Contains("exit"))
		{
			player.HasWon = true;
		}
	}

	private void PrintLook()
	{
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	private void PrintStatus()
	{
		Console.WriteLine("Health: " + player.Health);
		Console.WriteLine("You are carrying " + player.InventoryWeight + " kg of items.");
	}
}
