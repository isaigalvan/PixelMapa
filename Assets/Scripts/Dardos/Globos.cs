using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globos : MonoBehaviour
{
    public float vidaGlobo = 15f;
    public GameObject scripts;
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        Debug.Log(colInfo.relativeVelocity.magnitude);
        if (colInfo.relativeVelocity.magnitude > vidaGlobo)
        {
            explota();
            
        }
    }

    void explota()
    {
        gameObject.SetActive(false);
        nombres();
        if (scripts.GetComponent<ControlJugador>().jugador == 1)
        {
            scripts.GetComponent<Puntaje>().puntosP1++;
        }
        else
        {
            scripts.GetComponent<Puntaje>().puntosP2++;
        }
        
    }

    private void Start()
    {
        scripts = GameObject.Find("Scripts");
    }

    public void nombres()
    {
        for(int z = 0; z<7; z++)
        {
            if (gameObject.name == "Globo" + (z))
            {
                scripts.GetComponent<CrearGlobos>().Explotados[z] = true;
            }
        }
       
    }
}
