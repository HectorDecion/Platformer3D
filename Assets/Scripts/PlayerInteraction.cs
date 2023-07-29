using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 5f;
    public TextMeshProUGUI interactionText;

    private bool isInteracting;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }
    private void Update()
    {
        Vector3 rayOrigin = this.transform.position; //transform.position
        Vector3 rayDirection = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, interactionRange))
        {
            // Verificar si el raycast impacto con un objecto interactuable          
              
              Interactable interactable = hit.collider.GetComponent<Interactable>();

                if(interactable != null) 
                {
                interactionText.gameObject.SetActive(true);
                isInteracting = true;

                if (Input.GetKeyDown(KeyCode.E))
                    {
                    interactable.Interact();
                        Debug.Log("Intento de levantar un Item");
                    }
            }
            else
                {
                    interactionText.gameObject.SetActive(false);
                    isInteracting = false;
                }
                // Actualizar el Texto de Interaccion
                if (isInteracting)
                {
                    interactionText.text = "Presiona E para Interactuar";
                }
                else
                {
                    
                    interactionText.text = "";
                    
                }
        
            Debug.DrawRay(rayOrigin, rayDirection * interactionRange, Color.red);
        }
}
}




