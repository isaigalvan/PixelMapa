using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject scripts; 
    public float posx=5, posy;
    public float posxP2=5, posyP2;
    public float temposx = 5, dif;
    public bool condi, actTiempo;
    public float tiempo;
    /// <summary>
    /// Update
    /// este metodo se invoca una vez por cada frame
    /// La camara seguira al personaje, se almacena en el objeto scripts el objeto con el nombre "scripts", la variable "posx" almacenara
    /// el valor de "posx" del script "CrearPersonaje", la variable "posy" almacenara el valor de "posy" del script "CrearPersonaje", la
    /// posicion de la camara se le asignara la cordenada "posx","posy",-10
    /// </summary>
    private void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        scripts = GameObject.Find("Scripts");
        if (scripts.GetComponent<Dado>().jugador == 1)
        {
            posx = scripts.GetComponent<CrearPersonaje>().posx;
            posy = scripts.GetComponent<CrearPersonaje>().posy;
            gameObject.transform.position = new Vector3(posx, posy, -10);
        }
        if (scripts.GetComponent<Dado>().jugador == 2)
        {
            posxP2 = scripts.GetComponent<CrearPersonaje>().posxP2;
            posyP2 = scripts.GetComponent<CrearPersonaje>().posyP2;
            gameObject.transform.position = new Vector3(posxP2, posyP2, -10);
        }
        if (scripts.GetComponent<Dado>().movCamara ==true)
        {
            cambio();
        }
    }

    public void cambio()
    {
        if (scripts.GetComponent<Dado>().jugador == 1&&condi==false)
        {
            scripts.GetComponent<Dado>().jugador = 2;
            scripts.GetComponent<Dado>().Letrero.SetActive(true);
            scripts.GetComponent<Dado>().spriteRLetrero.sprite = scripts.GetComponent<Dado>().spriteJugador[1];
            condi = true;
            actTiempo = true;
        }
        if (scripts.GetComponent<Dado>().jugador == 2 && condi == false)
        {
            scripts.GetComponent<Dado>().jugador = 1;
            scripts.GetComponent<Dado>().Letrero.SetActive(true);
            scripts.GetComponent<Dado>().spriteRLetrero.sprite = scripts.GetComponent<Dado>().spriteJugador[0];
            condi = true;
            actTiempo = true;
        }
        if (tiempo >= 2)
        {    
            scripts.GetComponent<Dado>().esTurno = true;
            scripts.GetComponent<Dado>().condiTurno = true;
            scripts.GetComponent<Dado>().movCamara = false;
            condi = false;
            actTiempo = false;
            tiempo = 0;
        }
        
    }

    /*public void movP1aP2()
    {
        if (scripts.GetComponent<Dado>().jugador == 1)
        {
            if (condi == false)
            {
                temposx = posx;
                condi = true;
            }
            if (posx > posxP2)
            {
                temposx = temposx - 0.05f;
                gameObject.transform.position = new Vector3(temposx, 2.7f, -10);
            }
            if (posx < posxP2)
            {
                temposx = temposx + 0.05f;
                gameObject.transform.position = new Vector3(temposx, 2.7f, -10);
            }
            dif = temposx - posxP2;
            if (dif <= 0.1f || dif >= -0.1f)
            {
                cambio();
                condi = false;
            }
        }
    }

    public void movP2aP1()
    {
        if (scripts.GetComponent<Dado>().jugador == 2)
        {
            if (condi == false)
            {
                temposx = posxP2;
                condi = true;
            }
            if (posxP2 > posx)
            {
                temposx = temposx - 0.05f;
                gameObject.transform.position = new Vector3(temposx, 2.7f, -10);
            }
            if (posxP2 < posx)
            {
                temposx = temposx + 0.05f;
                gameObject.transform.position = new Vector3(temposx, 2.7f, -10);
            }
            dif = temposx - posx;
            if (dif <= 0.1f || dif >= -0.1f)
            {
                cambio();
                condi = false;
            }
        }
    }*/
}



/*
void Update()
    {
        if (seDetuvo == false) { tiempo = Time.deltaTime + tiempo; }
        asignar();
       
    }

    void LateUpdate()
     {
         transform.position = player.transform.position + offset;
     }
    public void asignar()
    {
        if (tiempo >= 0.001f)
        {
            player = GameObject.FindGameObjectWithTag("PerPref");
            offset = transform.position - player.transform.position;
            seDetuvo = true;
            tiempo = 0;
        }



    scripts = GameObject.Find("Scripts");
        posx = scripts.GetComponent<CrearPersonaje>().posx;
        posy = scripts.GetComponent<CrearPersonaje>().posy;
        gameObject.transform.position = new Vector3(posx, posy, -10);


    }*/
