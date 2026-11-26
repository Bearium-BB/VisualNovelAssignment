using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KeypadManager : MonoBehaviour
{
    public GameObject keypadPanel;
    public TextMeshProUGUI TextBox;
    public string correctCode = "1234";
    public UnityEvent onCorrectCodeEntered;
    public UnityEvent onIncorrectCodeEntered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTextBox(string text)
    {
        if (TextBox.text.Length == 4)
        {
            ClearTextBox();
        }
        else
        {
            TextBox.text += text;
        }


        if (TextBox.text.Length == 4)
        {
            if (TextBox.text == correctCode)
            {
                onCorrectCodeEntered.Invoke();
            }
            else
            {
                onIncorrectCodeEntered.Invoke();
            }
        }
    }

    public void ClearTextBox()
    {
        TextBox.text = "";
    }

    public void Open()
    {
        if (GameplayGameManager.instance.TryOpen(keypadPanel))
            ClearTextBox();
    }

    public void Close()
    {
        GameplayGameManager.instance.Close(keypadPanel);
    }
}
