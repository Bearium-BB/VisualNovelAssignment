using System.Collections.Generic;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{

    [SerializeField] InventoryView view;
    [SerializeField] List<ItemSO> startingItems;

    public InventoryModel Model { get; private set; }

    // Binding the redraw method to add item and remove item. 
    void Awake()
    {
        Model = new InventoryModel();
        Model.ItemAdded += _ => Redraw();
        Model.ItemRemoved += _ => Redraw();
    }

    // Adding starting items to the inventory.
    void Start()
    {

        foreach (ItemSO so in startingItems)
        {
            if (so == null) continue;
            Add(new Item(so));

        }

        Redraw();
    }

    // Redraw the view with the current items in the model.
    void Redraw()
    { 
        view.Refresh(Model.GetItems()); 
    }
    
    // Add an item to the inventory.
    public void Add(Item item) => Model.AddItem(item);
    // Remove an item from the inventory.
    public void Remove(Item item) => Model.RemoveItem(item);
}