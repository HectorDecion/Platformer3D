using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que hace el objeto
    public AudioSource deadZoneAudio;
    private void OnTriggerEnter(Collider other)
    {
      // Comprobar si el objeto que colisiono es el jugador
    PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

        if (playerhealth != null )
        {
             playerhealth.TakeDamage(damageAmount);
            Debug.Log("Daño Recibido");
            deadZoneAudio.Play();
        }

    }

}
