using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
[Serializable]
public class WaveData
{
    public string id;
    // public string text;
    public int cost;
    // public float speed;
}
[Serializable]
public class WaveDataList
{
    public List<WaveData> waves;
}
public class WaveDatabase : MonoBehaviour
{
    public static WaveDatabase Instance;
    public WaveDataList dataList;
    [SerializeField] Text text;

    void Awake()
    {
        Instance = this;
        TextAsset json = Resources.Load<TextAsset>("Json/waves");
        dataList = JsonUtility.FromJson<WaveDataList>(json.text);

        foreach (WaveData wave in dataList.waves)
        {
            text.text += wave.id + " " + wave.cost + "\n";
        }
    }

    public WaveData GetWave(string id)
    {
        for (int i = 0; i < dataList.waves.Count; i++)
            if (dataList.waves[i].id == id)
                return dataList.waves[i];
        return null;
    }
}


