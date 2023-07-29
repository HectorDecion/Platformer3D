using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorSeek : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float maxSeekDistance = 10f;
    public float raycastLegth = 15f;

    public LayerMask obstacleLayer;

    private void Start()
    {
   
    }

    private void Update()
    {
        if(target != null)
        {
            // Calcular la direccion hacia el target
            Vector3 direction = (target.position - transform.position).normalized;
            //Dibujo RayC
            Debug.DrawRay(transform.position, direction * raycastLegth, Color.yellow);

            // Comprobar si el target esta dentro del rango de busqueda
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(distanceToTarget <= maxSeekDistance)
            {
                // Verificar que esta tocando el RayCast
                RaycastHit hit;
                if(Physics.Raycast(transform.position, direction, out hit, raycastLegth, obstacleLayer))
                {
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.green);
                }
                else
                {
                    // Translado el agente hacia el target
                    transform.Translate(direction * speed * Time.deltaTime);
                }
            }
        }
    }
}
