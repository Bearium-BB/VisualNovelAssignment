using UnityEngine;

public class RemembranceSystem : MonoBehaviour
{
    public GameObject container;
    public GameObject prefab;

    public void AddCode(string codeText)
    {
        GameObject newCode = Instantiate(prefab, container.transform);
        newCode.GetComponent<RemembranceSetupPrefab>().SetUp(codeText);
    }

    void Start()
    {
        AddCode("Example Code 1");
        AddCode("Example Code 2");
    }
}
