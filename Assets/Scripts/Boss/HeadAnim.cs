using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System;
public class HeadAnim : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
        
      public void OpenForSec(float time)
    {
       StartCoroutine(Open(time));
    }
    IEnumerator Open(float time)
    {
        animator.SetBool("isOpen", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("isOpen", false);
    }
    public void TalkForSec(float time)
    {
        StartCoroutine(Talk(time));
    }
    IEnumerator Talk(float time)
    {
        animator.SetTrigger("talk");
        yield return new WaitForSeconds(time);
        animator.SetTrigger("shut");
    }
   }
