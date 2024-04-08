using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Press : TestBase
{
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        GameManager.Instance.Board.Test_BoardReset();
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        base.OnTest2(context);
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        base.OnTest3(context);
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        base.OnTest4(context);
    }
}
