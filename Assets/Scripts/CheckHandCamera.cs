using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckHandCamera : MonoBehaviour 
{
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject checkHandCameraBox;
    [SerializeField] private GameObject locomotionSystem;
    [SerializeField] private GameObject rightController;
    [SerializeField] private GameObject leftController;
    
    private const string HAND_CAMERA_TAG = "HandCamera";

    public void PlayGame()
    {
        ActivateGameplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HAND_CAMERA_TAG))
        {
            ActivateGameplay();
            checkHandCameraBox.SetActive(false);
        }
    }

    //make player able to move again
    private void ActivateGameplay()
    {
        rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
        leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
        if (gameplayPanel != null) gameplayPanel.SetActive(true);
        if (locomotionSystem != null) locomotionSystem.SetActive(true);
    }
}
