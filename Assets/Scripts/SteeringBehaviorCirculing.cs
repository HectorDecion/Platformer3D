using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorCirculing : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float maxSeekDistance = 10f;
    public float raycastLegth = 15f;

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
                //Translado el agente hacia el target
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}
