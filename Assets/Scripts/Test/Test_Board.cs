using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Board : TestBase
{
    Board board;

    public int width = 8;
    public int height = 8;
    public int mineCount = 3;

    private void Start()
    {
        board = FindAnyObjectByType<Board>();
    }
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        board.Initialize(width, height, mineCount);
    }
}
