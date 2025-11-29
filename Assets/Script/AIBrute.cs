using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AIBrute : AI
{
    public WaveGernerator waveGernerator;
    public Animator animator;
    private Tween moveTween;
    [SerializeField] float upDownDistance; 
    int newRow;
    protected override void Start()
    {
        AISkill Rugh = new AISkill("Raaa", 10, RaaaEffect); 
        base.skills.Add(Rugh);
        base.Start();
    }
    void Update()
    {
        
    }

    public void RaaaEffect()
    {
        newRow = UnityEngine.Random.Range(0,5);
        Debug.Log("enemy:"+newRow);
        moveTween = transform.DOMoveZ(
            transform.position.z + (CurrentRow-newRow)*upDownDistance,
            0.3f
        );
        CurrentRow = newRow;
        animator.SetTrigger("attack");
    }
    public void attackAniEvent()
    {       
        waveGernerator.GenerateWave("Raaa",true,newRow);
    }
}
