using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiempo : MonoBehaviour
{
    public bool pararTiempo, actTiempo, seAbrio;
    public float tiempoTemp, tiempo1, tiempo2;
    public GameObject per1, per2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        per1 = GameObject.Find("jugador1");
        per2 = GameObject.Find("jugador2");
        pararT();
        terminar();
        if (actTiempo == true) { tiempo1 += Time.deltaTime; }
    }

    public void pararT()
    {
        if (pararTiempo == true)
        {
            GetComponent<Puntaje>().tiempo = tiempoTemp;
        }
        else
        {
            tiempoTemp = GetComponent<Puntaje>().tiempo;
        }
    }

    public void terminar()
    {
        if ((per1.GetComponent<PerCofre>().idTomoCofre!=0&& per2.GetComponent<PerCofre>().idTomoCofre != 0)||GetComponent<Puntaje>().tiempo<=0.2f)
        {
            seAbrio = true;
            pararTiempo = true;
            tiempoTemp = 0.1f;
            actTiempo = true;
        }
        if (tiempo1>=3)
        {
            pararTiempo = false;
        }
    }
}
