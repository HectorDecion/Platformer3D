using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Salud Maxima del jugador
    public int maxHealth = 100;
    //Salud actual del jugador
    public int currentHealth;

     private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Restar una cantidad x da�o al jugador
        currentHealth -= damageAmount;

        // Revisamos si el jugador sigue vivo
        if(currentHealth <= 0 ) 
        {
            Die();
        }
    }
    public void RecoverHealth(int recoverAmount)
    {
        if (currentHealth <= 100)
        { 
        currentHealth += recoverAmount;
        }
    }
    private void Die()
    { 
    // Respawn a ultimo check point.
    }
}
