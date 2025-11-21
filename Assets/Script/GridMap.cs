using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class wordWave
{
    public string word;
    public float moveInterval;
    public float damage;
    public bool isEnemy;
}

public class GridMap : MonoBehaviour
{
    [Header("Serialized Rows")]
    [SerializeField] List<GridInfo> row0;
    [SerializeField] List<GridInfo> row1;
    [SerializeField] List<GridInfo> row2;
    [SerializeField] List<GridInfo> row3;
    [SerializeField] List<GridInfo> row4;

    [SerializeField] Sprite emptySprite;
    [SerializeField] Sprite waveSprite;

    private List<List<GridInfo>> gridInfos;
    [SerializeField] Health health;
    List<wordWave> wordWaves;

    [SerializeField] float fixedTime = 0.5f;

    void Awake()
    {
        gridInfos = new List<List<GridInfo>>()
        {
            row0, row1, row2, row3, row4
        };
        wordWaves = new List<wordWave>();
        StartCoroutine(FixedLoop());    
    }
    void Start()
    {
        
    }

    void Update()
    {
        int rows = gridInfos.Count;
        int cols = gridInfos[0].Count;

        for (int i = rows-1; i >= 0; i--)
        {
            for (int j = cols-1; j >= 0; j--)
            {
                if(gridInfos[i][j].wordWave == null)
                {
                    gridInfos[i][j].TileSprite.sprite = emptySprite;
                }
                else
                {
                    gridInfos[i][j].TileSprite.sprite = waveSprite;
                }
            }
        }
    }

    public void LaunchWordWave(string word, float moveInterval, float damage, int currentRow)
    {
        wordWave wordWave = new wordWave();
        wordWave.word = word;
        wordWave.moveInterval = moveInterval;
        wordWave.damage = damage;
        wordWave.isEnemy = false;
        int column = 0;
        foreach (char character in wordWave.word)
        {
            gridInfos[currentRow][column].wordWave = wordWave;
            gridInfos[currentRow][column].character = character;
            gridInfos[currentRow][column].Cha.text = character.ToString();
            column++;
        }
        wordWaves.Add(wordWave);
    }
    public void LaunchEnemyWave(string word, float moveInterval, float damage, int currentRow)
    {
        wordWave wordWave = new wordWave();
        wordWave.word = word;
        wordWave.moveInterval = moveInterval;
        wordWave.damage = damage;
        wordWave.isEnemy = true;
        int column = gridInfos[0].Count -1;
        foreach (char character in wordWave.word)
        {
            gridInfos[currentRow][column].wordWave = wordWave;
            gridInfos[currentRow][column].character = character;
            gridInfos[currentRow][column].Cha.text = character.ToString();
            column--;
        }
        wordWaves.Add(wordWave);
    }
    IEnumerator FixedLoop()
    {
        while (true)
        {
            int rows = gridInfos.Count;
            int cols = gridInfos[0].Count;

            for (int i = rows-1; i >= 0; i--)
            {
                for (int j = cols-1; j >= 0; j--)
                {
                    if(gridInfos[i][j].wordWave == null)
                    {
                        continue;
                    }
                    gridInfos[i][j].waitTime -= fixedTime;
                    if(gridInfos[i][j].waitTime <= 0 && gridInfos[i][j].wordWave.isEnemy == false)
                    {
                        if(j<cols-1)
                        {
                            if(gridInfos[i][j+1].wordWave == null || gridInfos[i][j+1].wordWave.isEnemy == false)
                            {
                                //文字向前移动
                                gridInfos[i][j+1].wordWave = gridInfos[i][j].wordWave;
                                gridInfos[i][j+1].character = gridInfos[i][j].character;
                                gridInfos[i][j+1].Cha.text = gridInfos[i][j].character.ToString();
                                gridInfos[i][j+1].waitTime = gridInfos[i][j].wordWave.moveInterval;
                            }
                            else
                            {
                                gridInfos[i][j+1].wordWave = null;
                                gridInfos[i][j+1].character = '\0';
                                gridInfos[i][j+1].Cha.text = "";
                                gridInfos[i][j+1].waitTime = 0;
                            }
                        }
                        else
                        {          
                            //触发伤害            
                            health.loseEnemyHealth(1);
                        }
                        gridInfos[i][j].wordWave = null;
                        gridInfos[i][j].character = '\0';
                        gridInfos[i][j].Cha.text = "";
                        gridInfos[i][j].waitTime = 0;
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(gridInfos[i][j].wordWave == null)
                    {
                        continue;
                    }
                    gridInfos[i][j].waitTime -= fixedTime;
                    if(gridInfos[i][j].waitTime <= 0 && gridInfos[i][j].wordWave.isEnemy == true)
                    {                                                                                                                     
                        if(j>0)
                        {
                            // if(gridInfos[i][j-1].wordWave == null || gridInfos[i][j-1].wordWave.isEnemy == false)
                            // {
                                gridInfos[i][j-1].wordWave = gridInfos[i][j].wordWave;
                                gridInfos[i][j-1].character = gridInfos[i][j].character;
                                gridInfos[i][j-1].Cha.text = gridInfos[i][j].character.ToString();
                                gridInfos[i][j-1].waitTime = gridInfos[i][j].wordWave.moveInterval;
                            //}
                        }
                        else
                        {
                            health.losePlayerHealth(1);
                        }
                        gridInfos[i][j].wordWave = null;
                        gridInfos[i][j].character = '\0';
                        gridInfos[i][j].Cha.text = "";
                        gridInfos[i][j].waitTime = 0;
                    }
                }
            }
        yield return new WaitForSeconds(fixedTime);
    }
    }
}
// 以后注意内存清理
