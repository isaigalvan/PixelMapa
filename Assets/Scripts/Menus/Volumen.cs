using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public AudioSource audioSrc;
    public float musicVolume;
    public Slider barra;

   
    // Use this for initialization
    void Start()
    {
        if ((RestablecerValores.obtenerRespawn()) == false)
        {
            musicVolume = .5f;
            RestablecerValores.volumen = .5f;
        }
        else
        {
            musicVolume = RestablecerValores.volumen;
            barra.value = RestablecerValores.volumen;
        }
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
        RestablecerValores.volumen = vol;
    }
}
