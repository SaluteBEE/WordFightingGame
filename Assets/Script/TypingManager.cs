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

    // 由 PlayerInput 调用，把自己传进来
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

        // if(Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     movement.MoveUp();
        // }
        // else if(Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     movement.MoveDown();
        // }
        // else if(Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     movement.MoveLeft();
        // }
        // else if(Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     movement.MoveRight();
        // }
        string input = Input.inputString;
        if(input != " ")
            {
                Inputtext.text = Inputtext.text += input;
            }
            else 
            {
                // if(Inputtext.text == "UP")
                // {
                //     movement.MoveUp();
                // }
                // else if(Inputtext.text == "DOWN")
                // {
                //     movement.MoveDown();
                // }
                // else if(Inputtext.text == "LEFT")
                // {
                //     movement.MoveLeft();
                // }
                // else if(Inputtext.text == "RIGHT")
                // {
                //     movement.MoveRight();
                // }
                // else 
                // {
                    localPlayer.CmdReportWordWave(Inputtext.text);
                    //waveGenerator.GenerateWave(Inputtext.text,false);
                //}
                CurrentWordLength = 0;
                Inputtext.text = "";
            }
        }
    }

