using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI textCont,textContP2, Tiempo;
    public int puntosP1, puntosP2;
    public float tiempo;
    private void Start()
    {
    }
    private void Update()
    {
        actualizarUI();
        if (tiempo <= 0.0f)
        {
            SceneManager.LoadScene("Ganador");
            ResultadosEstaticos.PuntosP1 = puntosP1;
            ResultadosEstaticos.PuntosP2 = puntosP2;
        }
        else
        {
            tiempo -= Time.deltaTime;
        }
    }

    public void actualizarUI()
    {
        textCont.text = "P1:" + puntosP1;
        textContP2.text = "P2:" + puntosP2;
        Tiempo.text = "Tiempo:" + "" + tiempo.ToString("f0");
    }
}
