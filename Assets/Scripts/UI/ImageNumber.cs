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
                number = value;
                NumberSelect(number);
            }
        }
    }

    public Sprite[] numbers;
    [SerializeField] private Image[] childImages;

    private void Awake()
    {
        childImages = GetComponentsInChildren<Image>();
    }

    public void NumberSelect(int number)
    {
        int findNumber = 0;
        int next = number;
        if(number >= 0) 
        { 
            for(int i = 0; i < childImages.Length; i++)
            {
                findNumber = next % 10;
                childImages[i].sprite = numbers[findNumber];
                next = next / 10;
            }
        }
        else
        {
            int minusCount = 0;
            next *= -1;
            for (int i = 0; i < childImages.Length; i++)
            {
                if(minusCount > 0)
                {
                    childImages[i].sprite = numbers[11];
                    continue;
                }

                if(next == 0)
                {
                    childImages[i].sprite = numbers[10];
                    minusCount++;
                }
                else
                {
                    findNumber = next % 10;
                    childImages[i].sprite = numbers[findNumber];
                    next = next / 10;
                }
            }
        }

    }

}
