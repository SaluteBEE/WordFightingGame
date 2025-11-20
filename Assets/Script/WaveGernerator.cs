using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGernerator : MonoBehaviour
{
    [SerializeField] GameObject WavePrefab;
    [SerializeField] Transform WaveParent;
    [SerializeField] Transform Character;
    [SerializeField] GridMap gridMap;

    public void GenerateWave(string WaveText,float moveInterval,float damage,int currentRow)
    {
        gridMap.LaunchWordWave(WaveText, moveInterval, damage, currentRow);
    }
}
