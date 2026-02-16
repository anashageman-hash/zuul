using System.Collections.Generic;

public class Inventory
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
    public bool Put(Item item)
    {
        string itemName = item.Description;
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

        foreach (Item item in items.Values)
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

    // Remove item from inventory
    public bool Remove(string itemName)
    {
        if (!items.ContainsKey(itemName))
        {
            return false;
        }
        items.Remove(itemName);
        return true;
    }

    // Peek item in inventory (without removing)
    public Item Peek(string itemName)
    {
        // Kijk of het item in de lijst zit
        if (items.ContainsKey(itemName))
            return items[itemName];  // zo ja = geef het terug
        else
            return null;             // zo nee = geef niks terug
    }
    // Show inventory contents
    public string Show()
    {
        if (items.Count == 0)
        {
            return "Your inventory is empty.";
            
        }  
       else
    {
        string result = "You are carrying:\n";

        foreach (var item in items.Values)
        {
            result += "- " + item.Description + " (" + item.Weight + "kg)\n";
        }

        return result; 
    }

