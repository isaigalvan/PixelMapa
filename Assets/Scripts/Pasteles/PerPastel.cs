using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerPastel : MonoBehaviour
{
    public int paso=0, idPersonaje, idPastelTomado, puntos, idPastel;
    public float tiempo;
    public bool actTiempo, solto;
    public bool[] estaTocando = new bool[4];
    public GameObject scripts, c1,c2,c3,c4;
    // Start is called before the first frame update
    void Start()
    {
       idPastel = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        scripts = GameObject.Find("scripts");
        c1 = GameObject.Find("caja1");
        c2 = GameObject.Find("caja2");
        c3 = GameObject.Find("caja3");
        c4 = GameObject.Find("caja4");
        mover();
        soltar();
        soltarEnCaja();
       if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
    }

    public void mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando",true);
            this.transform.position += new Vector3(-0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0, +0.07f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0,-0.07f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)==false&& Input.GetKey(KeyCode.RightArrow) == false&& Input.GetKey(KeyCode.UpArrow) == false&&Input.GetKey(KeyCode.DownArrow) == false)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
        }
    }

    public void soltar()
    {
        if (tiempo >= 0.5f)
        {
            paso = 0;
            actTiempo = false;
            tiempo = 0;
        }
    }

    public void soltarEnCaja()
    {
        if (solto)
        {
            if (estaTocando[0])
            {
                if (idPastelTomado == idPastel && idPastelTomado == c1.GetComponent<Caja>().idCaja)
                {
                    scripts.GetComponent<Puntaje>().puntos++;
                }
                else
                {
                    scripts.GetComponent<Puntaje>().puntos--;
                }
            }
            else if (estaTocando[1] )
            {
                if (idPastelTomado == idPastel && idPastelTomado == c2.GetComponent<Caja>().idCaja)
                {
                    scripts.GetComponent<Puntaje>().puntos++;
                }
                else
                {
                    scripts.GetComponent<Puntaje>().puntos--;
                }
            }
            else if (estaTocando[2])
            {
                if (idPastelTomado == idPastel && idPastelTomado == c3.GetComponent<Caja>().idCaja)
                {
                    scripts.GetComponent<Puntaje>().puntos++;
                }
                else
                {
                    scripts.GetComponent<Puntaje>().puntos--;
                }
            }
            else if (estaTocando[3])
            {
                if (idPastelTomado == idPastel && idPastelTomado == c4.GetComponent<Caja>().idCaja)
                {
                    scripts.GetComponent<Puntaje>().puntos++;
                }
                else
                {
                    scripts.GetComponent<Puntaje>().puntos--;
                }

            }
            else
            {
                scripts.GetComponent<Puntaje>().puntos--;
            }
            solto = false;
            idPastelTomado = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "caja1")
        {
            estaTocando[0] = true;
        }
        if (collision.gameObject.name == "caja2")
        {
            estaTocando[1] = true;
        }
        if (collision.gameObject.name == "caja3")
        {
            estaTocando[2] = true;
        }
        if (collision.gameObject.name == "caja4")
        {
            estaTocando[3] = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "caja1")
        {
            estaTocando[0] = false;
        }
        if (collision.gameObject.name == "caja2")
        {
            estaTocando[1] = false;
        }
        if (collision.gameObject.name == "caja3")
        {
            estaTocando[2] = false;
        }
        if (collision.gameObject.name == "caja4")
        {
            estaTocando[3] = false;
        }
    }
}
