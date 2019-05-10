using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    public float tiempo;
    public bool inservible;
    public GameObject scripts;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scripts = GameObject.Find("scripts");
        tiempo = Time.deltaTime + tiempo;
        destruir();
    }

    public void destruir()
    {
        if (tiempo >= 2.5f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "piso"|| collision.gameObject.tag == "tronco")
        {
            inservible = true;
        }
        if (collision.gameObject.tag == "personaje")
        {
            if (inservible == false)
            {
                scripts.GetComponent<Puntaje>().puntos++;
            }
            else
            {
                Destroy(gameObject);
            }         
        }
    }
}
