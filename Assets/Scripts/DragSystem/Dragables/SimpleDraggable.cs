using UnityEngine;

public class SimpleDraggable : MonoBehaviour, IDragable
{
    public void OnDragStart(Vector3 worldPoint) { }

    public void OnDrag(Vector3 worldPoint)
    {
        transform.position = worldPoint;
    }

    public void OnDragEnd() { }
}
