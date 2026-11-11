using UnityEngine;

public class ExampleDropTarget : MonoBehaviour, IDropTarget
{
    // This method is called when a draggable item is dropped on this drop target.
    public void OnDropped(UIWorldDropItem item, Vector3 worldPoint)
    {
        Debug.Log($"{name} received {item.name}");
    }
}
