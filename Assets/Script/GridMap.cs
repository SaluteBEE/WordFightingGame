using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInfo
{
    public char character;
    public wordWave wordWave;
    public float waitTime;
}
public class wordWave
{
    public string word;
    public float moveInterval;
}
public class GridMap : MonoBehaviour
{
    [SerializeField] GridInfo[,] gridInfos;
    [SerializeField] List<wordWave> wordWaves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LaunchWordWave(wordWave wordWave,int currentRow)
    {
        int column = 0;
        foreach(char character in wordWave.word)
        {
            gridInfos[currentRow,column].wordWave = wordWave;
            gridInfos[currentRow,column].character = character;
            column++;
        }
        

    }
}
