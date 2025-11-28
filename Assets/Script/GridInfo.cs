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

    [Header("阻挡方块特有")]
    [SerializeField] public TextMeshPro BlockCha;
    public char blockCharacter = '\0';
    public GameObject BlockSprite;
    public bool isBlockTile = false;
    public int BlockLeftHealth = 3;

    void Start()
    {
        Cha.text = character.ToString();
        BlockSprite.SetActive(false);
        wordWave = null;
    }
    void Update()
    {
        //Cha.text = character.ToString();
    }
    public void Refresh()
    {
        Cha.text = character.ToString();
        BlockCha.text = blockCharacter.ToString();
    }
}
