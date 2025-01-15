using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iState 
{
    public void StartState();
    public void UpdateState();
    public void EndState();
}
