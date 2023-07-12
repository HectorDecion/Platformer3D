using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    // Salud Maxima del jugador
    public int maxHealth = 100;
    //Salud actual del jugador
    public int currentHealth;
    public int cantidadDeVidas;

    //Punto de Respawn
    public GameObject respawnPoint;

    //Texto de la UI
    public TMP_Text starText; // The TextMeshPro object to display

    //Instancia vidas extra
    public GameObject extraLife;
    public Transform posicionExtraLife;
    public Transform posicionExtraLife2;
    public Transform posicionExtraLife3;
    public Transform posicionExtraLife4;

    //Sonidos

    public AudioSource restartaudio;
    public AudioSource itemaudio;
    public AudioSource itemNullAudio;
    private void Start()
    {
        currentHealth = maxHealth;

    }
    private void Update()
    {
        starText.SetText("Vidas: " + currentHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        // Restar una cantidad x daño al jugador
        currentHealth -= damageAmount;

        // Revisamos si el jugador sigue vivo
        if(currentHealth <= 0 ) 
        {
            Die();
        }
    }
    public void RecoverHealth(int recoverAmount)
    {
        if (currentHealth < 100)
        { 
        currentHealth += recoverAmount;
            itemaudio.Play();
        }
        else
        {
            itemNullAudio.Play();  
}
    }
    private void Die()
    { 
        this.transform.position = respawnPoint.transform.position;
        // Respawn a ultimo check point.
        currentHealth += 100;
        Instantiate(extraLife, posicionExtraLife);
        Instantiate(extraLife, posicionExtraLife2);
        Instantiate(extraLife, posicionExtraLife3);
        Instantiate(extraLife, posicionExtraLife4);
        restartaudio.Play();
    }
}
