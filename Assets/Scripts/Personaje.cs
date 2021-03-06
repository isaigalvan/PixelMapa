﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    public int casillaActual=0, ph=0, idPer;
    public SpriteRenderer spriteR;
    public GameObject textCasilla, textPh,scripts;
    public bool esPintado, esBloqueado, esBuff, esNerf, esInmune, esAtraido, verificado, condi;
    public bool verfi, actTiempo, condi2, condiRobar, condiHab3Leonn;
    public float tiempo;

    /// <summary>
    /// Update
    /// Este metodo se llama una vez por frame
    /// Manda a llamar a los metodos "imprimeCasilla" y "verificarCasilla"
    /// </summary>
    void Update()
    {
        verificaCasilla();
        if (actTiempo) { tiempo = Time.deltaTime + tiempo; }
        actMinijuego();
    }

    /// <summary>
    /// Awake
    /// este metodo se invoca al ejecutarse el programa
    /// el objeto "textCasilla" se le asignara el objeto con la etiqueta "NumCasilla"
    /// el objeto "textPh" se le asignara el objeto con la etiqueta "Ph"
    /// el objeto "scripts" se le asignara el objeto con la etiqueta "Scripts"
    /// </summary>
    private void Awake()
    {
        textCasilla = GameObject.FindGameObjectWithTag("NumCasilla");
        textPh = GameObject.FindGameObjectWithTag("Ph");
        scripts = GameObject.Find("Scripts");

    }
    
    /// <summary>
    /// AsignarTamanos
    /// Este metodo se invoca en el metodo "Crear" del script "CrearPersonaje"
    /// Se toma el valor "idPersonaje" para entrar dentro de un switch, en el caso 0 y caso 5 se transforma la escala en .23, en el caso 1
    /// en .25, en el caso 2 en .26, en el caso 3 en .29 y en el caso 4 en .24
    /// </summary>
    public void AsignarTamanos(int idPersonaje)
    {
        switch (idPersonaje)
        {
            case 0:
            case 5:
                transform.localScale = new Vector3(0.23f, 0.23f, 1);
                break;
            case 2:
                transform.localScale = new Vector3(0.26f, 0.26f, 1);
                break;
 
            default:
                break;
        }
    }

  


    /// <summary>
    /// verificarCasilla
    /// este metodo es llamado por update
    /// verifica la casilla en la que cayo el jugador para realizar acciones dependiendo del tipo de casilla en el que cayo 
    /// primero se verifica si el jugador ya tiro mediante la variable "yaTiro" comparandola con el valor true y la variable "esTurno" comparandola con false, en caso de que se cumpla
    /// se verifica si el el valor "casillaActual-1" de la lista "casillas" es del tipo de habilidad comparando la variable "esHabilidad" con el valor true, en caso de 
    /// que se cumpla, se verifica si la variable "ph" es mayor o igual a 4, en caso de ser asi la variable "ph" se le asignara el valor de 4, en caso contrario se le 
    /// sumara 1 a la variable "ph", en caso de no ser del tipo "esHabilidad" se compara si es del tipo "esDesabilidad" si dicha variable es igual a true
    /// se verifica si la variable "ph" es igual a 0, en caso de ser asi la variable "ph" se le asignara el valor de 0, en caso contrario se le 
    /// restara 1 a la variable "ph", en caso de no ser tipo "esDeshabilidad" se compara si es del tipo "esNegra" si dicha variable es igual a true
    /// en este caso automaticamente la variable "ph"se le asigna el valor de 0, terminando esto se manda a llamar el metodo "imprimePh"
    /// </summary>
    public void verificaCasilla()
    {
        if( (gameObject.name=="jugador1"&&scripts.GetComponent<Dado>().jugador==1)|| (gameObject.name == "jugador2" && scripts.GetComponent<Dado>().jugador == 2))
        {
            verfi = true;
        if(scripts.GetComponent<Dado>().yaTiro == true)
        {
                condi = true;

        }
         if (scripts.GetComponent<Dado>().caminando == true)
        {
                verifRobar();
        }
            if ((casillaActual > 0 && verificado == false && scripts.GetComponent<Dado>().caminando == false && condi == true && scripts.GetComponent<Dado>().yaTiro == false&&condiHab3Leonn==false) || (scripts.GetComponent<Habilidades>().verCasiHab1Zor == true))
        {
                verifPintura();
                if (scripts.GetComponent<Habilidades>().sumaPuntos && casillaActual > scripts.GetComponent<Habilidades>().casillaSumPuntos)
                {
                    ph++;
                    scripts.GetComponent<Habilidades>().sumaPuntos = false;
                    if (scripts.GetComponent<Dado>().jugador == 1)
                    {
                        RestablecerValores.ph++;
                    }
                    else
                    {
                        RestablecerValores.phP2++;
                    }
                }
                if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esHabilidad == true)
                {
                    if (ph >= 4)
                    {
                        ph = 4;
                    }
                    else
                    {
                        ph++;
                    }
                    scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;

                }
                else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDeshabilidad == true)
                {
                    if (ph <= 0)
                    {
                        ph = 0;
                    }
                    else
                    {
                        ph--;
                    }
                    scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                }
                else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esNegra == true)
                {
                    ph = 0;
                }
               
                else if(scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esFinal == true)
                {
                    ResultadosEstaticos.jugador = scripts.GetComponent<Dado>().jugador-1;
                    ResultadosEstaticos.idJugador = this.idPer;
                    SceneManager.LoadScene("GanadorFinal");
                }
                else if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esMinijuego == true)
                {
                    cambiarAntesMinijuego();   
                }
                
            verificado = false;
            condi = false;
                condiRobar = false;
                condiHab3Leonn = false;
            scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                scripts.GetComponent<TextoBarra>().actualizarTexto();
            }        
        }
    }

    public void verifPintura()
    {
        if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esPintada == true)
        {
            esPintado = true;
        }
        else
        {
            esPintado = false;
            if (scripts.GetComponent<Dado>().jugador == 1)
            {
                RestablecerValores.estados[0] = false;
            }
            else
            {
                RestablecerValores.estadosP2[0] = false;
            }
        }
    }

    public void actMinijuego()
    {
        if (tiempo >= .5f)
        {
            actTiempo = false;
            tiempo = 0;
            SceneManager.LoadScene("PreJuego");

        }
    }

    public void verifRobar()
    {
        if (condiRobar == false)
        {
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDesLeonn == true)
            {

                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                scripts.GetComponent<Habilidades>().robar1();
            }
            if (scripts.GetComponent<CrearCasilla>().casillas[casillaActual].GetComponent<Casilla>().esDesLeonn2 == true)
            {

                scripts.GetComponent<Habilidades>().verCasiHab1Zor = false;
                scripts.GetComponent<Habilidades>().robar2();
            }
            condiRobar = true;
        }
        
    }

    public void cambiarAntesMinijuego()
    {
        actTiempo = true;
        if (scripts.GetComponent<Dado>().jugador == 1)
        {
            if (scripts.GetComponent<Habilidades>().verCasiHab1Zor)
            {

                RestablecerValores.jugador = 1;
                RestablecerValores.valorSpriteLetrero = 0;
                RestablecerValores.casillaActual += 3;
                RestablecerValores.posx = gameObject.transform.position.x;
            }
            else
            {
                RestablecerValores.jugador = 2;
                RestablecerValores.valorSpriteLetrero = 1;
            }
        }
        else
        {
            if (scripts.GetComponent<Habilidades>().verCasiHab1Zor)
            {
                RestablecerValores.jugador = 2;
                RestablecerValores.valorSpriteLetrero = 1;
                RestablecerValores.casillaActualP2 += 3;
                RestablecerValores.posxP2 = gameObject.transform.position.x;
            }
            else
            {
                RestablecerValores.jugador = 1;
                RestablecerValores.valorSpriteLetrero = 0;
            }
        }
        Debug.Log(RestablecerValores.casillaActualP2);
        Debug.Log(RestablecerValores.casillaActual);
    }
    
}
