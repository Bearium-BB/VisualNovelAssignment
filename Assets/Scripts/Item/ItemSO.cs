using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite sprite;
    [SerializeField] string itemDescription;

    public string GetItemName()
    {
         return itemName;
    }

    public string GetDescription()
    {
         return itemDescription;
    }

    public Sprite GetSprite() 
    { 
        return sprite;
    }


}
