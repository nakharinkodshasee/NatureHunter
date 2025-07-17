using UnityEngine;

public class HandCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private Display display;
    [SerializeField] private ResultPanelManager resultPanelManager;

    [Header("Screenshot Quality")]
    [SerializeField] private int screenshotWidth = 1920;
    [SerializeField] private int screenshotHeight = 1080;
    [SerializeField] private int antiAliasing = 8; // 1, 2, 4, or 8
    [SerializeField] private RenderTextureFormat renderFormat = RenderTextureFormat.ARGB32;

    [Header("Camera Enhancement")]
    [SerializeField] private bool useTemporarySettings = true;
    [SerializeField] private float tempFOV = 45f;
    [SerializeField] private float tempNearClip = 0.1f;
    [SerializeField] private float tempFarClip = 100f;

    private const string CREATURE_TAG = "Creature";
    private const string PICTURED_TAG = "Pictured";
    private const float RAYCAST_DISTANCE = 15f;

    [SerializeField] private AudioSource audioSource;

    public void ScreenShotting()
    {
        audioSource.Play();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RAYCAST_DISTANCE) && hit.collider.gameObject.CompareTag(CREATURE_TAG))
        {
            // Store original camera settings
            RenderTexture originalRT = cam.targetTexture;
            float originalFOV = cam.fieldOfView;
            float originalNear = cam.nearClipPlane;
            float originalFar = cam.farClipPlane;

            try
            {
                // Create high-quality render texture
                RenderTexture rt = RenderTexture.GetTemporary(
                    screenshotWidth,
                    screenshotHeight,
                    24, // depth buffer bits
                    renderFormat,
                    RenderTextureReadWrite.Default,
                    antiAliasing
                );

                // Apply temporary camera settings for better composition
                if (useTemporarySettings)
                {
                    cam.fieldOfView = tempFOV;
                    cam.nearClipPlane = tempNearClip;
                    cam.farClipPlane = tempFarClip;
                }

                // Setup camera for high-quality rendering
                cam.targetTexture = rt;

                // Render with high quality
                cam.Render();

                // Read pixels from render texture
                RenderTexture.active = rt;
                Texture2D screenshot = new Texture2D(screenshotWidth, screenshotHeight, TextureFormat.RGBA32, false);
                screenshot.ReadPixels(new Rect(0, 0, screenshotWidth, screenshotHeight), 0, 0, false);
                screenshot.Apply();

                // Clean up
                RenderTexture.active = null;
                cam.targetTexture = originalRT;
                RenderTexture.ReleaseTemporary(rt);

                // Restore original camera settings
                if (useTemporarySettings)
                {
                    cam.fieldOfView = originalFOV;
                    cam.nearClipPlane = originalNear;
                    cam.farClipPlane = originalFar;
                }

                // Tag the creature and related objects
                GameObject hitObj = hit.collider.gameObject;
                hitObj.tag = PICTURED_TAG;
                hitObj.GetComponent<BoxCollider>().enabled = false;

                GameObject[] sameCreatures = hitObj.GetComponent<Creature>().SameCreature;
                if (sameCreatures != null)
                {
                    for (int i = 0; i < sameCreatures.Length; i++)
                    {
                        sameCreatures[i].tag = PICTURED_TAG;
                        sameCreatures[i].GetComponent<BoxCollider>().enabled = false;
                    }
                }

                // Display screenshot
                display.AddPicture(screenshot);
                resultPanelManager.ResultUpdate(hitObj, screenshot);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Screenshot failed: {e.Message}");

                // Restore settings in case of error
                cam.targetTexture = originalRT;
                if (useTemporarySettings)
                {
                    cam.fieldOfView = originalFOV;
                    cam.nearClipPlane = originalNear;
                    cam.farClipPlane = originalFar;
                }
            }
        }
    }
}