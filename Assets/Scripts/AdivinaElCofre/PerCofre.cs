using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerCofre : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject pruebaFondo, scripts;
    public int numJugador, idTomoCofre;
    public bool[] estaTocando = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        scripts = GameObject.Find("Scripts");
        sr = gameObject.GetComponent<SpriteRenderer>();
        mover();
        moverP2();
        abrir();
    }

    public void mover()
    {
        if (numJugador == 1 && idTomoCofre==0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(-0.07f, 0, 0);

                sr.flipX = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0.07f, 0, 0);

                sr.flipX = false;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0, +0.07f, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0, -0.07f, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", false);
            }
        }
    }

    public void moverP2()
    {
        if (numJugador == 2 && idTomoCofre == 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(-0.07f, 0, 0);

                sr.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                this.transform.position += new Vector3(0.07f, 0, 0);

                sr.flipX = false;
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

    public void abrir()
    {
        if (Input.GetKey(KeyCode.Space) == true && numJugador==1)
        {
            if (estaTocando[0] == true)
            {
               idTomoCofre = 1;
            }
            if (estaTocando[1] == true)
            {
                idTomoCofre = 2;
            }
            if (estaTocando[2] == true)
            {
                idTomoCofre = 3;
            }
            verfGanador(idTomoCofre);
        }
        if (Input.GetKey(KeyCode.E) == true && numJugador == 2)
        {
            if (estaTocando[0] == true)
            {
                idTomoCofre = 1;
            }
            if (estaTocando[1] == true)
            {
                idTomoCofre = 2;
            }
            if (estaTocando[2] == true)
            {
                idTomoCofre = 3;
            }
            verfGanador(idTomoCofre);
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cofre1")
        {
            estaTocando[0] = true;
        }
        if (collision.gameObject.name == "cofre2")
        {
            estaTocando[1] = true;
        }
        if (collision.gameObject.name == "cofre3")
        {
            estaTocando[2] = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
            if (collision.gameObject.name == "cofre1")
            {
                estaTocando[0] = false;
            }
            if (collision.gameObject.name == "cofre2")
            {
                estaTocando[1] = false;
            }
            if (collision.gameObject.name == "cofre3")
            {
                estaTocando[2] = false;
            }
    }

    public void verfGanador(int idPer)
    {
        if (numJugador == 1)
        {
            if (scripts.GetComponent<CrearMapaAC>().cofre == idPer)
            {
                scripts.GetComponent<Puntaje>().puntosP1++;
            }
        }
        else
        {
            if (scripts.GetComponent<CrearMapaAC>().cofre == idPer)
            {
                scripts.GetComponent<Puntaje>().puntosP2++;
            }
        }
    }
}
