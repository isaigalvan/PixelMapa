using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelIzq : MonoBehaviour
{
    public float posx=-10, posy=2.85f, tiempo;
    public int pasoPastel = 0, idPastel;
    public GameObject per1, per2, scripts;
    public SpriteRenderer sr;
    public bool estaTocandoP1, estaTocandoP2, actTiempo, tomoJ1, tomoJ2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        per1 = GameObject.Find("jugador1");
        per2 = GameObject.Find("jugador2");
        scripts = GameObject.Find("scripts");
        mover();
        estadoP1(per1); estadoP2(per2);
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
    }
   
  
    public void mover()
    {
        if (pasoPastel == 0)
        {
            if (posx <= -2f)
            {
                gameObject.transform.localPosition = new Vector3(posx, posy);
                posx = posx + 0.05f;
            }
            else
            {
                if (posy <= 4.3f)
                {
                    posy = posy + 0.05f;
                    posx = posx + 0.035f;
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
        }
        pastelVerif(per1);
        pastelVerif(per2);
    }

    public void pastelVerif(GameObject per)
    {
        if (per.GetComponent<PerPastel>().paso == 1 && pasoPastel == 1)
        {
            pastelSiguePer();
            gameObject.transform.localPosition = new Vector3(posx + 0.1f, posy - 0.3f);

        }
    }
    public void pastelSiguePer()
    {
        if (tomoJ1)
        {
            posx = per1.transform.position.x;
            posy = per1.transform.position.y;
        }
        else
        {
            posx = per2.transform.position.x;
            posy = per2.transform.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "jugador1")
        {
            estaTocandoP1 = true;
        }
        if (collision.gameObject.name== "jugador2")
        {
            estaTocandoP2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jugador1")
        {
            estaTocandoP1 = false;
        }
        if (collision.gameObject.name == "jugador2")
        {
            estaTocandoP2 = false;
        }
    }
    public void estadoP1(GameObject perP1)
    {

        if (Input.GetKey(KeyCode.Space) && estaTocandoP1 == true && perP1.GetComponent<PerPastel>().paso == 0 && perP1.GetComponent<PerPastel>().numJugador==1)
        {
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f);
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sortingOrder = 5;
            perP1.GetComponent<PerPastel>().paso = 1;
            perP1.GetComponent<PerPastel>().idPastelTomado = gameObject.GetComponent<PastelIzq>().idPastel;
            pasoPastel = 1;
            actTiempo = true;
            tomoJ1 = true;
            perP1.GetComponent<PerPastel>().tomo = true;
        }

        else if (Input.GetKey(KeyCode.Space) == true)
        {
            if (perP1.GetComponent<PerPastel>().paso == 1 && tiempo >= .5f && pasoPastel == 1 && perP1.GetComponent<PerPastel>().numJugador == 1 && tomoJ1 == true)
            {
                perP1.GetComponent<PerPastel>().actTiempo = true;
                perP1.GetComponent<PerPastel>().solto = true;
                actTiempo = false;
                tiempo = 0;
                Destroy(this.gameObject);
                tomoJ1 = false;
            }
        }
            
    }

    public void estadoP2(GameObject perP2)
    {
        if (Input.GetKey(KeyCode.E) && estaTocandoP2 == true && perP2.GetComponent<PerPastel>().paso == 0 && perP2.GetComponent<PerPastel>().numJugador == 2)
        {
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f);
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sortingOrder = 5;
            perP2.GetComponent<PerPastel>().paso = 1;
            perP2.GetComponent<PerPastel>().idPastelTomado = gameObject.GetComponent<PastelIzq>().idPastel;
            pasoPastel = 1;
            actTiempo = true;
            tomoJ2 = true;
            perP2.GetComponent<PerPastel>().tomo = true;
        }
        else if (Input.GetKey(KeyCode.E) == true)
        {
            if (perP2.GetComponent<PerPastel>().paso == 1 && tiempo >= .5f && pasoPastel == 1 && perP2.GetComponent<PerPastel>().numJugador == 2 && tomoJ2==true)
            {
                perP2.GetComponent<PerPastel>().actTiempo = true;
                perP2.GetComponent<PerPastel>().solto = true;
                actTiempo = false;
                tiempo = 0;
                Destroy(this.gameObject);
                tomoJ2 = false;
            }
        }
    }
}
