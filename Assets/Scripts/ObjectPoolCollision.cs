using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool1 : MonoBehaviour
{
  //  private ObjectPool objectPool;
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        // Verificando si el objecto collisionado esta en el pool
        if (objectPool.Contains(collidedObject))
        {
            collidedObject.SetActive(false);
        }
    }
}
