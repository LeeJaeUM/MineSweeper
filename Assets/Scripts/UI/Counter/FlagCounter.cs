using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCounter : CounterBase
{
    int flagCount = 0;
    public int FlagCount
    {
        get => flagCount;
        set
        {
            flagCount = value;
            Refresh(flagCount);
        }
    }

    private void OnEnable()
    {
        FlagCount = GameManager.Instance.mineCount;
    }

    private void Start()
    {
        GameManager.Instance.onFlagCountChange += Refresh;
        Refresh(flagCount);
    }

}
