using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    public AudioSource backgroundAudio;


    private void Start()
    {
        backgroundAudio.Play();
}
}