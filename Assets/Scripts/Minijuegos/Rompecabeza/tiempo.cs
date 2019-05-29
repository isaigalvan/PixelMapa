using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class tiempo : MonoBehaviour
{
    public TextMeshProUGUI tiempoUI;
    public float tiempoJuego;

    private void Update()
    {
        actualizarUI();
        if (tiempoJuego <= 0.0f)
        {
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            tiempoJuego -= UnityEngine.Time.deltaTime;
        }
    }

    public void actualizarUI()
    {
        tiempoUI.text = "Tiempo:" + "" + tiempoJuego.ToString("f0");
    }
}
