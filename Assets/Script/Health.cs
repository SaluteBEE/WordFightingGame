using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 100;
    [SerializeField] int MaxPlayerHealth = 100;
    [SerializeField] int EnemyHealth = 100;
    [SerializeField] int MaxEnemyHealth = 100;
    [SerializeField] UITopBar uITopBar;
    Collider2D boxCollider;

    [SerializeField] int currentRow = 2;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        uITopBar.SetHealth(PlayerHealth,MaxPlayerHealth);
        uITopBar.SetEnemyHealth(EnemyHealth,MaxEnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void losePlayerHealth(int amount)
    {
        PlayerHealth -= amount;
        // PlayerHealthText.text = PlayerHealth.ToString();
        uITopBar.SetHealth(PlayerHealth,MaxPlayerHealth);
    }
    public void loseEnemyHealth(int amount)
    {
        EnemyHealth -= amount;
        //EnemyHealthText.text = EnemyHealth.ToString();
        uITopBar.SetEnemyHealth(EnemyHealth,MaxEnemyHealth);
    }
    
     
}
