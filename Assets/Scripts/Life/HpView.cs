using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class HpView: MonoBehaviour
{
    private Vector3 scale;

    [SerializeField]
    private LifeSystem lifeSystem;

    [SerializeField]
    private int count;

    [SerializeField]
    private float animationSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        scale = transform.localScale;
        if(lifeSystem.Hp < count && scale.x >= 0)
        {
           transform.localScale -= new Vector3(1f, 1f, 0f) * animationSpeed * Time.deltaTime;
        }
    }
   public void Reset()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}