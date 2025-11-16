using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGernerator : MonoBehaviour
{
    [SerializeField] GameObject WavePrefab;
    [SerializeField] Transform WaveParent;
    [SerializeField] Transform Character;

    public void GenerateWave(string WaveText,float damage,int currentRow)
    {
        GameObject wave = Instantiate(WavePrefab, transform.position, Quaternion.identity);
        wave.transform.parent = WaveParent;
        wave.transform.position = Character.position;
        wave.GetComponent<Wave>().WaveText = WaveText;
        wave.GetComponent<Wave>().damage = damage;
        wave.GetComponent<Wave>().currentRow = currentRow;
    }
}
