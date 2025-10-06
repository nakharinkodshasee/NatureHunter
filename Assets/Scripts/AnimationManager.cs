using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    [SerializeField] private Animator[] animators;
    void Start()
    {
        foreach (Animator animator in animators)
        {
            NullCheck(animator);
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0f);
        }
    }

    private void NullCheck(Animator animator)
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator reference is missing!", this);

            return;
        }
    }
}
