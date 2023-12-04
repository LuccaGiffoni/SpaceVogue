using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartContinuousGlow()
    {
        animator.SetTrigger("Continuous");
    }
}