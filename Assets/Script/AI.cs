using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] WaveGernerator waveGenerator;
    void Start()
    {
        StartCoroutine(EnemyWaveLoop());
    }
    IEnumerator EnemyWaveLoop()
    {
        while (true)
        {
            
            waveGenerator.GenerateWave("BOOM", true);
            yield return new WaitForSeconds(5f);
        }
    }
}
