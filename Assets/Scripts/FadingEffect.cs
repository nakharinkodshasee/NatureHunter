using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator FadingOut()
    {
        while (spriteRenderer.color.a > 1f)
        {
            Color c = spriteRenderer.color;
            c.a -= 1f * Time.deltaTime;
            spriteRenderer.color = c;
            yield return null;
        }
    }

    public IEnumerator FadingIn()
    {
        while (spriteRenderer.color.a < 1f)
        {
            Color c = spriteRenderer.color;
            c.a += 1f * Time.deltaTime;
            spriteRenderer.color = c;
            yield return null;
        }
    }
}
