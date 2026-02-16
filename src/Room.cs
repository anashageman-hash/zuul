using System.Collections.Generic;

public class Room
{
    private string description;
    private Dictionary<string, Room> exits;
    private Inventory chest;

    // Getter voor chest
    public Inventory Chest
    {
        get { return chest; }
    }

<<<<<<< HEAD
    // Constructor
    public Room(string desc)
    {
        description = desc;
        exits = new Dictionary<string, Room>();
        chest = new Inventory(25);
    }
=======
	// Create a room described "description". Initially, it has no exits.
	public Room(string desc)
	{
		description = desc;
		exits = new Dictionary<string, Room>();
		chest = new Inventory(25); // <-- TOEGEVOEGD
	}
>>>>>>> 8efd205b78fcb986b3fa795146b535859be50cae

    // Exit toevoegen
    public void AddExit(string direction, Room neighbor)
    {
        exits[direction] = neighbor; 
    }

    // Korte beschrijving
    public string GetShortDescription()
    {
        return description;
    }

    // Lange beschrijving
    public string GetLongDescription()
    {
        return "You are " + description + ".\n" + GetExitString();
    }

    // Exit ophalen
    public Room GetExit(string direction)
    {
        if (exits.ContainsKey(direction))
        {
            return exits[direction];
        }
        else
        {
            return null;
        }
    }

    // String met exits
    private string GetExitString()
    {
        return "Exits: " + string.Join(", ", exits.Keys);
    }
}
