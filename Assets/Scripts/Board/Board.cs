using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Board : MonoBehaviour
{
    /// 셀을 생성하고 관리 (리셋, 지뢰 설치 등등)
    public GameObject cellPrefab;

    /// <summary>
    /// 보드의 가로길이
    /// </summary>
    int width = 16;

    /// <summary>
    /// 보드의 세로 길이
    /// </summary>
    int height = 16;

    /// <summary>
    /// 배치될 지회의 개수
    /// </summary>
    int mineCount = 10;

    /// <summary>
    /// 이 보드가 생성한 모든 셀
    /// </summary>
    Cell[] cells = null;

    /// <summary>
    /// 셀 한 변의 크기
    /// </summary>
    const float Distance = 1.0f;

    PlayerInputActions inputAction;

    public Sprite[] openCellImage;
    public Sprite this[OpenCellType type] => openCellImage[(int)type];
    public Sprite[] closeCellImage;
    public Sprite this[CloseCellType type] => closeCellImage[(int)type];

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        //GameManager manager = GameManager.Instance;
        //manager.onGameReady += RefreshBoard;
        //manager.onGamePlay += ;
        //manager.onGameClear += ;
        //manager.onGameOver += ;
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
        inputAction.Player.LeftClick.performed += OnLeftPress;  //왼쪽 버튼 눌렀을때
        inputAction.Player.LeftClick.canceled += OnLeftRelease; //왼 쪽 버 튼 떼 ㅆ을 때
        inputAction.Player.RightClick.performed += OnRightClick;    //우측 마우스 버튼 클릭했을떄
        inputAction.Player.MouseMove.performed += OnMouseMove;      //마우스의 움직임 
    }
    private void OnDisable()
    {
        inputAction.Player.MouseMove.performed -= OnMouseMove;
        inputAction.Player.RightClick.performed -= OnRightClick;
        inputAction.Player.LeftClick.canceled -= OnLeftRelease;
        inputAction.Player.LeftClick.performed -= OnLeftPress;
        inputAction.Player.Disable();
    }

    /// <summary>
    /// 이 보드가 가질 모든 셀을 생성하고 배치하는 함수
    /// </summary>
    /// <param name="newWidth">보드의 가로길이</param>
    /// <param name="newHeight">보드의 세로길이</param>
    /// <param name="newMineCount">설치될 지뢰의 개수</param>
    public void Initialize(int newWidth, int newHeight, int newMineCount)
    {
        width = newWidth;
        height = newHeight;
        mineCount = newMineCount;

        //셀 배열 만들기
        cells = new Cell[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject cellObj = Instantiate(cellPrefab, transform);
                Cell cell = cellObj.GetComponent<Cell>();
                cell.transform.localPosition = new Vector3(x * Distance, -y * Distance);

                int id = x + y * width;
                cell.ID = id;
                cells[id] = cell;
                cellObj.name = $"Cell_{id}_({x},{y})";
            }
        }
        ResetBoard();
        MineCreate();
    }

    private void MineCreate()
    {
        for(int x = 0; x < 10;x++)
        {
            cells[x].SetMine();
        }
    }

    private void ResetBoard()
    {
        foreach (Cell cell in cells)
        {
            cell.ResetData();
        }


    }

    /// <summary>
    /// 스크린좌표를 그리드좌표로 볌ㄴ환하는 함수
    /// </summary>
    /// <param name="screen">스크린ㄷ좌표</param>
    /// <returns>변환된 그리드좌표</returns>
    Vector2Int ScreenToGrid(Vector2 screen)
    {
        Vector2 world = Camera.main.ScreenToWorldPoint(screen);
        Vector2 diff = world - (Vector2)transform.position;

        return new Vector2Int(Mathf.FloorToInt( diff.x / Distance), Mathf.FloorToInt(-diff.y / Distance));
    }

    /// <summary>
    /// 그리드좌표를 인댁스로 변환 하는 함수
    /// </summary>
    /// <param name="x">x좌표</param>
    /// <param name="y">y좌표</param>
    /// <returns></returns>
    int? GridToIndex(int x, int y)
    {
        int? result = null;
        if(IsValidGrid(x,y))
        {
            result = x + y * height;
        }

        return result;
    }

    /// <summary>
    /// 지정된 그리드 좌표가 보드 내부인지 확인하느 ㄴ함수
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>보드 안이라면 true</returns>
    bool IsValidGrid(int x, int y) 
    { 
        return x >= 0 && y >= 0 && x < width && y < height;
    }

    /// <summary>
    /// 특정 스크린 좌표에 ㅣㅇ?ㅆㄴ,ㄴ 셀을 리턴하는 함수
    /// </summary>
    /// <param name="screen"></param>
    /// <returns></returns>
    Cell GetCell(Vector2 screen)
    {
        Cell result = null;
        Vector2Int grid = ScreenToGrid(screen);
        int? index = GridToIndex(grid.x, grid.y);
        if(index != null)
        {
            result = cells[index.Value];
        }

        return result;
    }

    #region InputActions 함수 ---------------------------------------------------------

    // 입력에 따라 셀 변환
    private void OnLeftPress(InputAction.CallbackContext context)
    {
        Vector2 screen = Mouse.current.position.ReadValue();
        Cell testcell = GetCell(screen);
        if(testcell == null)
        {
            Debug.Log("ㅇ벗어");
        }
        else
        {
            Debug.Log($"{testcell.gameObject.name}");
        }

    }
    private void OnLeftRelease(InputAction.CallbackContext context)
    {
        Vector2 scress = Mouse.current.position.ReadValue();
    }

    private void OnRightClick(InputAction.CallbackContext context)
    {
        Vector2 scress = Mouse.current.position.ReadValue();
    }
    private void OnMouseMove(InputAction.CallbackContext context)
    {
        Vector2 scress = Mouse.current.position.ReadValue();
    }
    #endregion


#if UNITY_EDITOR
    public void Test_OpenAllCover()
    {
        foreach (Cell cell in cells)
        {
            cell.Test_OpenCover();
        }
    }
#endif
}