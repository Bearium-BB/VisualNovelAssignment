using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] InventorySlotView slotPrefab;
    List<InventorySlotView> slots = new List<InventorySlotView>();

    // Refresh the inventory view with the given list of items.
    public void Refresh(List<Item> items)
    {
        foreach (var slot in slots)
            Destroy(slot.gameObject);
        slots.Clear();

        foreach (var item in items)
        {
            var slot = Instantiate(slotPrefab, container);
            slot.Bind(item);
            slots.Add(slot);
        }
    }
}
