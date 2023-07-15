using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public AudioSource deadZoneAudio;
    private void OnTriggerEnter(Collider other)
    {
      // Comprobar si el objeto que colisiono es el jugador
    PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

        if (playerhealth != null )
        {
            if(PowerUp.sharedInstance.powerUpActive)
            {
                playerhealth.TakeDamage(EnemyManager.sharedInstance.damageAmount[0]);
            }
            else
            {

                playerhealth.TakeDamage(EnemyManager.sharedInstance.damageAmount[1]);
            Debug.Log("Daño Recibido");
            deadZoneAudio.Play();
        }
        }

    }

}
