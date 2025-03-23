using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHeartSpawner : AResetable
{
    public override void ResetItem()
    {   
        gameObject.SetActive(false);
    }
}
