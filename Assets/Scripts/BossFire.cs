using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossFire: MonoBehaviour
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

    //animaciones
    private Animator animatorplayer;
    void Update()
    {

        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            // transform.LookAt(jugador);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            animatorplayer.SetBool("isWalking", true);
        }
        else
        {
            animatorplayer.SetBool("isWalking", false);
            animatorplayer.SetBool("isAttacking", false);
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
        Gizmos.color = Color.red;
     //   Gizmos.DrawIcon(transform.position, "rangoDeAlerta");
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
            animatorplayer.SetBool("isAttacking", true);
            this.transform.position = transportar.transform.position;
            Debug.Log("IntentoDeTP");
        }
        
        //     if (gameObject.CompareTag("Player"))
        //if (other.gameObject.tag == "Player")
    }
    private void Start()
    {
        animatorplayer = GetComponent<Animator>();
    }
}

