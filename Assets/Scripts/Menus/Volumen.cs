using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumen : MonoBehaviour
{
    public AudioSource audioSrc;
    public float musicVolume = 1f;

    // Use this for initialization
    void Start()
    { 
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void ponerVolumen(float vol)
    {
        musicVolume = vol;
    }
}
