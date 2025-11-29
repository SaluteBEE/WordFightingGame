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
    [SerializeField] public int currentRow = 2;
    [SerializeField] public GridMap gridMap;

    private Tween moveTween; 

    void Start()
    {
        gridMap.HighLightCurrentLine();
    }

    private void FinishCurrentTween()
    {
        if (moveTween != null && moveTween.IsActive())
        {
            moveTween.Complete();   
            moveTween = null;
        }
    }

    // public void MoveLeft()
    // {
    //     FinishCurrentTween();
    //     moveTween = transform.DOMoveX(
    //         transform.position.x - leftRightDistance,
    //         0.3f
    //     );
    // }

    // public void MoveRight()
    // {
    //     FinishCurrentTween();

    //     moveTween = transform.DOMoveX(
    //         transform.position.x + leftRightDistance,
    //         0.3f
    //     );
    // }

    public void MoveUp()
    {
        if (currentRow > minRow)
        {
            currentRow--;

            FinishCurrentTween();

            moveTween = transform.DOMoveZ(
                transform.position.z + upDownDistance,
                0.2f
            );

            gridMap.HighLightCurrentLine();
        }
    }

    public void MoveDown()
    {
        if (currentRow < maxRow)
        {
            currentRow++;

            FinishCurrentTween();

            moveTween = transform.DOMoveZ(
                transform.position.z - upDownDistance,
                0.2f
            );
            gridMap.HighLightCurrentLine();
        }
    }
}
