using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImageNumber))]
public class CounterBase : MonoBehaviour
{
    ImageNumber imageNumber;

    protected virtual void Awake()
    {
        imageNumber = GetComponent<ImageNumber>();
    }

    /// <summary>
    /// number를 표시하는 함수
    /// </summary>
    /// <param name="count">표시될 숫자</param>
    protected void Refresh(int count)
    {
        imageNumber.Number = count;
    }
}
