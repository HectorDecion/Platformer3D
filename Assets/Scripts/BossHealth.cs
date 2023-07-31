using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public AudioSource bossdamage;
    public AudioSource bossdead;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        // Restar una cantidad x daño al jugador
        currentHealth -= damageAmount;

        // Revisamos si el jugador sigue vivo
        if (currentHealth <= 0)
        {
            bossdead.Play();
            Destroy(gameObject,1f);
        }
        else
        {
                bossdamage.Play();
        }
    }
}
