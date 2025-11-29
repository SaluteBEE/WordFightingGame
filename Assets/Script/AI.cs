using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AISkill
{
    public string name;
    public int weight;
    public Action onTrigger;
    public AISkill(string name,int weight,Action onTrigger=null)
    {
        this.name = name;
        this.weight = weight;
        this.onTrigger = onTrigger;
    }
}
public class AI : MonoBehaviour
{
    public string AIName = "AI";
    public int AIHealth = 100;
    public float AIAttackInterval = 5f;
    public List<AISkill> skills;
    public int CurrentRow = 2;
    protected virtual void Start()
    {
        InvokeRepeating("AIBehavior", AIAttackInterval, AIAttackInterval);
    }
    public void AIBehavior()
    {
        int totalWeight = 0;

        foreach (var skill in skills)
            totalWeight += skill.weight; // 累加总权重
        int randomValue = UnityEngine.Random.Range(0, totalWeight);
        int current = 0;

        foreach (var skill in skills)
        {
            current += skill.weight;

            if (randomValue < current)
            {
                skill.onTrigger?.Invoke();
                return;
            }
        }
    }
}
