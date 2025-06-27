using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private Transform layout;
    private const string SCREENSHOT_NAME = "ScreenshotImage";

    //add picture to left gallery
    public void AddPicture(Texture2D screenshot)
    {
        if (screenshot == null || layout == null) return;

        GameObject picture = new GameObject(SCREENSHOT_NAME);
        picture.transform.SetParent(layout, false);
        picture.transform.SetSiblingIndex(0);
        RawImage rawImage = picture.AddComponent<RawImage>();
        rawImage.texture = screenshot;
    }
}

