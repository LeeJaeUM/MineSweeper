using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageNumber : MonoBehaviour
{
    int number = 0;
    public int Number
    {
        get => number;
        set
        {
            if(number != value)
            {
                number = Mathf.Clamp(value, -99, 999);
                NumberSelect();
                //Refresh();
            }
        }
    }

    public Sprite[] numberSprites;

    //가독성을 위한 일부 스프라이트 프로퍼티로 설정
    Sprite ZeroSprite => numberSprites[0];
    Sprite EmptySprite => numberSprites[10];
    Sprite MinusSprite => numberSprites[11];

    [SerializeField] private Image[] childImages;

    private void Awake()
    {
        childImages = GetComponentsInChildren<Image>();
    }

    public void NumberSelect()
    {
        //이미지에 넣을 숫자
        int findNumber = 0;
        int next = Number;
        if(Number >= 0)     //플러스 일때
        { 
            for(int i = 0; i < childImages.Length; i++)
            {
                findNumber = next % 10;
                childImages[i].sprite = numberSprites[findNumber];
                next = next / 10;
            }
        }
        else    //마이너스일때
        {
            int minusCount = 0;
            next *= -1;
            for (int i = 0; i < childImages.Length; i++)
            {
                if(minusCount > 0)
                {
                    childImages[i].sprite = EmptySprite;
                    continue;
                }

                if(next == 0)
                {
                    childImages[i].sprite = MinusSprite;
                    minusCount++;
                }
                else
                {
                    findNumber = next % 10;
                    childImages[i].sprite = numberSprites[findNumber];
                    next = next / 10;
                }
            }
        }

    }

    void Refresh()
    {
        int temp = Mathf.Abs(Number);           //양수로 처리

        Queue<int> digits = new Queue<int>(3);  //temp 자리 수 별수 자른 수를 저장할 큐

        //자리 수 별로 Number를 나누어서 child(digit) 큐에 담기
        while(temp > 0)
        {
            digits.Enqueue(temp % 10);
            temp /= 10;
        }

        //이미지 표시하기
        int index = 0;
        while(digits.Count > 0)
        {
            int num = digits.Dequeue();                     //큐에서 하나씩 꺼내서
            childImages[index].sprite = numberSprites[num]; //스프라이트 설정
            index++;
        }

        for(int i = 0; index < childImages.Length; index++)
        {
            childImages[i].sprite = ZeroSprite;
        }

        //음수일 경우
        if(Number < 0)
        {
            childImages[childImages.Length -1].sprite = MinusSprite; // 앞에 - 붙이기
        }
    }

}
