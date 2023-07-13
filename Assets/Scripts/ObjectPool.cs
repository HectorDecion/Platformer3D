using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool // : MonoBehaviour Este script no depende de Unity
{
    //Objeto
    private GameObject prefab;
    private List<GameObject> pool;

    public ObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
        this.pool = new List<GameObject>();
    }

    public GameObject Get()
    {
        //Busca un objecto inactivo en el pool
        GameObject obj = pool.Find(o => !o.activeSelf);

        // Si el objecto es null o no existe, se crea un nuevo objeto y se agrega al pool actual.
        if (obj == null)
        {
            obj = CreateNewObject();
            pool.Add(obj);
        }

        return obj;

    }
    //Metodo que crea un nuevo objeto y lo instancia de forma inactiva.
    private GameObject CreateNewObject()
    {
        GameObject newObj = Object.Instantiate(prefab);
        newObj.SetActive(false);
        return newObj;
    }
}
