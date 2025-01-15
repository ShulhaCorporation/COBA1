using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentLevel{
    Horizontal,
    Vertical,
    Moving
}


public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private CurrentLevel currentLevel;
    private CurrentLevel saveLevel;
    [SerializeField]
    private Transform objectiv;
    [SerializeField]
    private Transform player;
    private Rigidbody2D rigidbody;
    private Vector2 distance;
    public void SetObject(Transform transform)
    {
        objectiv = transform;
    }
    public void SetObject(Transform transform, float speed)
    {

        objectiv = transform;
        distance = objectiv.position - this.transform.position;
        currentLevel = CurrentLevel.Moving;
        StartCoroutine(Moving(speed));
    }
    void Start()
    {
        objectiv = player;   
        saveLevel = currentLevel;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ResetCamera() { 
        objectiv = player;
    }
    void Update()
    {    if (currentLevel == CurrentLevel.Horizontal)
        {
            this.transform.position = new Vector3(objectiv.position.x, transform.position.y, transform.position.z);
        }
        else if (currentLevel == CurrentLevel.Vertical)
        {
            this.transform.position = new Vector3(objectiv.position.x, objectiv.position.y, transform.position.z);
        }
    }
    IEnumerator Moving(float speed)
    {
        rigidbody.velocity += distance.normalized * speed;

        yield return new WaitForSeconds(3.4f);
        currentLevel = saveLevel;
    }
}
