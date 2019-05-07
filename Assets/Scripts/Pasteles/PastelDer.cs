using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelDer : MonoBehaviour
{
    public float posx = 10, posy = 2.85f, tiempo;
    public int pasoPastel = 0, idPastel;
    public GameObject per;
    public SpriteRenderer sr;
    public bool estaTocando, actTiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        per = GameObject.FindGameObjectWithTag("Personaje");
        mover();
        estado();
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
    }


    public void mover()
    {
        if (posx >= 2f)
        {
            gameObject.transform.localPosition = new Vector3(posx, posy);
            posx = posx - 0.05f;
        }
        else
        {
            if (posy <= 4.3f)
            {
                posy = posy + 0.05f;
                posx = posx - 0.035f;
                gameObject.transform.localPosition = new Vector3(posx, posy);
            }
            else
            {
                posy = posy + 0.05f;
                gameObject.transform.localPosition = new Vector3(posx, posy);
            }
        }
        if (posy >= 7)
        {
            Destroy(gameObject);
        }
        if (per.GetComponent<PerPastel>().paso == 1 && pasoPastel == 1)
        {
            posx = per.transform.position.x;
            posy = per.transform.position.y;
            gameObject.transform.localPosition = new Vector3(posx + 0.1f, posy - 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Personaje")
        {
            estaTocando = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Personaje")
        {
            estaTocando = false;
        }
    }
    public void estado()
    {

        if (Input.GetKey(KeyCode.Space) && estaTocando == true && per.GetComponent<PerPastel>().paso == 0)
        {
            Debug.Log("ME AGARROOO ACOSO!!");
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f);
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sortingOrder = 5;
            per.GetComponent<PerPastel>().paso = 1;
            per.GetComponent<PerPastel>().idPastelTomado = gameObject.GetComponent<PastelDer>().idPastel;
            pasoPastel = 1;
            actTiempo = true;
        }
        else if (Input.GetKey(KeyCode.Space) && per.GetComponent<PerPastel>().paso == 1 && tiempo >= .5f && pasoPastel == 1)
        {
            per.GetComponent<PerPastel>().actTiempo = true;
            per.GetComponent<PerPastel>().solto = true;
            actTiempo = false;
            tiempo = 0;
            Destroy(gameObject);
        }

    }

}
