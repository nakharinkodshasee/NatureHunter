using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPauser : MonoBehaviour
{
    [SerializeField] private Animator[] animators;

    void Start()
    {
        PauseAnimation();
        ResumeAnimation();
    }
    public void PauseAnimation()
    {
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
    }

    public void ResumeAnimation()
    {
        foreach (Animator animator in animators)
        {
            animator.enabled = true;
        }
    }
}
