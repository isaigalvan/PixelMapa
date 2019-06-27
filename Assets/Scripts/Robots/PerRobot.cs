using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerRobot : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject pruebaFondo;
    public int numJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        mover();
        moverP2();
    }

    public void mover()
    {
        if (numJugador == 1) { 
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
        if (numJugador == 2) { 
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
}
