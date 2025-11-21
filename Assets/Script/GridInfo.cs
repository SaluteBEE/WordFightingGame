using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GridInfo:MonoBehaviour
{
    [SerializeField] public TextMeshPro Cha;
    public char character = '\0';
    public SpriteRenderer TileSprite;
    public wordWave wordWave;
    public float waitTime;

    void Start()
    {
        Cha.text = character.ToString();
        wordWave = null;
    }
}
