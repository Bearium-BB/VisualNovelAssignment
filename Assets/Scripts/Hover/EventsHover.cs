using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventsHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnHover;
    public UnityEvent OnExitHover;

    private void OnMouseEnter()
    {
        OnHover.Invoke();
    }

    private void OnMouseExit()
    {
        OnExitHover.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitHover.Invoke();
    }
}
