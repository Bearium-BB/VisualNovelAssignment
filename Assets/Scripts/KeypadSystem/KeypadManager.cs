using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class KeypadManager : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public string correctCode = "1234";
    public UnityEvent onCorrectCodeEntered;
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
        if (TextBox.text.Length >= 4)
        {
            ClearTextBox();
            onCorrectCodeEntered.Invoke();
        }

        TextBox.text += text;


        if (TextBox.text.Length == 4)
        {
            Debug.Log(TextBox.text.Length);
            onCorrectCodeEntered.Invoke();
        }
    }

    public void ClearTextBox()
    {
        TextBox.text = "";
    }
}
