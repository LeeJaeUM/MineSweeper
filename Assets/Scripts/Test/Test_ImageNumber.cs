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

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        StartCoroutine(Test());
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

    IEnumerator Test()
    {
        int t = -99;
        while(t < 1000)
        {
            imageNumber.NumberSelect(t);
            yield return new WaitForSeconds(0.01f);
            t++;
        }
    }
}
