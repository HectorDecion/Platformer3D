using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventario : MonoBehaviour
{

    public int Cantidad = 0;
    public int var2 = 0;
    public Transform BossDoor;


        private void Start()
    {
    }
    private void Update()
    {
        tpToBossDoor();
    }
    void tpToBossDoor()
    {
        if (Cantidad == 10)
        { 
        this.transform.position = BossDoor.transform.position;
        Debug.Log("llaves" + Cantidad);
            Cantidad = 0;
        }
    }
}
