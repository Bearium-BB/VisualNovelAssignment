using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public GameObject parentForPopUp;
    public Image parentImage;
    public Sprite popUpSprite;

    public void OnClick()
    {
        parentForPopUp.SetActive(true);
        parentImage.sprite = popUpSprite;
    }
}
