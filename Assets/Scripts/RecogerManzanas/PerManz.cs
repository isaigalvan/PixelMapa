using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerManz : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public bool pisando, actTiempo;
    public float jumpv, tiempo;
    public int saltos;
    // Start is called before the first frame update
    void Start()
    {
        jumpv = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        mover();
        spriteSaltar();
        sr= gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            sr.flipX = true;
            this.transform.position += new Vector3(-0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            sr.flipX = false;
            this.transform.position += new Vector3(0.07f, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow)&&pisando==true&&saltos==0)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
            pisando = false;
            rb.AddForce(Vector2.up * jumpv, ForceMode2D.Impulse);
            saltos = 1;
            actTiempo = true; 
        }

        if (Input.GetKey(KeyCode.UpArrow) && saltos == 1 && tiempo >= .4f)
        {
            pisando = false;
            rb.AddForce(Vector2.up * (jumpv), ForceMode2D.Impulse);
            saltos = 2;
            actTiempo = false;
            tiempo = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
            gameObject.GetComponent<Animator>().SetBool("saltando", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            saltos = 0;
            pisando = true;
        }
        if (collision.gameObject.tag == "tronco")
        {
            saltos = 1;
            actTiempo = true;
            pisando = true;
        }
    }
 

    public void spriteSaltar()
    {
        if (pisando == true)
        {
            gameObject.GetComponent<Animator>().SetBool("saltando", false);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("saltando", true);
        }
    }
}
