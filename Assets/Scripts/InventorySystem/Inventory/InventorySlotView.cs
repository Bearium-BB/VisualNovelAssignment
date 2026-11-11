using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text nameLabel;
    [SerializeField] UIWorldDropItemInventory dragable;

    public Item Item { get; private set; }

    // Bind the item to the slot view, updating the icon and name label.
    public void Bind(Item item)
    {
        Item = item;
        iconImage.sprite = item.itemSO.GetSprite();
        iconImage.enabled = item.itemSO.GetSprite() != null;
        if (nameLabel != null) nameLabel.text = item.itemSO.GetItemName();
        if (dragable != null) dragable.SetItem(item);
    }
}
