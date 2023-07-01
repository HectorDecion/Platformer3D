using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Referencia a la pos del jugador
    public Vector3 offSet = new Vector3(0f, 2f, -5f); // OffSet de la posicion de la camara con respecto al jugador
    public float smoothSpeed = 0.05f; // Velocidad de suavizado del movimiento de la camara
    public float rotationSpeed = 2f;
  //  public float rotationX = 0f;
    //  public float rotationY = 0f;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        offSet = transform.position - player.position;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = this.player.position + offSet; // Calcula la pos deseada de la camara sumando el offset deseado.

        //Actualiza la pos del jugador.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Camara simpre voltea al jugador.
        transform.LookAt(this.player);

        //Rotacion de Camara
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        //Limitamos la rotacion vertical de la camara
        mouseY = Mathf.Clamp(mouseY, -45f, 45f);

        // Calcular la rotacion del jugador y de la camara
        Quaternion playerRotation = Quaternion.Euler(0f, mouseX, 0f);
        Quaternion cameraRotation = Quaternion.Euler(mouseY, mouseX, 0f);
        //Aplica rotacion al jugador
        player.rotation = playerRotation;
        //aplicar la rotacion de la camara alreadedor del jugador
        transform.position = player.position + playerRotation * offSet;
        transform.rotation = cameraRotation;

      //  Quaternion rotation = Quaternion.Euler(mouseX, mouseY, 0f);
      //  transform.rotation = rotation;

      //    this.player.rotation = Quaternion.Euler(0f, mouseX, 0f);
       
    }

}
