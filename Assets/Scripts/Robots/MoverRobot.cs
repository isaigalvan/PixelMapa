﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRobot : MonoBehaviour
{
    public float tiempoMax, tiempo, velocidad;
    public int direccion, direcAnt=1;
    public bool moviendo, tocando, temp;
    public SpriteRenderer sr;
    public GameObject scripts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scripts = GameObject.Find("Scripts");
        sr = gameObject.GetComponent<SpriteRenderer>();
        tiempo = Time.deltaTime + tiempo;
        mover();
        verTiempo();
    }

    public void mover()
    {
        if (moviendo == false)
        {
                
            do
            {
              direccion = Random.Range(1,9);
            } while (direccion == direcAnt);
            tiempoMax = Random.Range(1.1f, 2.1f);
            velocidad = Random.Range(0.06f, 0.1f);
             moviendo = true;
            direcAnt = direccion;
           
        }
        else
        {
                switch (direccion)
                {
                    case 1:
                        this.transform.position += new Vector3(0, +velocidad, 0);   //ARRIBA
                        break;
                    case 2:
                        this.transform.position += new Vector3(0, -velocidad, 0);  //ABAJO 
                        break;
                    case 3:
                        this.transform.position += new Vector3(velocidad, 0, 0);  //IZQUIERDA
                        sr.flipX = false;
                         break;
                    case 4:
                        this.transform.position += new Vector3(-velocidad, 0, 0);   //DRERECHA
                         sr.flipX = true;
                    break;
                case 5:
                    this.transform.position += new Vector3(-velocidad, velocidad, 0);
                    sr.flipX = true;
                    break;
                case 6:
                    this.transform.position += new Vector3(-velocidad, -velocidad, 0);
                    sr.flipX = true;
                    break;
                case 7:
                    this.transform.position += new Vector3(velocidad, velocidad, 0);
                    sr.flipX = false;
                    break;
                case 8:
                    this.transform.position += new Vector3(velocidad, -velocidad, 0);
                    sr.flipX = false;
                    break;
                default:
                    break;
                }
        }

    }

    public void verTiempo()
    {
        if(tiempo>= tiempoMax)
        {
            moviendo = false;
            tiempo = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
    /*    if(collision.gameObject.tag == "pared"|| collision.gameObject.tag == "obs")
        {
            moviendo = false;
            tiempo = 0;
            tocando = true;
        }*/
        if(collision.gameObject.name== "jugador1")
        {
            scripts.GetComponent<Puntaje>().puntosP1++;
            scripts.GetComponent<CrearRobot>().estaEnJuego = false;
            Destroy(gameObject);         
        }
        if (collision.gameObject.name == "jugador2")
        {
            scripts.GetComponent<Puntaje>().puntosP2++;
            scripts.GetComponent<CrearRobot>().estaEnJuego = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pared" || collision.gameObject.tag == "obs")
        { 
            tocando = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Arriba")
        {
            tiempo = 0;
            direccion = 2;
            tiempoMax = .5f;
            velocidad = Random.Range(0.06f, 0.1f);
        }
        if (collision.gameObject.name == "Abajo")
        {
            tiempo = 0;
            direccion = 1;
            tiempoMax = .5f;
            velocidad = Random.Range(0.06f, 0.1f);
        }
        if (collision.gameObject.name == "Derecha")
        {
            tiempo = 0;
            direccion = 4;
            tiempoMax = .5f;
            velocidad = Random.Range(0.06f, 0.1f);
        }
        if (collision.gameObject.name == "Izquierda")
        {
            tiempo = 0;
            direccion = 3;
            tiempoMax = .5f;
            velocidad = Random.Range(0.06f, 0.1f);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
       
            

