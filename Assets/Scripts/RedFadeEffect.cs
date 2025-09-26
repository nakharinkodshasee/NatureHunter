using UnityEngine;
using UnityEngine.UI;

public class RedFadeEffect : MonoBehaviour
{
    [SerializeField] private Image redImage;
    [SerializeField] private float fadeSpeed = 2f; // Controls how fast the image fades
    [SerializeField] private float maxAlpha = 0.7f; // The maximum alpha value (transparency)
    private const float SinOffset = 1f;
    private const float SinDivisor = 2f;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        // Calculate the alpha (transparency) value using a sine wave
        // Time.time increases continuously, so Mathf.Sin(Time.time * fadeSpeed) oscillates between -1 and 1
        // Adding 1 shifts the range to 0–2, and dividing by 2 makes it 0–1
        // Multiplying by 0.7 limits the alpha range to 0–0.7 for a soft pulsing effect
        float alpha = (Mathf.Sin(Time.time * fadeSpeed) + SinOffset) / SinDivisor * maxAlpha;

        Color color = redImage.color;
        color.a = alpha;
        redImage.color = color;
    }
}
