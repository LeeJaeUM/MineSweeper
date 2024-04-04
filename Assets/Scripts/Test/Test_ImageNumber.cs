using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ImageNumber : TestBase
{
    public ImageNumber imageNumber;
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect(123);
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect(45);
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect(1);
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect(-65);
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        imageNumber.NumberSelect(-5);
    }
}
