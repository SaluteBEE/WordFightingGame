using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 100;
    [SerializeField] int EnemyHealth = 100;
    [SerializeField] Text PlayerHealthText;
    [SerializeField] Text EnemyHealthText;
    Collider2D boxCollider;

    [SerializeField] int currentRow = 2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthText.text = PlayerHealth.ToString();
        EnemyHealthText.text = EnemyHealth.ToString();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void losePlayerHealth(int amount)
    {
        PlayerHealth -= amount;
        PlayerHealthText.text = PlayerHealth.ToString();
    }
    public void loseEnemyHealth(int amount)
    {
        EnemyHealth -= amount;
        EnemyHealthText.text = EnemyHealth.ToString();
    }
    
    
}
