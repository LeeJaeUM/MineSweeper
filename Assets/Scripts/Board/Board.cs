using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Board : MonoBehaviour
{
    /// 셀을 생성하고 관리 (리셋, 지뢰 설치 등등)
    /// 입력에 따라 셀 변환
    /// 게임 상태 변환

    [SerializeField] Cell[] cells = null;

    float x;
    public float X
    {
        get => x; set => x = value;
    }

    float y;
    public float Y
    {
        get => y; set => y = value;
    }

    public int width = 8;
    public int height = 8;

    PlayerInputActions inputAction;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        GameManager manager = GameManager.Instance;
        manager.onGameReady += RefreshBoard;
        //manager.onGamePlay += ;
        //manager.onGameClear += ;
        //manager.onGameOver += ;
    }

    #region InputActions

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }
    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    #endregion

    private void InitializedBoard()
    {

    }

    void RefreshBoard()
    {

    }
    



}