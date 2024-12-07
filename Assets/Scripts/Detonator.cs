using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{    private Animator animator;
    [SerializeField] 
    private GameObject blockage;
    [SerializeField]
    private GameObject blackScreen;
    private Blindfold blindfold;
    private bool wasActivated = false;
    void Start()
    { blindfold = blackScreen.GetComponent<Blindfold>();
      animator = gameObject.GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !wasActivated)
        {
            animator.SetTrigger("Activate");
            StartCoroutine(CutScene());
            Destroy(blockage);
            
            wasActivated = true;
        }
    }
    IEnumerator CutScene()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(0.550f);
        Debug.Log("2");
        blindfold.Enable(true);
        yield return new WaitForSeconds(1.2f);
        Debug.Log("3");
        blindfold.Enable(false);
    }
}
