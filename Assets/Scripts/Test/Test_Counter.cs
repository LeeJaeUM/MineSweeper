using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Counter : TestBase
{
    FlagCounter flagCounter;
    [Range(-99, 999)]
    public int testInt = 0;
    private void Start()
    {
        flagCounter = FindAnyObjectByType<FlagCounter>();
    }

    private void Update()
    {
        GameManager.Instance.TestFlagCounter(testInt);
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
       
    }

}
