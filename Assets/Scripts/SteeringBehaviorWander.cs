using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SteeringBehaviorWander : MonoBehaviour
{
    public float speed = 5f;
    [Range(0f, 15f)]
    public float wanderDistance = 10f;

    public float wanderRadius = 2f;

    public float maxTimeToReachTarget = 5f;
    private float timer;

    public GameObject targetPositionPoint;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = GetRandomPointInSphere() + transform.position;
        timer = 0f;
    }
    private void Update()
    {
        // Verificar que se llego a la posicion destino.
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            // Si se llego, obtener una nueva posicion de destino aleatoria.
            targetPosition = GetRandomPointInSphere() + transform.position;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= Time.deltaTime)
            {
                targetPosition = GetRandomPointInSphere() + transform.position;
                timer = 0f;
            }
        }
        Vector3 direction = (targetPosition = transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
        
        targetPositionPoint.transform.position = targetPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, wanderDistance);
    }
    private Vector3 GetRandomPointInSphere()
    {
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint.y = 0f;

        return randomPoint;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            targetPosition = GetRandomPointInSphere() + transform.position;
        }
    }
}
