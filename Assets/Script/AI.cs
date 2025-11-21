using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] WaveGernerator waveGenerator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWaveLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemyWaveLoop()
    {
        while (true)
        {
            int randomRow = Random.Range(1, 5);
            waveGenerator.GenerateEnemyWave("DAMN", 0.5f, 10, randomRow);
            yield return new WaitForSeconds(5f);
        }
    }
}
