using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InfoUI : MonoBehaviour
{
    GameManager gameManager;
    Board board;

    TextMeshProUGUI actionCountTMP;
    TextMeshProUGUI findMineTMP;
    TextMeshProUGUI notFindMineTMP;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        Transform g_child = child.GetChild(1);
        actionCountTMP = g_child.GetComponent<TextMeshProUGUI>();

        child = transform.GetChild(1);
        g_child = child.GetChild(1);
        findMineTMP = g_child.GetComponent<TextMeshProUGUI>();

        child = transform.GetChild(2);
        g_child = child.GetChild(1);
        notFindMineTMP = g_child.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        board = gameManager.Board;

        gameManager.onGameClear += GameClear;

        gameManager.onGameReady += OnGameReady;

        board.onAction += PlusAction;
        board.onMinCount += MineCount;
    }

    private void MineCount(int arg1, int arg2)
    {
        board.onAction -= PlusAction;
        findMineTMP.text = arg1.ToString();
        notFindMineTMP.text = arg2.ToString();

    }

    private void PlusAction(int obj)
    {
        actionCountTMP.text = obj.ToString();
    }

    private void OnGameReady()
    {
        actionCountTMP.text =  "???";
        findMineTMP.text = "???";
        notFindMineTMP.text = "???";
        board.onAction += PlusAction;
    }

    private void GameClear()
    {
        board.onAction -= PlusAction;
    }
}
