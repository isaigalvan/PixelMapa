using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultadosFinales : MonoBehaviour
{
    public float tiempo;
    public bool condi;
    public int jugador, idJugador;

    public Sprite Gano;
    public Sprite[] GanoJugador;
    public Sprite[] Pose;
    public SpriteRenderer spriteGano, spriteJugador,spritePose;

    public GameObject Boton, posePos;

    private void Start()
    {
       jugador = ResultadosEstaticos.jugador;
       idJugador = ResultadosEstaticos.idJugador;

    }
    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        ganador();
        if (tiempo >= 4)
        {
            Boton.SetActive(true);
        }
    }

    public void ganador()
    {
        if (tiempo >= 1)
        {
            spriteGano.sprite = Gano;
        }
        if (tiempo >= 2f)
        {
            spriteJugador.sprite = GanoJugador[jugador];
        }
        if (tiempo >= 3f)
        {
            spritePose.sprite = Pose[idJugador];
            if (idJugador == 2) { posePos.transform.position = new Vector3(6, -2); }
            if (idJugador == 5) { posePos.transform.position = new Vector3(6, -1); }
        }

    }

    public void salirMenu()
    {
        SceneManager.LoadScene("Main");
    }
}

