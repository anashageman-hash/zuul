using System.Collections.Generic;

class Inventory
{
    // fields
    private int maxWeight;
    private Dictionary<string, Item> items;

    // constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        items = new Dictionary<string, Item>();
    }

    // Put item in inventory
    public bool Put(string itemName, Item item)
    {
        // check if item already exists
        if (items.ContainsKey(itemName))
        {
            return false;
        }

        // check if item fits (weight)
        if (item.Weight > FreeWeight())
        {
            return false;
        }

        // add item
        items.Add(itemName, item);
        return true;
    }

    // Get item from inventory
    public Item Get(string itemName)
    {
        // check if item exists
        if (!items.ContainsKey(itemName))
        {
            return null;
        }

        // get and remove item
        Item item = items[itemName];
        items.Remove(itemName);
        return item;
    }

    // total weight of inventory
    public int TotalWeight()
    {
        int total = 0;

        foreach (Item item in items.Values)      2222222
        {
            total += item.Weight;
        }

        return total;
    }

    // free weight in inventory
    public int FreeWeight()
    {
        return maxWeight - TotalWeight();
    }
}
