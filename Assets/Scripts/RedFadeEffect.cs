using UnityEngine;
using UnityEngine.UI;

public class RedFadeEffect : MonoBehaviour
{
    public Image redImage;
    public float fadeSpeed = 2f;
    
    private void Update()
    {
        // Calculate the alpha (transparency) value using a sine wave
        float alpha = (Mathf.Sin(Time.time * fadeSpeed) + 1f) / 2f * 0.7f;
        
        Color color = redImage.color;
        color.a = alpha;
        redImage.color = color;
    }
}
