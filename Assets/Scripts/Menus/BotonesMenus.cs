using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenus : MonoBehaviour
{
    public GameObject  botones, marcoPausa;
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
}
