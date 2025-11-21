using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Timer : MonoBehaviour
{
    private float startTime = 120f;
    private int lastDisplayedSecond = -1;

    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private RectTransform resultPanelTransform;
    [SerializeField] private Transform XR_OriginTransform;
    
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject locomotionSystem;
    [SerializeField] private GameObject redScreen;
    [SerializeField] private GameObject handCamera;

    [SerializeField] private GameObject rightController;
    [SerializeField] private GameObject leftController;

    
    private static readonly Vector2 RESULT_POSITION = new Vector2(0f, 125f);
    private static readonly Vector3 ORIGIN_POSITION = Vector3.zero;
    private const float WarningThreshold = 7f;
    void Update()
    {
        if (startTime > 0f)
        {
            startTime -= Time.deltaTime;

            int currentSecond = Mathf.CeilToInt(startTime);

            if (startTime < WarningThreshold && startTime > 0f && redScreen.activeInHierarchy == false)
            {
                redScreen.SetActive(true);
            }

            if (currentSecond != lastDisplayedSecond)
            {
                lastDisplayedSecond = currentSecond;
                textMeshProUGUI.text = currentSecond.ToString();
            }
            
        }
        else if (enabled)
            {
                ShowResult();
                locomotionSystem.SetActive(false);
                gameplayPanel.SetActive(false);
            }
    }

    private void ShowResult()
    {
        rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
        leftController.GetComponent<XRInteractorLineVisual>().enabled = true;
        var charController = XR_OriginTransform.GetComponent<CharacterController>();
        if (charController != null)
        {
            charController.enabled = false;
            XR_OriginTransform.position = ORIGIN_POSITION;

            Vector3 direction = resultPanelTransform.position - XR_OriginTransform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                XR_OriginTransform.rotation = Quaternion.LookRotation(direction);
            }

            charController.enabled = true;
        }
        else
        {
            XR_OriginTransform.position = ORIGIN_POSITION;

            Vector3 direction = resultPanelTransform.position - XR_OriginTransform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                XR_OriginTransform.rotation = Quaternion.LookRotation(direction);
            }
        }
        handCamera.SetActive(false);
        resultPanelTransform.anchoredPosition = RESULT_POSITION;
        resultPanelTransform.gameObject.SetActive(true);
    }
}

