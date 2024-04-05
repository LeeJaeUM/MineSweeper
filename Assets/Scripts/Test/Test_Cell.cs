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


}
