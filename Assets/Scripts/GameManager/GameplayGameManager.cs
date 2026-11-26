using UnityEngine;

public class GameplayGameManager : MonoBehaviour
{    
    public static GameplayGameManager instance { get; private set; }

    
    public InventoryPresenter inventoryPresenter;
    public RemembranceSystem remembranceSystem;

    public bool replaceCurrentOverlay = false;

    GameObject currentOverlay;


    //Updates this variable when reading is blocking
    public bool isBlocking => currentOverlay != null;

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }

    public bool TryOpen(GameObject overlay)
    {

        if (overlay == null) 
        {
            return false;
        }
        if (currentOverlay == overlay)
        {
            return true;
        }

        if (currentOverlay != null)
        {
            if (!replaceCurrentOverlay) return false;   
            currentOverlay.SetActive(false);
        }

        currentOverlay = overlay;
        currentOverlay.SetActive(true);
        return true;
    }

    public void Close(GameObject overlay)
    {
        if (overlay == null || overlay != currentOverlay)
        {
            return;
        }

        currentOverlay.SetActive(false);
        currentOverlay = null;
    }

    public void CloseCurrent()
    {
        if (currentOverlay == null) 
        { 
            return;
        }

        currentOverlay.SetActive(false);
        currentOverlay = null;
    }

}
