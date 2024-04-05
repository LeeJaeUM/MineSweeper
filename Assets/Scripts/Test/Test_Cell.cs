using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Cell : TestBase
{
    public Cell cell;

    private void Start()
    {
        cell = FindAnyObjectByType<Cell>();
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        cell.InsideSpriteSelect();
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        cell.InsideSpriteSelect(true);
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        cell.Press();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        cell.Close();
    }
}
