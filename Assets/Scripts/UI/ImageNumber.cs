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
        int count = 2;
        if(number >= 0) 
        { 
            for(int i = 0; i < childImages.Length; i++)
            {
                findNumber = next % 10;
                childImages[count].sprite = numbers[findNumber];
                next = next / 10;
                count--;
            }
        }
        else
        {
            next *= -1;
            for (int i = 0; i < childImages.Length; i++)
            {
                if(next == 0)
                {
                    childImages[count].sprite = numbers[10];
                }
                else
                {
                    findNumber = next % 10;
                    childImages[count].sprite = numbers[findNumber];
                    next = next / 10;
                }
                count--;
            }
        }

    }

}
