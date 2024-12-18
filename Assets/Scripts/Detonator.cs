using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{    private Animator animator;
    [SerializeField] 
    private GameObject blockage;
    [SerializeField]
    private GameObject blackScreen;
    [SerializeField]
    private CameraFollow cameraFollow;
    [SerializeField]
    private GameObject cameraCenter;
    [SerializeField]
    private List<GameObject> particles;
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
          
            
            wasActivated = true;
        }
    }
    IEnumerator CutScene()
    {
      
        yield return new WaitForSeconds(0.550f);
       
        blindfold.Enable(true);
        yield return new WaitForSeconds(1.5f);
        cameraFollow.SetObject(cameraCenter.transform); 
         blindfold.Enable(false);
        yield return new WaitForSeconds(1.2f);
        foreach (GameObject particle in particles)
        {
            particle.SetActive(true);
        }
        yield return new WaitForSeconds(0.4f);
        Destroy(blockage);
        yield return new WaitForSeconds(3f);
        blindfold.Enable(true);
        yield return new WaitForSeconds(1.5f);
        cameraFollow.ResetCamera();
        blindfold.Enable(false);

    }
}
