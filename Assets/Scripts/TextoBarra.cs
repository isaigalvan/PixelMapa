using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoBarra : MonoBehaviour
{
    public GameObject  jugador1, jugador2;
    public TextMeshProUGUI textCasilla, textPh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jugador1 = GameObject.Find("jugador1");
        jugador2 = GameObject.Find("jugador2");

       
    }

    /// <summary>
    /// imprimeCasilla
    /// Este metodo es llamado por update, despues del turno del jugador imprime la casilla actual del jugador de todo el tablero 
    /// primero se verifica si el turno del jugador ya termino comparando la variable "esTurno" con el valor false, en caso de que se cumpla la condicion 
    /// verifica si la variable "casillaActual" del jugador es menor a 10, en ese caso se imprime un 0 y despues la variable "casillaActual" en el objeto de texto
    /// "textoCasillaActual", en caso de que la variable "casillaActual" sea mayor a 10 y menor a 100, solo se imprime la variable "casillaActual" en el objeto de 
    /// texto "textoCasillaActual", en caso de que la variable "casillaActual" sea mayor a 100, se reucira el tamaño de la fuente a un valor de 30 del objeto de texto 
    /// "textoCasilaActual"
    /// </summary>
    public void imprimeCasilla(GameObject per)
    {

            if (per.GetComponent<Personaje>().casillaActual < 10)
            {
                textCasilla.text = "0" + per.GetComponent<Personaje>().casillaActual;
            }
            else
            {
                textCasilla.GetComponent<TextMeshProUGUI>().text = "" + per.GetComponent<Personaje>().casillaActual;
            }
            if (per.GetComponent<Personaje>().casillaActual >= 100)
            {
                textCasilla.GetComponent<TextMeshProUGUI>().fontSize = 30;
            }
        
    }

    /// <summary>
    /// imprimePh
    /// Este metodo es llamado por verificarCasilla, imprime el valor de los puntos de habilidad del jugador
    /// Este metodo imprime la variable "ph" en el objeto de texto "textoPH"
    /// </summary>
    public void imprimePh(GameObject per)
    {
        textPh.text = "" + per.GetComponent<Personaje>().ph;
    }

    public void actualizarTexto()
    {
        if (GetComponent<Dado>().jugador == 1)
        {
            imprimeCasilla(jugador1);
            imprimePh(jugador1);
        }
        else
        {
            imprimeCasilla(jugador2);
            imprimePh(jugador2);
        }
    }
}
