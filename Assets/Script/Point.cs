using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    [SerializeField] UITopBar uITopBar;
    int pointValue = 0;

    void Start()
    {
        RefreshPointText();
    }

    void Update()
    {
        
    }
    public bool ConsumePoint(int value)
    {
        if(pointValue-value >= 0)
        {
            pointValue -= value;
            RefreshPointText();
            return true;
        }
        else
        {
            RefreshPointText();
            return false;
        }
    }
    public void AddPoint(int value)
    {
        pointValue += value;
        RefreshPointText();
    }
    public void ResetPoint()
    {
        pointValue = 0;
        RefreshPointText();
    }
    public int GetPoint()
    {
        return pointValue;
    }
    public void RefreshPointText()
    {
        uITopBar.SetEnergy(pointValue,50);
    }
}
