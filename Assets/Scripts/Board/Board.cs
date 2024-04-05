using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Board : MonoBehaviour
{
    /// 셀을 생성하고 관리 (리셋, 지뢰 설치 등등)
    public GameObject cellPrefab;

    int width = 16;
    int height = 16;
    int mineCount = 10;

    [SerializeField] Cell[] cells = null;

    const float Distance = 1.0f;

    PlayerInputActions inputAction;

    private void Awake()
    {
        //inputAction = new PlayerInputActions();
        //GameManager manager = GameManager.Instance;
        //manager.onGameReady += RefreshBoard;
        //manager.onGamePlay += ;
        //manager.onGameClear += ;
        //manager.onGameOver += ;
    }

    #region InputActions

    //private void OnEnable()
    //{
    //    inputAction.Player.Enable();
    //}
    //private void OnDisable()
    //{
    //    inputAction.Player.Disable();
    //}

    #endregion

    public void Initialize(int newWidth, int newHeight, int newMineCount)
    {
        width = newWidth;
        height = newHeight;
        mineCount = newMineCount;

        cells = new Cell[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject cellObj = Instantiate(cellPrefab, transform);
                Cell cell = cellObj.GetComponent<Cell>();
                cell.transform.localPosition = new Vector3(x * Distance, -y * Distance);

                int id = x + y * width;
                cells[id] = cell;
                cellObj.name = $"Cell_{id}_({x},{y})";
            }
        }
    }

    void RefreshBoard()
    {

    }

    /// 입력에 따라 셀 변환

    /// 게임 상태 변환


}