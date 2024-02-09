using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    // The function called from the Animation Event
    public void OnAnimationEnd()
    {
        // Increment the animation parameter (assuming it's a float or integer)
        int currentParameterValue = animator.GetInteger("Anim"); // Assuming it's an integer parameter, change accordingly for other types
        currentParameterValue++; // Increment the parameter value
        animator.SetInteger("Anim", currentParameterValue); // Set the updated value
    }
}
