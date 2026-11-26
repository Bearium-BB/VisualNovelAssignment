using UnityEngine;

public class GameplayGameManager : MonoBehaviour
{    
    public static GameplayGameManager instance { get; private set; }

    
    public InventoryPresenter inventoryPresenter;
    public RemembranceSystem remembranceSystem;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }

}
