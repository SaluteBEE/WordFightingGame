using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITopBar : MonoBehaviour
{
    [SerializeField] public Image HealthBar;
    [SerializeField] public TextMeshProUGUI HealthBarText;
    [SerializeField] public Image EnergyBar;
    [SerializeField] public TextMeshProUGUI EnergyBarText;
    [SerializeField] public Image EnemyHealthBar;
    [SerializeField] public TextMeshProUGUI EnemyHealthBarText;
    // [SerializeField] public int MaxHealth;
    // [SerializeField] public int MaxEnergy;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetHealth(int health,int MaxHealth)
    {
        HealthBar.fillAmount = (float)health/(float)MaxHealth;
        HealthBarText.text = health.ToString();
    }
    public void SetEnemyHealth(int health,int MaxHealth)
    {
        Debug.Log(health + "   "+ MaxHealth);
        EnemyHealthBar.fillAmount = (float)health/(float)MaxHealth;
        EnemyHealthBarText.text = health.ToString();
    }
    public void SetEnergy(int energy,int MaxEnergy)
    {
        EnergyBar.fillAmount = (float)energy/(float)MaxEnergy;
        EnergyBarText.text = energy.ToString();
    }
}
