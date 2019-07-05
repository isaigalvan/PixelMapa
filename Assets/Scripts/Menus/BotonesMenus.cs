using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenus : MonoBehaviour
{
    public void CargarMain()
    {
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
}
