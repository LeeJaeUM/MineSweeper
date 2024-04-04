using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ImageNumber : TestBase
{
    public ImageNumber imageNumber;
    [Range(-99, 999)]
    public int testInt = 0;

    private void Awake()
    {
        imageNumber = FindAnyObjectByType<ImageNumber>();
    }

    private void Update()
    {
        imageNumber.Number = testInt;
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
       
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect();
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect();
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect();
    }

}
