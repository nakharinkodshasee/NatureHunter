using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject creaturePanel;
    //[SerializeField] private GameObject cameraPanel;
    [SerializeField] private GameObject checkHandCameraBox;

    public void ToCameraPanel()
    {
        creaturePanel.SetActive(false);
        checkHandCameraBox.SetActive(true);
        //cameraPanel.SetActive(true);
    }
}
