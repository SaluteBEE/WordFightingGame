using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGernerator : MonoBehaviour
{
    [SerializeField] Transform Character;
    [SerializeField] GridMap gridMap;
    [SerializeField] Point point;

    public void GenerateWave(string waveID, bool isEnemy,int row = -1)
    {
        
        WaveData data = WaveDatabase.Instance.GetWave(waveID);
        if(isEnemy == false)
        {
            if(data == null)
            {
                gridMap.LaunchWordWave("***", 1, 1);
                return;
            }
            if(!point.ConsumePoint(data.cost))
            {
                Debug.Log("Not enough points");
                return;
            }
            gridMap.LaunchWordWave(data.id, 1, 1);
        }
        else
        {
            if(row == -1)
            {
                int randomRow = Random.Range(0, 5);
            }
            else
            {
                int randomRow = row;
            }
            gridMap.LaunchEnemyWave(data.id, 1, 1,row);
        }
        
    }
}
