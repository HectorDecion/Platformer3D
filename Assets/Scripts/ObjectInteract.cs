using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public Inventario inventario;
    public TMP_Text starText; // The TextMeshPro object to display
    public int var = 0;
    public AudioSource llavesaudio;

    public int scoreAmount;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        starText.SetText("Llaves: " + var);
    }
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager1 scoreincrement = other.GetComponent<ScoreManager1>();
        if (other.tag == "Player")
        {
            inventario.Cantidad = inventario.Cantidad + 1;
            var = inventario.Cantidad;
            starText.SetText("Llaves: " + var);
            llavesaudio.Play();
            scoreincrement.sumaScore(scoreAmount);
            Destroy(gameObject,1f);
           
        }
    }

}
