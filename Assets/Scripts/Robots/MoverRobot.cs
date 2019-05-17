using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRobot : MonoBehaviour
{
    public float tiempoMax, tiempo, velocidad;
    public int direccion, direcAnt=1;
    public bool moviendo, tocando;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        tiempo = Time.deltaTime + tiempo;
        mover();
        verTiempo();
    }

    public void mover()
    {
        if (moviendo == false)
        {
            direccion = Random.Range(1, 9);
            do
            {
              direccion = Random.Range(1,9);
            } while (direccion == direcAnt);
            tiempoMax = Random.Range(1.1f, 2.1f);
            velocidad = Random.Range(0.05f, 0.1f);
             moviendo = true;
            direcAnt = direccion;
           
        }
        else
        {
                switch (direccion)
                {
                    case 1:
                        this.transform.position += new Vector3(0, +velocidad, 0);
                        break;
                    case 2:
                        this.transform.position += new Vector3(0, -velocidad, 0);
                        break;
                    case 3:
                        this.transform.position += new Vector3(velocidad, 0, 0);
                        sr.flipX = false;
                         break;
                    case 4:
                        this.transform.position += new Vector3(-velocidad, 0, 0);
                         sr.flipX = true;
                    break;
                case 5:
                    this.transform.position += new Vector3(-velocidad, velocidad, 0);
                    sr.flipX = true;
                    break;
                case 6:
                    this.transform.position += new Vector3(-velocidad, -velocidad, 0);
                    sr.flipX = true;
                    break;
                case 7:
                    this.transform.position += new Vector3(velocidad, velocidad, 0);
                    sr.flipX = false;
                    break;
                case 8:
                    this.transform.position += new Vector3(velocidad, -velocidad, 0);
                    sr.flipX = false;
                    break;
                default:
                    break;
                }
        }

    }

    public void verTiempo()
    {
        if(tiempo>= tiempoMax)
        {
            moviendo = false;
            tiempo = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pared"|| collision.gameObject.tag == "obs")
        {
            moviendo = false;
            tiempo = 0;
            tocando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pared" || collision.gameObject.tag == "obs")
        { 
            tocando = false;
        }
    }
}
       
            

