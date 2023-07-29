using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    private bool playerArriba = false;
    void Start()
    {       
    }
    void Update()
    {
            //Verificar que el jugador este tocando el piso
            if (playerArriba == true)
            {
            
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            playerArriba = false;
            HierarchyDropFlags.DropAbove.Equals(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerArriba = true;
            HierarchyDropFlags.DropAbove.Equals(true);
        }
    }
}
