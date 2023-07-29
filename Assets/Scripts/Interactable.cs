using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("Interactuando con: " + gameObject.name);
    }

    public void PickUp()
    {
        // Animacion
    }
}
