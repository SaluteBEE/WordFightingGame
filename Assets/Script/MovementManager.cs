using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] float upDownDistance;
    [SerializeField] float leftRightDistance;
    [SerializeField] int maxRow = 5;
    [SerializeField] int minRow = 1;
    [SerializeField] public int Player0CurrentRow = 2;
    [SerializeField] public int Player1CurrentRow = 2;
    [SerializeField] public GridMap gridMap;

    [SerializeField] public GameObject Player0;
    [SerializeField] public GameObject Player1;


    private Tween moveTween; 
    public static MovementManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //gridMap.HighLightCurrentLine();
    }

    private void FinishCurrentTween()
    {
        if (moveTween != null && moveTween.IsActive())
        {
            moveTween.Complete();   
            moveTween = null;
        }
    }

    public void MoveUp(int playerPos)
    {
        FinishCurrentTween();

        if(playerPos == 0)
        {
            if (Player0CurrentRow > minRow)
            {
                Player0CurrentRow--;
                moveTween = Player0.transform.DOMoveZ(
                Player0.transform.position.z + upDownDistance,
                0.2f
                );
            }
        }
        else
        {
            if (Player1CurrentRow > minRow)
            {
                Player1CurrentRow--;
                moveTween = Player1.transform.DOMoveZ(
                Player1.transform.position.z + upDownDistance,
                0.2f
                );
            }
        }

    
        // if (currentRow > minRow)
        // {
        //     currentRow--;

            // FinishCurrentTween();

            // moveTween = transform.DOMoveZ(
            //     transform.position.z + upDownDistance,
            //     0.2f
            // );

        //     gridMap.HighLightCurrentLine();
        // }
    }

    public void MoveDown(int playerPos)
    {
        
        FinishCurrentTween();

        if(playerPos == 0)
        {
            if (Player0CurrentRow < maxRow)
            {
                Player0CurrentRow++;
                moveTween = Player0.transform.DOMoveZ(
                Player0.transform.position.z - upDownDistance,
                0.2f
                );
            }
        }
        else
        {
            if (Player1CurrentRow < maxRow)
            {
                Player1CurrentRow++;
                moveTween = Player1.transform.DOMoveZ(
                Player1.transform.position.z - upDownDistance,
                0.2f
                );
            }
        }
        // if (currentRow < maxRow)
        // {
        //     currentRow++;

        //     FinishCurrentTween();

        //     moveTween = transform.DOMoveZ(
        //         transform.position.z - upDownDistance,
        //         0.2f
        //     );
        //     //gridMap.HighLightCurrentLine();
        // }
    }
}
