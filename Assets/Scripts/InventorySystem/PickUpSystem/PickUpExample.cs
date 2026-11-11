using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUpExample : MonoBehaviour, IPickUpable
{
    [SerializeField] ItemSO itemSO;

    [SerializeField] SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        if (itemSO != null && spriteRenderer != null)
            spriteRenderer.sprite = itemSO.GetSprite();
    }
    // When the player collides with the pickup, add the item to the inventory and destroy the pickup object.
    public Item OnPickUp()
    {
        Item item = new Item(itemSO);
        GameplayGameManager.instance.inventoryPresenter.Add(item);
        Destroy(gameObject);    
        return item;
    }
}