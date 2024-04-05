using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    /// 보드 입력에 따른 cover이미지 변경
    /// 열기 / 닫기 
    
    [SerializeField] SpriteRenderer coverRenderer;
    [SerializeField] SpriteRenderer insideRenderer;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        coverRenderer = child.GetComponent<SpriteRenderer>();

        child = transform.GetChild(1);
        insideRenderer = child.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 지뢰 배치 여부에 따라 inside 이미지 변경
    /// </summary>
    public void InsideSpriteSelect(bool isBoom = false)
    {
        //이 셀이 폭탄일 경우
        if (isBoom)
        {

        }
        //폭탄이 아닐 경우
        else
        {

        }
    }

    /// <summary>
    /// 누른 상태 유지 시 보여줄 기본 inside
    /// </summary>
    public void Press()
    {
        coverRenderer.sortingOrder = -1;
    }

    /// <summary>
    /// 다시 cover를 씌운다
    /// </summary>
    public void Close()
    {
        coverRenderer.sortingOrder = 10;
    }
}
