using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleAnimator : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

    public void PlayNamedAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
    }
}
