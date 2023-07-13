using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootingForce = 10f;
    private ObjectPool projectilePool;
    void Start()
    {
        projectilePool = new ObjectPool(projectilePrefab);
          
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Obtiene un proyectil del pool
            GameObject projectile = projectilePool.Get();

            projectile.transform.position = projectileSpawnPoint.position;
            projectile.transform.rotation = projectileSpawnPoint.rotation;

            projectile.SetActive(true);

            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = projectileSpawnPoint.forward * shootingForce;
        }
    }
}
