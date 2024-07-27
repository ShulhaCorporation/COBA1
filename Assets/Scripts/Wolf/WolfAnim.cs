using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnim : MonoBehaviour
{
    private Animator animator;
    private WolfController controller;
    void Start()
    {
        controller = gameObject.GetComponent<WolfController>();
        animator = gameObject.GetComponent<Animator>();
        controller.OnJump += Jump;
        controller.OnLand += Walk;
    }
    
    void Jump()
    {
        animator.SetBool("isJumping", true);
    }
    void Walk()
    {
        animator.SetBool("isJumping",  false);
    }
}
