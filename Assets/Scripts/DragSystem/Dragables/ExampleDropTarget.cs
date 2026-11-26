using UnityEngine;
using UnityEngine.Events;

public class ExampleDropTarget : MonoBehaviour, IDropTarget
{
    [SerializeField] string neededItemName;
    [SerializeField] UnityEvent onCorrectItem;
    public void OnDropped(Item item, Vector3 worldPoint)
    {

        if (item.itemSO.GetItemName() == neededItemName)
        {
            Debug.Log($"{name} received the correct item: {item.itemSO.GetItemName()}");
            GameplayGameManager.instance.inventoryPresenter.Remove(item);
            onCorrectItem.Invoke();
        }
    }
}
