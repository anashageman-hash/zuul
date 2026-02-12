public class Player
{
    public int Health { get; set; } = 100;
    public bool HasWon { get; set; } = false;

    // Inventory van de speler
    private Inventory backpack;

    // Current room of the player
    public Room CurrentRoom { get; set; }

    // Total weight of inventory
    public int InventoryWeight => backpack.TotalWeight();

    // Constructor
    public Player()
    {
        backpack = new Inventory(25); // max 25kg
    }

    // Pak item uit de Room
    public bool TakeFromChest(Room room, string itemName)
    {
        Item item = room.Chest.Peek(itemName);
        if (item == null)
        {
            Console.WriteLine("Item is not in Room");
            return false;
        }

        if (!backpack.Put(item))
        {
            Console.WriteLine("Item doesn't fit in your inventory");
            return false;
        }

        room.Chest.Remove(itemName);
        Console.WriteLine("Item taken");
        return true;
    }

    // Leg item in de Room
    public bool DropToChest(Room room, string itemName)
    {
        Item item = backpack.Get(itemName);
        if (item == null)
        {
            Console.WriteLine("You don't have that Item");
            return false;
        }

        room.Chest.Put(item);
        backpack.Remove(itemName);
        Console.WriteLine("Item dropped");
        return true;
    }

    // Show backpack contents
    public string ShowBackpack()
    {
        return backpack.Show();
    }
}
