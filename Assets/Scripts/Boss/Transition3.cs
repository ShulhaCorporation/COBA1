using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Transition3 : iState
{
    private BossStates bossStates;
    private Cart cart;
    public Transition3(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }
    public void StartState()
    {
       cart = bossStates.cart;
        cart.OnCartStop += EndTransition;
        cart.Setup();
    }

    public void UpdateState()
    {

    }

    public void EndState()
    {
        
        
    }

    public void ResetState()
    {

    }
    private void EndTransition()
    {
        bossStates.Transition(bossStates.phase4);
        cart.OnCartStop -= EndTransition;
    }
}
