using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGlobos : MonoBehaviour
{
    public GameObject globo1, globo2;
    public int punt1, punt2;
    public bool listo1, listo2,termino, actTiempo;
    public float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        estadoGlobo();
        sumarPuntos();
    }

    public void sumarPuntos()
    {
        if (Input.GetKey(KeyCode.E)&&listo1==true&&termino==false)
        {
            punt2++;
            listo1 = false;
            GetComponent<Puntaje>().puntosP2 = punt2;
        }
        if (Input.GetKey(KeyCode.UpArrow)&&listo2==true && termino == false)
        {
            punt1++;
            listo2 = false;
            GetComponent<Puntaje>().puntosP1 = punt1;
        }

        if (Input.GetKey(KeyCode.E)==false)
        {
            listo1 = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)==false)
        {
            listo2 = true;
        }
    }

    public void estadoGlobo()
    {
        globos(globo1, punt1);
        globos(globo2, punt2);
        terminar();
    }

    public void globos(GameObject globo, int punt)
    {
        if (punt <= 25)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 1);
        }
        else if (punt >= 26 && punt<= 50)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 1);
        }
        else if (punt >= 51 && punt <= 75)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 2);

        }
        else if (punt >= 76 && punt <= 100)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 3);
        }
        else if (punt >= 101 && punt <= 125)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 4);

        }
        else if (punt >= 126 && punt <= 150)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 5);
        }
        else if (punt >= 151 && tiempo<=1.4f)
        {
            termino = true;
            globo.GetComponent<Animator>().SetInteger("paso", 6);
            actTiempo = true;
        }
        else if (tiempo >= 1.5f && punt>=151)
        {
            globo.GetComponent<Animator>().SetInteger("paso", 7);
        }
    }

    public void terminar()
    {
        if (tiempo >= 3)
        {
            GetComponent<Puntaje>().tiempo = 0;
        }
        if(GetComponent<Puntaje>().tiempo <= 0.2f&&termino==false)
        {
            GetComponent<Puntaje>().puntosP1 = GetComponent<Puntaje>().puntosP2;
        }
    }

}
