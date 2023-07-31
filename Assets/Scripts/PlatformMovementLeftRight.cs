using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlatformMovementLeftRight : MonoBehaviour
{
    public float speed = 2f;
    public float movementRange = 5f;

    private Vector3 initialPosition;
    private float movementDirection = 1f;
    public Transform playerPosicion;
    public Transform playerTP;

    private void Start()
    {
        initialPosition = transform.position;
        playerTP = GetComponent<Transform>();
    }

    private void Update()
    {
        float movement = speed * Time.deltaTime * movementDirection;

        transform.Translate(Vector3.right * movement);

        if (Mathf.Abs(transform.position.x - initialPosition.x) >= movementRange / 2f)
        {
            movementDirection *= -1f;
        }
        playerPosicion = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPosicion.transform.position = playerTP.transform.position;

        }
    }
}

