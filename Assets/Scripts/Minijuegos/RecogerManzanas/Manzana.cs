using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    public float tiempo;
    public bool inservible;
    public GameObject scripts;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scripts = GameObject.Find("Scripts");
        rb = gameObject.GetComponent<Rigidbody2D>();
        bc = gameObject.GetComponent<BoxCollider2D>();
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
            Destroy(bc);
            Destroy(rb);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Personaje" && inservible == false)
        {
            Destroy(bc);
            if (inservible == false)
            {
                scripts.GetComponent<Puntaje>().puntos++;

            }
            Destroy(gameObject);
        }
    }
}
