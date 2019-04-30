using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject scripts; 
    public float posx, posy;

    /// <summary>
    /// Update
    /// este metodo se invoca una vez por cada frame
    /// La camara seguira al personaje, se almacena en el objeto scripts el objeto con el nombre "scripts", la variable "posx" almacenara
    /// el valor de "posx" del script "CrearPersonaje", la variable "posy" almacenara el valor de "posy" del script "CrearPersonaje", la
    /// posicion de la camara se le asignara la cordenada "posx","posy",-10
    /// </summary>
    private void Update()
    {
        scripts = GameObject.Find("Scripts");
        posx = scripts.GetComponent<CrearPersonaje>().posx;
        posy = scripts.GetComponent<CrearPersonaje>().posy;
        gameObject.transform.position = new Vector3(posx, posy, -10);
    }


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

    }*/
