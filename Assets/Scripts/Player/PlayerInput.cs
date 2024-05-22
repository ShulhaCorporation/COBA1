using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    private KeyCode rightKey;

    [SerializeField]
    private KeyCode leftKey;

    [SerializeField]
    private KeyCode flyKey;

    [SerializeField]
    private KeyCode downKey;

    [SerializeField]
    private KeyCode escape;

    public bool IsRightPressed { get; set; } = false;
    public bool IsLeftPressed { get; set; } = false;
    public bool IsDownPressed { get; set; } = false;
    public bool IsFlyPressed { get; set; } = false;
    public bool IsEscPressed { get; set; } = false;



    // Update is called once per frame
   void Update()
    {
        IsRightPressed = Input.GetKey(rightKey);
        IsLeftPressed = Input.GetKey(leftKey);
        IsDownPressed = Input.GetKey(downKey);
        IsFlyPressed = Input.GetKey(flyKey);
        IsEscPressed = Input.GetKey(escape);
    }
}
