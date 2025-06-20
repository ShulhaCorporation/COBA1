using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detonator : AResetable
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
    private List<LightController> lights;
 /*   [SerializeField]
    private List<ParticleSystem> particles;  Я не знаю, чи треба додавати частинки, вони виглядають всрато*/
    [SerializeField]
    private GameObject barrier;
    [SerializeField]
    private GameObject dynamites;
    [SerializeField]
    private Button pauseButton;
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
    {   pauseButton.enabled = false;
        barrier.SetActive(true);
        yield return new WaitForSeconds(0.550f);
       
        blindfold.Enable(true);
        yield return new WaitForSeconds(2.2f);
        cameraFollow.SetObject(cameraCenter.transform); 
         blindfold.Enable(false);
        yield return new WaitForSeconds(1.2f);
        dynamites.SetActive(false);
      /*  foreach (ParticleSystem particle in particles)
        {   
            particle.Play();
        }*/
        foreach (LightController light in lights)
        {
            light.Explode();
        }
        yield return new WaitForSeconds(1.0f);
        blockage.SetActive(false);
        foreach (LightController light in lights)
        {
            light.TurnOff();
        }
    
        yield return new WaitForSeconds(3f);
        blindfold.Enable(true);
        yield return new WaitForSeconds(2.2f);
        cameraFollow.ResetCamera();
        blindfold.Enable(false);
        barrier.SetActive(false);
        pauseButton.enabled = true;
    }

    public override void ResetItem()
    {
       wasActivated = false;
       pauseButton.enabled = true;
       barrier.SetActive(false);
        blockage.SetActive(true);
        dynamites.SetActive(true);
    }
}
