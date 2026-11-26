using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RemembranceSystem : MonoBehaviour
{
    public GameObject container;
    public GameObject prefab;
    public List<string> rememberedCodes = new List<string>();

    public void AddCode(string codeText)
    {
        if (rememberedCodes.Contains(codeText)) 
        {
            return;
        }

        GameObject newCode = Instantiate(prefab, container.transform);
        newCode.GetComponent<RemembranceSetupPrefab>().SetUp(codeText);
        rememberedCodes.Add(codeText);
    }
}
