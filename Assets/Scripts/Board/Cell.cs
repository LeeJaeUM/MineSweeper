using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    /// 보드 입력에 따른 cover이미지 변경
    /// 열기 / 닫기 
    
    
    int? id = null; 

    public int ID
    {
        get => id.GetValueOrDefault(); // 0일 경우 맞을 수도 있고 아닐 수도 있다.
        set
        {
            if (id == null)     //이 프로퍼티는 한 번만 설정 가능하다.
            {
                id = value;
            }
        }
    }

    /// <summary>
    /// 겉면의 스프라이트 렌더러
    /// </summary>
    [SerializeField] SpriteRenderer cover;

    /// <summary>
    /// 안쪽의 스프라이트 렌더러
    /// </summary>
    [SerializeField] SpriteRenderer inside;

    bool hasMine = false;
    public bool HasMine => hasMine;

    Board parentBoard = null;
    public Board Board
    {
        get => parentBoard;
        set
        {
            if(parentBoard == null) 
                parentBoard = value;
        }
    }


    private void Awake()
    {
        Transform child = transform.GetChild(0);
        cover = child.GetComponent<SpriteRenderer>();

        child = transform.GetChild(1);
        inside = child.GetComponent<SpriteRenderer>();


    }

    public void ResetData()
    {
        Board = FindAnyObjectByType<Board>();
        hasMine = false;
        cover.sprite = Board[CloseCellType.Close];
        inside.sprite = Board[OpenCellType.Empty];
        cover.gameObject.SetActive(true);
    }

    /// <summary>
    /// 지뢰 배치 여부에 따라 inside 이미지 변경
    /// </summary>
    public void SetMine()
    {
        hasMine = true;
        inside.sprite = Board[OpenCellType.Mine];
    }


#if UNITY_EDITOR
    public void Test_OpenCover()
    {
        cover.gameObject.SetActive(false);
    }
#endif
}
