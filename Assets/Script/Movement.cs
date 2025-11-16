using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector2 upDownVector;
    [SerializeField] float leftRightDistance;
    [SerializeField] int maxRow = 3;
    [SerializeField] int minRow = 1; 
    [SerializeField] public int currentRow = 2;  

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
            transform.DOMoveX(transform.position.x + upDownVector.x, 0.3f);
            transform.DOMoveY(transform.position.y + upDownVector.y, 0.3f);
        }
        
    }
    public void MoveDown()
    {
        if(currentRow < maxRow)
        {
            currentRow++;
            transform.DOMoveX(transform.position.x - upDownVector.x, 0.3f);
            transform.DOMoveY(transform.position.y - upDownVector.y, 0.3f);
        }
    }
    IEnumerator MoveUpDownCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(upDownVector.x, upDownVector.y, 0f);
        Gizmos.DrawLine(start, end);
    }
}
    

