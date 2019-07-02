using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resultados : MonoBehaviour
{
    public float tiempo;
    public bool condi;
    public int PP1, PP2;

    public Sprite[] GanoEmpate;
    public Sprite[] GanoPH;
    public Sprite[] GanoJugador;
    public SpriteRenderer spriteGanoEmpate, spritePH, spriteJugador;

    public GameObject GE, PH, J;

    private void Start()
    {
        PP1 = ResultadosEstaticos.PuntosP1;
        PP2 = ResultadosEstaticos.PuntosP2;
        GE = GameObject.Find("Gano");
        PH = GameObject.Find("ph");
        J = GameObject.Find("Jugador");
        spriteGanoEmpate = GE.GetComponent<SpriteRenderer>();
        spritePH = PH.GetComponent<SpriteRenderer>();
        spriteJugador = J.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        resultados();
        if (tiempo >= 4)
        {
            SceneManager.LoadScene("01-Mapa");
        }
    }

    public void resultados()
    {
        if (PP1 == PP2)
        {
            empat();
        }
        if (PP1 > PP2)
        {
            ganador(0);
            if (condi == false)
            {
                RestablecerValores.ph++;
                condi = true;
            }
            
        }
        if (PP2 > PP1)
        {
            ganador(1);
            if (condi == false)
            {
                RestablecerValores.phP2++;
                condi = true;
            }
        }
    }

    public void empat()
    {
        if (tiempo >= 1)
        {
            spriteGanoEmpate.sprite = GanoEmpate[1];
        }
        if (tiempo >= 2f)
        {
            spritePH.sprite = GanoPH[1];
        }
 
    }

    public void ganador(int gano)
    {
        if (tiempo >= 1)
        {
            spriteGanoEmpate.sprite = GanoEmpate[0];
        }
        if (tiempo >= 2f)
        {
            spriteJugador.sprite = GanoJugador[gano];
        }
        if (tiempo >= 3f)
        {
            spritePH.sprite = GanoPH[0];
        }
    }
}
