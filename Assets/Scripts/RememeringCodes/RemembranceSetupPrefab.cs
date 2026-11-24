using UnityEngine;
using TMPro;

public class RemembranceSetupPrefab : MonoBehaviour
{
    public TextMeshProUGUI code;

    public void SetUp(string codeText)
    {
        code.text = codeText;
    }
}
