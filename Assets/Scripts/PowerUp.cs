using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp sharedInstance;

    public bool powerUpActive;

    public AudioSource powerUpAudio;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;

        else
            Destroy(gameObject);

    }



    public void Start()
    {
        powerUpActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUpEffect(other.gameObject);
            powerUpAudio.Play();
            Destroy(gameObject,1f);
        }
    }

    private void ApplyPowerUpEffect(GameObject player)
    {
        powerUpActive = true;
    }

}


