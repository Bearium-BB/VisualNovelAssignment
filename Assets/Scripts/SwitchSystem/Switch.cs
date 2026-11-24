using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public bool isOn = false;
    
    public UnityEvent onSwitchOn;

    public UnityEvent onSwitchOff;

    public void Toggle()
    {
        isOn = !isOn;

        if (isOn)
            onSwitchOn.Invoke();
        else
            onSwitchOff.Invoke();
    }
}
