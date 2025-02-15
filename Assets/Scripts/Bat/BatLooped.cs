using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLooped : BatController
{
    
    protected override void ChangeIndex()
    {
            if (Vector3.Distance(transform.position, points[index]) < 0.2) 
            { 
                index++;
            }

        if (index == points.Count)
        {
          
            index = 0;
        }
    }
}


