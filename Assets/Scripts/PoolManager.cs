using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject objPrefab;

    public int poolSize;

    private Queue<GameObject> objPool;

    public GameObject sinMunicion;
    public AudioSource recargabalasaudio;
    public AudioSource shootaudio;

    //Singleton

    public static PoolManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;

        else
            Destroy(gameObject);
    }
    void Start()
    {
        objPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab);
            objPool.Enqueue(newObj);
            newObj.SetActive(false);
        }

    }
    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotacion)
    {
        while (objPool.Count > 0)
        {
            GameObject newObj = objPool.Dequeue();

            newObj.SetActive(true);

            newObj.transform.SetPositionAndRotation(newPosition, newRotacion);

            shootaudio.Play();

            return newObj;
        }
        
        Debug.Log("Sin Municion");
        return sinMunicion;

    }


    public void ReturnObjToPool(GameObject go)
    {
        recargabalasaudio.Play();
        go.SetActive(false);
        objPool.Enqueue(go);
    }
}
