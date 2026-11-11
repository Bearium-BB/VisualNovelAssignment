using UnityEngine;

public interface IDropTarget
{
    void OnDropped(Item item, Vector3 worldPoint);
}