using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BotonesMenus : MonoBehaviour
{
    public GameObject  botones, marcoPausa, dado, marcoMinimapa, per1, per2;
    public TextMeshProUGUI pos1, pos2;
    public void CargarMain()
    {
        RestablecerValores.ponerRespawn(false);
        RestablecerValores.Reiniciar();
        RestablecerCasilla.respawn = false;
        SceneManager.LoadScene("Main"); 
    }

    public void CargarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void CargarSeleccion()
    {
        SceneManager.LoadScene("Seleccion");
    }

    public void CargarAyuda()
    {
        SceneManager.LoadScene("Ayuda");
    }

    public void pausa()
    {
        marcoPausa.SetActive(true);
        botones.SetActive(false);
    }

    public void regresar()
    {
        marcoPausa.SetActive(false);
        botones.SetActive(true);

    }

    public void minimapa()
    {
        per1 = GameObject.Find("jugador1");
        per2 = GameObject.Find("jugador2");
        marcoMinimapa.SetActive(true);
        botones.SetActive(false);
        pos1.text = ""+per1.GetComponent<Personaje>().casillaActual;
        pos2.text = "" + per2.GetComponent<Personaje>().casillaActual;
    }

    public void cerrar()
    {
        marcoMinimapa.SetActive(false);
        botones.SetActive(true);
    }

    public void salir()
    {
        Application.Quit();
    }
}
