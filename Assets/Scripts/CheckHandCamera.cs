using UnityEngine;

public class CheckHandCamera : MonoBehaviour 
{
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject checkHandCameraBox;
    [SerializeField] private GameObject locomotionSystem;
    
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
        if (gameplayPanel != null) gameplayPanel.SetActive(true);
        if (locomotionSystem != null) locomotionSystem.SetActive(true);
    }
}
