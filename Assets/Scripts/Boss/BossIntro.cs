using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : iState
{ private BossStates bossStates;
    private Rigidbody2D rigidbody;
    private float speed;
    private float requiredAltitude;
    public BossIntro(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }
    public void EndState()
    {
       
    }

    public void StartState()
    {
       rigidbody = bossStates.GetComponent<Rigidbody2D>();
        speed = bossStates.speed1;
        requiredAltitude = bossStates.reqAltitude;
    }

    public void UpdateState()
    {
        if(bossStates.transform.position.y - requiredAltitude <= 0.03)
        {
            bossStates.Transition(bossStates.phase1);
        }
        rigidbody.velocity = Vector3.down * Time.deltaTime * speed;
    }
}
