using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Portraits : MonoBehaviour
{
    public DialogueRunner runner;
    public Image leftImage;
    public Image rightImage;
    public Sprite[] sprites;

    void Awake()
    {

        //Added Command 
        runner.AddCommandHandler<string, string>("portrait", ShowPortrait);
        runner.AddCommandHandler("hide_portraits", HidePortraits);

        HidePortraits();
    }
  
    void ShowPortrait(string side, string spriteName)
    {
        Sprite spriteFound = null;

        //Looks for the sprite based off its name. Not its file name, it's "SRRITE" name. 
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == spriteName)
            {
                spriteFound = sprite;
            }
        }

        //Sets the direction based off left or right. 
        if (side == "left")
        {
            SetImage(leftImage, spriteFound);
        }
        else
        {
            SetImage(rightImage, spriteFound);
        }

    }

    void HidePortraits()
    {
        leftImage.enabled = false;
        rightImage.enabled = false;
    }

    void SetImage(Image image ,Sprite sprite)
    {

        image.sprite = sprite;
        image.enabled = true;
    }
}
