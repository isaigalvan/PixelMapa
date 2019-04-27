using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject scripts; 
    public float posx, posy;


    private void Update()
    {
        scripts = GameObject.Find("Scripts");
        posx = scripts.GetComponent<CrearPersonaje>().posx;
        posy = scripts.GetComponent<CrearPersonaje>().posy;
        gameObject.transform.position = new Vector3(posx, posy, -10);
    }


}



/*
void Update()
    {
        if (seDetuvo == false) { tiempo = Time.deltaTime + tiempo; }
        asignar();
       
    }

    void LateUpdate()
     {
         transform.position = player.transform.position + offset;
     }
    public void asignar()
    {
        if (tiempo >= 0.001f)
        {
            player = GameObject.FindGameObjectWithTag("PerPref");
            offset = transform.position - player.transform.position;
            seDetuvo = true;
            tiempo = 0;
        }

    }*/
