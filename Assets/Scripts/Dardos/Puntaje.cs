using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI textCont, Tiempo;
    public int puntos;
    public float tiempo;
    private void Start()
    {
        tiempo = 10;
    }
    private void Update()
    {
        actualizarUI();
        if (tiempo <= 0.0f)
        {
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            tiempo -= Time.deltaTime;
        }
    }

    public void actualizarUI()
    {
        textCont.text = "PUNTOS:" + puntos;
        Tiempo.text = "Tiempo:" + "" + tiempo.ToString("f0");
    }
}
