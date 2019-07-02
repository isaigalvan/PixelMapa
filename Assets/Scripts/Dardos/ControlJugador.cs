using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public int jugador;
    public bool repite, pararTiempo, actTiempo,condi, actTiempo2, movible=true;
    public float tiempoTemp, tiempo1, tiempo2;

    public GameObject imagen;
    public SpriteRenderer imgR;
    public Sprite[] jug;
    // Start is called before the first frame update
    void Start()
    {
        jugador = 1;
        actTiempo2 = true;
        imgR = imagen.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        cambio();
        mostarJugador();
        empiezo();
        if (actTiempo == true) { tiempo1 += Time.deltaTime; }
        if (actTiempo2 == true) { tiempo2 += Time.deltaTime; }
        if (pararTiempo == true)
        {
            GetComponent<Puntaje>().tiempo = tiempoTemp;
        }
        else
        {
            tiempoTemp = GetComponent<Puntaje>().tiempo;
        }
    }

    public void cambio()
    {
        if (GetComponent<Puntaje>().tiempo <= 0.1f && repite == false)
        {
            movible = false;
            imagen.SetActive(true);
            pararTiempo = true;
            actTiempo = true;
        }

    }

    public void mostarJugador()
    {
        if (tiempo1 >= 3.5f)
        {
            movible = true;
            imagen.SetActive(false);
            GetComponent<Puntaje>().tiempo = 30;
            jugador = 2;
            repite = true;
            actTiempo = false;
            tiempo1 = 0;
            pararTiempo = false;
        }
    }

    public void empiezo()
    {
        if (tiempo2 >= 0.1f&&condi==false)
        {
            movible = false;
            pararTiempo = true;
            condi = true;
            actTiempo = false;
            tiempo1 = 0;
            imgR.sprite = jug[0];
        }
        if (tiempo2 >= 4&&condi==true)
        {
            movible = true;
            pararTiempo = false;
            actTiempo2 = false;
            tiempo2 = 0;
            imgR.sprite = jug[1];
            imagen.SetActive(false);
        }
    }
}
