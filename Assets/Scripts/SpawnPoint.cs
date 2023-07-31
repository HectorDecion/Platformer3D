using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cubePrefab;
    public float cubeForce = 20f;
  //  public AudioSource shootaudio;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("espera", 5f);
            GameObject cube = PoolManager.sharedInstance.GetObjectFromPool(spawnPoint.position, spawnPoint.rotation);

            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * cubeForce, ForceMode.Impulse);
        //    shootaudio.Play();
        }
    }
    public void espera()
    {

    }
}
