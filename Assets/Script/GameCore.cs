using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    [SerializeField] string word;
    [SerializeField] Text Targettext;
    [SerializeField] Text Inputtext;
    [SerializeField] Health health;
    
    int wordLength;
    int CurrentWordLength = 0;
    [SerializeField] WaveGernerator waveGenerator;
    [SerializeField] Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        Targettext.text = "";
        Inputtext.text = "";
        Targettext.text = word;
        wordLength = word.Length;
    }

    // Update is called once per frame
    void Update()
    {
        string input = Input.inputString;
        if(!string.IsNullOrEmpty(input))
        {
            if(input != " ")
            {
                Inputtext.text = Inputtext.text+=input;
            }
            else 
            {
                if(Inputtext.text == Targettext.text)
                {
                    waveGenerator.GenerateWave(Targettext.text, 10, movement.currentRow);
                }
                else if(Inputtext.text == "UP")
                {
                    movement.MoveUp();
                }
                else if(Inputtext.text == "DOWN")
                {
                    movement.MoveDown();
                }
                else if(Inputtext.text == "LEFT")
                {
                    movement.MoveLeft();
                }
                else if(Inputtext.text == "RIGHT")
                {
                    movement.MoveRight();
                }
                else
                {
                    string wrongWord = "";
                    for(int i = 0; i < Inputtext.text.Length; i++)
                    {
                        wrongWord += "*";
                    }
                    waveGenerator.GenerateWave(wrongWord, 2, movement.currentRow);
                }
                CurrentWordLength = 0;
                Inputtext.text = "";
            }
        }
    }
}
