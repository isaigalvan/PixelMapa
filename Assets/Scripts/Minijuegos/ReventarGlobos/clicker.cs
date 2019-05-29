using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{
    public bool ganador = false;
    public bool perdedor = false;
    public Button boton;
    public int maxClicks = 20;

    private int clicks = 0;

    public void BotonClick()
    {
        clicks++;

        if (clicks == maxClicks)
        {
            ganador = true;
            gameObject.GetComponent<Animator>().SetBool("perdedor", perdedor);
            gameObject.GetComponent<Animator>().SetBool("ganador", ganador);
            Debug.Log("__________Ganador__________");
        }
        else if(clicks > maxClicks)
        {
            boton.interactable = false;
            perdedor = true;
            gameObject.GetComponent<Animator>().SetBool("perdedor", perdedor);
            gameObject.GetComponent<Animator>().SetBool("ganador", ganador);
            Debug.Log("__________Perdedor__________");

        }

        Debug.Log(clicks);
    }
}
