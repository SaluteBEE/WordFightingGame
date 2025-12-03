using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

[System.Serializable]
public class wordWave
{
    public string word;
    public float damage;
    public bool isReverse;
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
    [SerializeField] Sprite burnSprite;
    [SerializeField] Sprite freezeSprite;
    [SerializeField] Sprite blockSprite;

    private List<List<GridInfo>> gridInfos;

    [SerializeField] Health health;
    List<wordWave> wordWaves;

    [SerializeField] float fixedTime = 0.5f;
    [SerializeField] MovementManager movement;
    [SerializeField] Point point;

    void Awake()
    {
        gridInfos = new List<List<GridInfo>>()
        {
            row0, row1, row2, row3, row4
        };

        wordWaves = new List<wordWave>();
        
        int rows = gridInfos.Count;
        int cols = gridInfos[0].Count;
        for (int i = rows-1; i >= 0; i--)
        {
            for (int j = cols-1; j >= 0; j--)
            {
                gridInfos[i][j].wordWave = null;
                gridInfos[i][j].character = '\0';
                gridInfos[i][j].Cha.text = "";
                gridInfos[i][j].waitTime = 0;
                gridInfos[i][j].TileSprite.sprite = emptySprite;
            }
        }
        StartCoroutine(FixedLoop());    
    }

    public void LaunchWordWave(string word,int id)
    {
        word = word.ToUpper();
        int currentRow;
        wordWave wordWave = new wordWave();

        if(id == 0)
        {
            currentRow = MovementManager.Instance.Player0CurrentRow;
            wordWave.isReverse = false;
        }
        else
        {
            currentRow = MovementManager.Instance.Player1CurrentRow;
            wordWave.isReverse = true;
        }

        wordWave.word = word;
        wordWave.damage = 1;

        int column;
        string printedWord;

        if(id == 0)
        {
            column = 0;
            printedWord = wordWave.word;
        }
        else
        {
            column = gridInfos[0].Count -1;
            printedWord = new string(wordWave.word.Reverse().ToArray());
        }

        Sprite useSprite = waveSprite;
        if(word == "BURN") useSprite = burnSprite;
        if(word == "FREEZE") useSprite = freezeSprite;

        foreach (char character in printedWord)
        {
            gridInfos[currentRow][column].wordWave = wordWave;
            gridInfos[currentRow][column].character = character;
            gridInfos[currentRow][column].Cha.text = character.ToString();
            gridInfos[currentRow][column].TileSprite.sprite = useSprite;

            if(id == 0) column++;
            else column--;
        }

        wordWaves.Add(wordWave);
    }


    IEnumerator FixedLoop()
    {
        while (true)
        {
            int rows = gridInfos.Count;
            int cols = gridInfos[0].Count;

            //-----------------------------------
            // 正向波（玩家 → 敌人方向）
            //-----------------------------------
            for (int i = rows-1; i >= 0; i--)
            {
                for (int j = cols-1; j >= 0; j--)
                {
                    if(gridInfos[i][j].isBlockTile)
                        gridInfos[i][j].BlockSprite.SetActive(true);
                    else
                        gridInfos[i][j].BlockSprite.SetActive(false);

                    if(gridInfos[i][j].wordWave == null)
                        continue;

                    gridInfos[i][j].waitTime -= fixedTime;

                    if(gridInfos[i][j].waitTime <= 0 && gridInfos[i][j].wordWave.isReverse == false)
                    {
                        // 非边缘
                        if(j < cols-1)
                        {
                            // 遇到敌人
                            if(gridInfos[i][j+1].wordWave != null && gridInfos[i][j+1].wordWave.isReverse == true)
                            {
                                //==================================================
                                // ===== BURN 正向清行（玩家烧敌人整行） =====
                                //==================================================
                                if(gridInfos[i][j].wordWave.word == "BURN")
                                {
                                    var burnWave = gridInfos[i][j].wordWave;

                                    // 清除整行敌人
                                    for(int c = 0; c < cols; c++)
                                    {
                                        if(gridInfos[i][c].wordWave != null && gridInfos[i][c].wordWave.isReverse == true)
                                        {
                                            gridInfos[i][c].wordWave = null;
                                            gridInfos[i][c].character = '\0';
                                            gridInfos[i][c].Cha.text = "";
                                            gridInfos[i][c].waitTime = 0;
                                            gridInfos[i][c].TileSprite.sprite = emptySprite;
                                        }
                                    }

                                    // 清除整条 burn（自身）
                                    for(int c = 0; c < cols; c++)
                                    {
                                        if(gridInfos[i][c].wordWave == burnWave)
                                        {
                                            gridInfos[i][c].wordWave = null;
                                            gridInfos[i][c].character = '\0';
                                            gridInfos[i][c].Cha.text = "";
                                            gridInfos[i][c].waitTime = 0;
                                            gridInfos[i][c].TileSprite.sprite = emptySprite;
                                        }
                                    }

                                    continue; //burn 已触发
                                }

                                // 普通波：只消前方敌人格子
                                gridInfos[i][j+1].wordWave = null;
                                gridInfos[i][j+1].character = '\0';
                                gridInfos[i][j+1].Cha.text = "";
                                gridInfos[i][j+1].waitTime = 0;
                                gridInfos[i][j+1].TileSprite.sprite = emptySprite;
                            }
                            else
                            {
                                // 正常推进
                                gridInfos[i][j+1].wordWave = gridInfos[i][j].wordWave;
                                gridInfos[i][j+1].character = gridInfos[i][j].character;
                                gridInfos[i][j+1].Cha.text = gridInfos[i][j].character.ToString();
                                gridInfos[i][j+1].TileSprite.sprite = gridInfos[i][j].TileSprite.sprite;
                            }
                        }
                        else // 边缘扣血
                        {        
                            health.loseEnemyHealth(1);
                            point.AddPoint(1);
                        }

                        // 销毁自身
                        gridInfos[i][j].wordWave = null;
                        gridInfos[i][j].character = '\0';
                        gridInfos[i][j].Cha.text = "";
                        gridInfos[i][j].waitTime = 0;
                        gridInfos[i][j].TileSprite.sprite = emptySprite;
                    }
                }
            }


            //-----------------------------------
            // 反向波（敌人 → 玩家方向）
            //-----------------------------------
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(gridInfos[i][j].wordWave == null)
                        continue;

                    gridInfos[i][j].waitTime -= fixedTime;

                    if(gridInfos[i][j].waitTime <= 0 && gridInfos[i][j].wordWave.isReverse == true)
                    {
                        //===================================
                        // ===== BURN 反向清行（敌人烧玩家整行）=====
                        //===================================
                        if(gridInfos[i][j].wordWave.word == "BURN")
                        {
                            var burnWave = gridInfos[i][j].wordWave;

                            // 清除整行玩家正向波
                            for(int c = 0; c < cols; c++)
                            {
                                if(gridInfos[i][c].wordWave != null && gridInfos[i][c].wordWave.isReverse == false)
                                {
                                    gridInfos[i][c].wordWave = null;
                                    gridInfos[i][c].character = '\0';
                                    gridInfos[i][c].Cha.text = "";
                                    gridInfos[i][c].waitTime = 0;
                                    gridInfos[i][c].TileSprite.sprite = emptySprite;
                                }
                            }

                            // 清除整条 burn（自身）
                            for(int c = 0; c < cols; c++)
                            {
                                if(gridInfos[i][c].wordWave == burnWave)
                                {
                                    gridInfos[i][c].wordWave = null;
                                    gridInfos[i][c].character = '\0';
                                    gridInfos[i][c].Cha.text = "";
                                    gridInfos[i][c].waitTime = 0;
                                    gridInfos[i][c].TileSprite.sprite = emptySprite;
                                }
                            }

                            continue; 
                        }

                        // 正常反向推进
                        if(j > 0)
                        {
                            if(gridInfos[i][j-1].isBlockTile)
                            {
                                if(gridInfos[i][j-1].BlockLeftHealth > 1)
                                    gridInfos[i][j-1].BlockLeftHealth--;
                                else
                                {
                                    gridInfos[i][j-1].isBlockTile = false;
                                    gridInfos[i][j-1].BlockLeftHealth = 0;
                                }
                            }
                            else
                            {
                                gridInfos[i][j-1].wordWave = gridInfos[i][j].wordWave;
                                gridInfos[i][j-1].character = gridInfos[i][j].character;
                                gridInfos[i][j-1].Cha.text = gridInfos[i][j].character.ToString();
                                gridInfos[i][j-1].TileSprite.sprite = gridInfos[i][j].TileSprite.sprite;
                            }
                        }
                        else
                        {
                            health.losePlayerHealth(1);
                        }

                        // 销毁自身
                        gridInfos[i][j].wordWave = null;
                        gridInfos[i][j].character = '\0';
                        gridInfos[i][j].Cha.text = "";
                        gridInfos[i][j].waitTime = 0;
                        gridInfos[i][j].TileSprite.sprite = emptySprite;
                    }
                }
            }

            yield return new WaitForSeconds(fixedTime);
        }
    }
}
