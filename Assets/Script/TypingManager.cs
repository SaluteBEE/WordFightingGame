using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager: MonoBehaviour
{
    [SerializeField] string word;
    [SerializeField] TextMeshPro Inputtext;
    [SerializeField] Health health;

    
    int wordLength;
    int CurrentWordLength = 0;
    [SerializeField] WaveGernerator waveGenerator;
    [SerializeField] MovementManager movement;
    private PlayerInput localPlayer;
    public static TypingManager Instance { get; private set; }
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
    public void RegisterPlayer(PlayerInput player)
    {
        localPlayer = player;
    }
    void Start()
    {
        Inputtext.text = "";
        wordLength = word.Length;
    }
    void Update()
    {
        string input = Input.inputString;
        if(input != " ")
        {
            Inputtext.text = Inputtext.text += input;
        }
        else 
        {
            localPlayer.CmdReportWordWave(Inputtext.text);
            CurrentWordLength = 0;
            Inputtext.text = "";
        }
    }
}

