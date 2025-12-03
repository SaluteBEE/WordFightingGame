using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGernerator : MonoBehaviour
{
    [SerializeField] Transform Character;
    [SerializeField] GridMap gridMap;
    [SerializeField] Point point;

    public static WaveGernerator Instance { get; private set; }
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
    public void GenerateWave(string waveID, int id)
    {
        
        WaveData data = WaveDatabase.Instance.GetWave(waveID);
        if(data == null)
        {
            gridMap.LaunchWordWave("***",id);
            return;
        }
        if(!point.ConsumePoint(data.cost))
        {
            Debug.Log("Not enough points");
            return;
        }
        gridMap.LaunchWordWave(data.id,id);

        // if(isEnemy == false)
        // {
        //     if(data == null)
        //     {
        //         gridMap.LaunchWordWave("***", 1, 1);
        //         return;
        //     }
        //     if(!point.ConsumePoint(data.cost))
        //     {
        //         Debug.Log("Not enough points");
        //         return;
        //     }
        //     gridMap.LaunchWordWave(data.id, 1, 1);
        // }
        // else
        // {
        //     if(row == -1)
        //     {
        //         int randomRow = Random.Range(0, 5);
        //     }
        //     else
        //     {
        //         int randomRow = row;
        //     }
        //     gridMap.LaunchEnemyWave(data.id, 1, 1,row);
        // }
        
    }
}
