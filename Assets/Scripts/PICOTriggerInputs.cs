using UnityEngine;
using UnityEngine.InputSystem;


public class PICOTriggerInputs : MonoBehaviour
{
    [SerializeField] private InputActionReference takePhotoTrigger;
    [SerializeField] private HandCamera handCameraScript;
    void Start()
    {
        takePhotoTrigger.action.started += DoAddPicture;
    }

    private void OnDestroy()
    {
        takePhotoTrigger.action.started -= DoAddPicture;
    }

    private void DoAddPicture(InputAction.CallbackContext obj)
    {
        handCameraScript.ScreenShotting();
    }
}
