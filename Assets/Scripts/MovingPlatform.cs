using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    private Transform targetPointPartner;

    // Seek Vars
    public Transform target;
    public float speed = .5f;

    private void Start()
    {
        targetPointPartner = PointA;
    }

    public void Update()
    {

        MoveToPointsPartner();

    }

    void MoveToPointsPartner()
    {
        if (transform.position == targetPointPartner.position)
        {
            // Si el enemigo llega al punto A cambia al B y viceversa
            targetPointPartner = (targetPointPartner == PointA) ? PointB : PointA;
        }
        // Mover al enemigo hacia el punto actual
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPointPartner.position, step);
    }


}
