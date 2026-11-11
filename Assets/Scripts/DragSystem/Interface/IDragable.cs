using UnityEditor.Sprites;
using UnityEngine;

public interface IDragable 
{
    void OnDragStart(Vector3 position);
    void OnDragEnd();
    void OnDrag(Vector3 position);
}
