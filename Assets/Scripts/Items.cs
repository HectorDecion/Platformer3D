using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int IncrementHealth = 10; // Cantidad de incremento
    public GameObject HealthItem;
    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que colisiono es el jugador
        PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

        if (playerhealth != null)
        {
            playerhealth.RecoverHealth(IncrementHealth);
            Destroy(HealthItem, 2f);
        }

    }
}
