using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 4f;


    public Transform groundCheck;
    public Transform centroDelPlayer;
    private Rigidbody rb;
    public LayerMask groundLayer;
    private Animator animatorplayer;
    private float horizontalInput;
    private float verticalInput;

    public bool grounded; //Solo para ver si esta activa o no


    public AudioSource danceaudio;
    public AudioSource walkingaudio;
    public AudioSource jumpaudio;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animatorplayer = GetComponent<Animator>();
        //    offSet = transform.position - this.transform.position;
    }

    private void Update()
    {
        playerControl();
        IsTouchingGround();
        salto();
        Debug.DrawRay(centroDelPlayer.transform.position, -Vector3.up * 2f, UnityEngine.Color.red);

    }

    private void FixedUpdate()
    {
        
    }

    void playerControl()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Calcular direccion de movimiento
        // moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        //  rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y, 0f);

        transform.Translate(horizontalInput * 4f * Time.deltaTime, 0, verticalInput * 4f * Time.deltaTime);

       if (horizontalInput != 0f || verticalInput != 0f)
       {
            
            animatorplayer.SetBool("isRunning", true);
            
        }
       else
       {
            animatorplayer.SetBool("isRunning", false);
          
     }
            //Aplicar Movimiento en la direccion calculada
            //   rb.velocity = moveDirection * moveSpeed;

            //   float dancing = Input.GetAxis("F");
            if (Input.GetKeyDown(KeyCode.F))
            {
            danceaudio.Play();
            animatorplayer.SetBool("isDancing", true);
            animatorplayer.SetBool("isIdle", false);
        }
         else
        {
            animatorplayer.SetBool("isDancing", false);
            animatorplayer.SetBool("isIdle", true);
        }
    }
    bool IsTouchingGround()
    {
        //Verificar que el jugador este tocando el piso
        if (Physics.Raycast(centroDelPlayer.transform.position, -Vector3.up, 1.5f, groundLayer))
                {
            grounded = true;
            return true;

        }
        else 
        {
            grounded = false;
            return false;
        }

       

    }
    public void salto()
    {
        
        if (Input.GetButtonDown("Jump") && IsTouchingGround())
        {
            
            jumpaudio.Play();
            animatorplayer.SetBool("isJumping", true);
            rb.velocity += Vector3.up * jumpForce;
        }
        //Si está cayendo
        if (rb.velocity.y < 0) //Si está cayendo
        {
            animatorplayer.SetBool("isJumping", false);
        }
    }
    private void LateUpdate()
    {


    }

}
