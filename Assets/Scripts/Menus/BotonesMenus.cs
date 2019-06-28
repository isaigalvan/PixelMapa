using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenus : MonoBehaviour
{
    public void salirCreditos()
    {
        SceneManager.LoadScene("Main");
    }

    public void entrarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
