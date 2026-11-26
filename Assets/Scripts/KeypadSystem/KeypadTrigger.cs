using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    public KeypadManager keypadManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenKeypad()
    {
        if (keypadManager != null)
        {
            keypadManager.Open();
        }
    }
}
