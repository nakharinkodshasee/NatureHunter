using UnityEngine;

public class XRFootStep : MonoBehaviour
{
    public AudioSource stepSound;
    public AudioClip footstepClip;
    public float stepInterval = 0.5f;
    
    private float stepTimer;
    private Vector3 lastPos;
    
    void Start()
    {
        lastPos = transform.position;
        if (stepSound == null) stepSound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (stepSound == null || footstepClip == null) return;
        
        Vector3 currentPos = transform.position;
        float distance = Vector2.Distance(
            new Vector2(currentPos.x, currentPos.z),
            new Vector2(lastPos.x, lastPos.z)
        );
        lastPos = currentPos;
        
        if (distance > 0.01f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                stepSound.PlayOneShot(footstepClip);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}
