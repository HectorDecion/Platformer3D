using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Animations;

public class Animation : MonoBehaviour
{
    public Transform NPC;
    public bool isHuman;
    public Animator animator;


    private void Start()
    {
        transform.SetParent(animator.transform);
       animator = GetComponent<Animator>();

    }
    private void Update()
    {
        AnimationPlayableOutput output = GetComponent<AnimationPlayableOutput>();
        animationsNPCs();
        if (!animator.isInitialized)
            animator.Rebind();
    }


    void animationsNPCs()
    {
       
        animator.enabled = true;
        animator.SetBool("isDancing", true);
        NPC.gameObject.SetActive(true);

        if(isHuman)
        {
            animator.enabled = true;
            animator.SetBool("isDancing", true);
            NPC.gameObject.SetActive(true);
        }
        else
        {
            animator.enabled = true;
            animator.SetBool("isDancing", true);
            NPC.gameObject.SetActive(true);
        }
    }
}
