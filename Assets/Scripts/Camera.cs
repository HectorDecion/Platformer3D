using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float speedH;
    public float speedV;

    float yaw;
    float pitch;

    public Vector3 offSet = new Vector3(0f, 2f, -5f); // OffSet de la posicion de la camara con respecto al jugador
    public float smoothSpeed = 0.05f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offSet; // Calcula la pos deseada de la camara sumando el offset deseado.

        //Actualiza la pos del jugador.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = target.position.normalized;

        // Camara simpre voltea al jugador.
        transform.LookAt(target);
    }
    void Update()
    {
        yaw += speedH + Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
