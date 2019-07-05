using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerPastel : MonoBehaviour
{
    public int paso=0, idPastelTomado, puntos, idPastel, numJugador;
    public float tiempo;
    public bool actTiempo, solto, tomo;
    public bool[] estaTocando = new bool[4];
    public GameObject scripts, c1,c2,c3,c4;
    // Start is called before the first frame update
    void Start()
    {

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
        moverP2();
        soltar();
        soltarEnCaja();
       if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
    }

    public void mover()
    {
        if (numJugador == 1)
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
    }

    public void moverP2()
    {
        if (numJugador == 2)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(-0.07f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0.07f, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0, +0.07f, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0, -0.07f, 0);
            }
            if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", false);
            }
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
                    puntosMas();
                }
                else
                {
                    puntosMenos();
                }
            }
            else if (estaTocando[1] )
            {
                if (idPastelTomado == idPastel && idPastelTomado == c2.GetComponent<Caja>().idCaja)
                {
                    puntosMas();
                }
                else
                {
                    puntosMenos();
                }
            }
            else if (estaTocando[2])
            {
                if (idPastelTomado == idPastel && idPastelTomado == c3.GetComponent<Caja>().idCaja)
                {
                    puntosMas();
                }
                else
                {
                    puntosMenos();
                }
            }
            else if (estaTocando[3])
            {
                if (idPastelTomado == idPastel && idPastelTomado == c4.GetComponent<Caja>().idCaja)
                {
                    puntosMas();
                }
                else
                {
                    puntosMenos();
                }

            }
            else
            {
                puntosMenos();
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

    public void puntosMas()
    {
        if(numJugador == 1)
        {
            scripts.GetComponent<Puntaje>().puntosP1++;
        }
        else
        {
            scripts.GetComponent<Puntaje>().puntosP2++;
        }
    }

    public void puntosMenos()
    {
        if (numJugador== 1)
        {
            scripts.GetComponent<Puntaje>().puntosP1--;
        }
        else
        {
            scripts.GetComponent<Puntaje>().puntosP2--;
        }
    }
}
