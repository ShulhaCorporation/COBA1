using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    [SerializeField]
    private int id;
    [SerializeField]
    private bool disabledByDefault = false;
    private Animator animation;
    public event Action<Vector3, int, List<AResetable>> OnCheckpointEntered;
    [SerializeField] private List<AResetable> resetables;
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
        StartCoroutine(DisableCheckpoint());
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"){
            OnCheckpointEntered(this.transform.position, id, resetables);
            animation.SetTrigger("Activated");
        }
    }
    IEnumerator DisableCheckpoint() // очікування, щоб CheckpointController встиг зареєструвати чекпоїнт до вимкнення
    {
        yield return new WaitForEndOfFrame();
        if (disabledByDefault)
        {
            gameObject.SetActive(false);
        }
    }
}
     