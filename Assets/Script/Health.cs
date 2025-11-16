using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Text healthText;
    Collider2D boxCollider;

    [SerializeField] int currentRow = 2;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loseHealth(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wave" && collision.gameObject.GetComponent<Wave>().currentRow == currentRow)
        {
            loseHealth((int)collision.gameObject.GetComponent<Wave>().damage);
            Destroy(collision.gameObject);
        }
    }
    
}
