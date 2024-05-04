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

    public bool IsRightPressed { get; set; } = false;
    public bool IsLeftPressed { get; set; } = false;
    public bool IsFlyPressed { get; set; } = false;



    // Update is called once per frame
    void Update()
    {
        IsRightPressed = Input.GetKey(rightKey);
        IsLeftPressed = Input.GetKey(leftKey);
        IsFlyPressed = Input.GetKey(flyKey);
    }
}
