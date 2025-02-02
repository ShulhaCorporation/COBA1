using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class BossSubscriber : MonoBehaviour
{
    [SerializeField]
    private TriggerBoss triggerBoss;
    [SerializeField]
    private GameObject cameraCenter;
    [SerializeField]
    private CameraFollow camera;
    [SerializeField]
    private CameraZoom zoom;
    [SerializeField]
    private float scale;
    [SerializeField]
    private float duration;
    [SerializeField]
    private SpinGear gear;
    [SerializeField]
    private Movement movement;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Rigidbody2D wall;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject checkpoint;
    [SerializeField]
    private GameObject timerLabel;
    [SerializeField]
    private Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        triggerBoss.OnBossTriggered += TriggerBoss_OnBossTriggered;
    }

    private void TriggerBoss_OnBossTriggered()
    {
        StartCoroutine(Cutscene());
       
        
    }
    IEnumerator Cutscene()
    {
        gear.StartSpinning(true);
        movement.CutsceneMode(true);
        checkpoint.SetActive(true);
        pauseButton.interactable = false;
        yield return new WaitForSeconds(2);
        timer.StartTime();
        timerLabel.SetActive(true);
        yield return new WaitForSeconds(1);
        camera.SetObject(cameraCenter.transform, 2);
        zoom.ScaleCamera(scale, duration);
        yield return new WaitForSeconds(3);
        wall.gravityScale = 1;
        wall.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(0.5f);
        particles.Play();
        boss.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        movement.CutsceneMode(false);
        wall.constraints = RigidbodyConstraints2D.FreezeAll;
        pauseButton.interactable = true;

    }
}
