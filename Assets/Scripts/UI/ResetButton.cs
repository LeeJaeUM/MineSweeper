using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    Button button;
    GameManager gameManager;
    Board board;
    Image image;

    public enum ResetButtonType
    {
        Smile = 0,
        Surprise,
        GameOver,
        GameClear
    };

    public Sprite[] resetbuttonSprite;
    public Sprite this[ResetButtonType type] => resetbuttonSprite[(int)type];

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void Start()
    {
        board = FindAnyObjectByType<Board>();
        board.onCellPress += Surprise;
        board.onCellRelease += ReSmile;

        gameManager = GameManager.Instance;
        gameManager.onGameReady += Smile;
        gameManager.onGameOver += GameOver;
        gameManager.onGameClear += GameClear;

        button.onClick.AddListener(OnClick);
    }

    private void Surprise()
    {
        if (image.sprite != this[ResetButtonType.GameOver] && image.sprite != this[ResetButtonType.GameClear])
        {
            image.sprite = this[ResetButtonType.Surprise];
        }
    }

    private void ReSmile()
    {
        if (image.sprite != this[ResetButtonType.GameOver] && image.sprite != this[ResetButtonType.GameClear])
        {
            image.sprite = this[ResetButtonType.Smile];
        }
    }

    private void Smile()
    {
        image.sprite = this[ResetButtonType.Smile];
    }

    private void GameClear()
    {
        image.sprite = this[ResetButtonType.GameClear];
    }

    private void GameOver()
    {
        image.sprite = this[ResetButtonType.GameOver];
    }



    private void OnClick()
    {
        GameManager.Instance.GameReset();
    }
}
