using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    List<Item> items;

    // Events to notify when an item is added or removed from the inventory.
    public event Action<Item> ItemAdded;
    public event Action<Item> ItemRemoved;
    public InventoryModel()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        if (items.Remove(item))
            ItemRemoved?.Invoke(item);
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
