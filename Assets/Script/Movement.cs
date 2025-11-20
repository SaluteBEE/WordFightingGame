using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float upDownDistance;
    [SerializeField] float leftRightDistance;
    [SerializeField] int maxRow = 5;
    [SerializeField] int minRow = 1; 
    [SerializeField] public int currentRow = 3;  

    public void MoveLeft()
    {
        transform.DOMoveX(transform.position.x - leftRightDistance, 0.3f);

    }
    public void MoveRight()
    {
        transform.DOMoveX(transform.position.x + leftRightDistance, 0.3f);
    }
    public void MoveUp()
    {
        if(currentRow > minRow)
        {
            currentRow--;
            transform.DOMoveZ(transform.position.z + upDownDistance, 0.3f);
        }
    }
    public void MoveDown()
    {
        if(currentRow < maxRow)
        {
            currentRow++;
            transform.DOMoveZ(transform.position.z - upDownDistance, 0.3f);
        }
    }
}
    

