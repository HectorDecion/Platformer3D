using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementLeftRight : MonoBehaviour
{
    public float speed = 2f;
    public float movementRange = 5f;

    private Vector3 initialPosition;
    private float movementDirection = 1f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float movement = speed * Time.deltaTime * movementDirection;

        transform.Translate(Vector3.right * movement);

        if (Mathf.Abs(transform.position.x - initialPosition.x) >= movementRange / 2f)
        {
            movementDirection *= -1f;
        }
    }
}
