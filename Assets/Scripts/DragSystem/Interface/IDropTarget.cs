using UnityEngine;

public interface IDropTarget
{
    void OnDropped(UIWorldDropItem item, Vector3 worldPoint);
}