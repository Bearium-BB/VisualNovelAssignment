using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "NewItem")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite sprite;

    public string GetItemName()
    {
         return itemName;
    }

    public Sprite GetSprite() 
    { 
        return sprite;
    }


}
