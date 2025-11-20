using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class wordWave
{
    public string word;
    public float moveInterval;
    public float damage;
}

public class GridMap : MonoBehaviour
{
    [Header("Serialized Rows")]
    [SerializeField] List<GridInfo> row0;
    [SerializeField] List<GridInfo> row1;
    [SerializeField] List<GridInfo> row2;
    [SerializeField] List<GridInfo> row3;
    [SerializeField] List<GridInfo> row4;

    private List<List<GridInfo>> gridInfos;

    List<wordWave> wordWaves;

    void Awake()
    {
        gridInfos = new List<List<GridInfo>>()
        {
            row0, row1, row2, row3, row4
        };
        wordWaves = new List<wordWave>();

    }

    void Update()
    {
        int rows = gridInfos.Count;
        int cols = gridInfos[0].Count;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                //gridInfos[i][j].TileSprite.sprite = gridSprites[i][j];
            }
        }
    }

    public void LaunchWordWave(string word, float moveInterval, float damage, int currentRow)
    {
        wordWave wordWave = new wordWave();
        wordWave.word = word;
        wordWave.moveInterval = moveInterval;
        wordWave.damage = damage;
        int column = 0;
        currentRow--;
        foreach (char character in wordWave.word)
        {
            gridInfos[currentRow][column].wordWave = wordWave;
            gridInfos[currentRow][column].character = character;
            gridInfos[currentRow][column].Cha.text = character.ToString();
            column++;
        }
        wordWaves.Add(wordWave);
    }
}
