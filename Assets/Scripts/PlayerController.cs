using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;


    public Transform groundCheck;

    private Rigidbody rb;
    public LayerMask groundLayer;

    private bool isGrounded;

    private Vector3 moveDirection;

    private Animator animatordancing;

    //Camera

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animatordancing = GetComponent<Animator>();
    //    offSet = transform.position - this.transform.position;
    }

    private void Update()
    {
        playerControl();
        IsTouchingGround();

    }

    private void FixedUpdate()
    {
        
    }

    void playerControl()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Calcular direccion de movimiento
        moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        //  rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y, 0f);

        //Aplicar Movimiento en la direccion calculada
        rb.velocity = moveDirection * moveSpeed;

        //   float dancing = Input.GetAxis("F");
         if (Input.GetKeyDown(KeyCode.F))
            {
            animatordancing.SetBool("isDancing", true);
            animatordancing.SetBool("isIdle", false);
        }
         else
        {
            animatordancing.SetBool("isDancing", false);
            animatordancing.SetBool("isIdle", true);
        }
    }
    void IsTouchingGround()
    {
        //Verificar que el jugador este tocando el piso

        isGrounded = Physics.Raycast(groundCheck.position, -Vector3.up, 0.1f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(transform.position, -Vector3.up, UnityEngine.Color.red);

    }
    private void cameraOpt()
    {

    }
    private void LateUpdate()
    {


    }
}
