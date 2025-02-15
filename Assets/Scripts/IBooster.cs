using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBooster
{
    // o6'eDHye 6ycTepu B oDHy rpyny
      
    public event Action OnBoosterActivation;
    public void SetPosition(Vector3 position);
    public void SetActive(bool mode);
}
