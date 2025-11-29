using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    [SerializeField] string word;
    [SerializeField] TextMeshPro Inputtext;
    [SerializeField] Health health;

    
    int wordLength;
    int CurrentWordLength = 0;
    [SerializeField] WaveGernerator waveGenerator;
    [SerializeField] Movement movement;
    void Start()
    {
        Inputtext.text = "";
        wordLength = word.Length;
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.MoveUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.MoveDown();
        }
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
                    waveGenerator.GenerateWave(Inputtext.text,false);
                //}
                CurrentWordLength = 0;
                Inputtext.text = "";
            }
        }
    }

