using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Transform jugador;
    public float velocidad;

    bool estarAlerta;

    //Daño a jugador
    public int damageAmount = 10;

    //Tp de enemigo
    public Transform transportar;

    //Sonidos
    public AudioSource golpeaudio;
    void Update()
    {

        estarAlerta =  Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            // transform.LookAt(jugador);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
       //     transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);        
        }
        if (gameObject.CompareTag("Player"))
        //if (other.gameObject.tag == "Player")
        {
            this.transform.position = transportar.transform.position;
            Debug.Log("IntentoDeTP");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    private void OnTriggerEnter(Collider other)
    {

        // Comprobar si el objeto que colisiono es el jugador
        PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

        if (playerhealth != null)
        {
            playerhealth.TakeDamage(damageAmount);
            Debug.Log("Daño Recibido");
            golpeaudio.Play();
            this.transform.position = transportar.transform.position;
            Debug.Log("IntentoDeTP");
        }
   //     if (gameObject.CompareTag("Player"))
        //if (other.gameObject.tag == "Player")
    }
    private void Start()
    {
    }
}
