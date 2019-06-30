using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidades : MonoBehaviour
{
    public GameObject scripts, jugador1, jugador2, per;
    public float tiempo, px,py;
    public bool actTiempo = false;
    public bool esHab1 = false, esHab2 = false, esHab3 = false, usoHab = false;
    //zorem
    public bool verCasiHab1Zor = false, condiZor1 = false;
    //Ian
    //Austin
    public GameObject btnCasillas;
    public List<GameObject> botones = new List<GameObject>();
    private int casillaAPintar, dif, verifCasilla, dif1, dif2;
    public int casiModif1, casiModif2;
    public float casRecorridas;
    private bool condiHab1Au, presionado1, presionado2, condiHab1Aus;
    public bool hayPint, hayPint1;
    //Rubi
    //Stella
    //Leonn
    public bool repite = false;
    public bool hayHab2Leonn;
    public int casiModif;
    public GameObject tronco;
    //
    void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        jugador1 = GameObject.Find("jugador1");
        jugador2 = GameObject.Find("jugador2");
        scripts = GameObject.Find("Scripts");
        tronco = GameObject.FindGameObjectWithTag("tronco");
        terminarHabilidades(per);

        if (GetComponent<Dado>().jugador == 1)
        {
            per = jugador1;
            px = GetComponent<CrearPersonaje>().posx;
            py = GetComponent<CrearPersonaje>().posy;
        }
        else
        {
            per = jugador2;
            px = GetComponent<CrearPersonaje>().posxP2;
            py = GetComponent<CrearPersonaje>().posyP2;
        }
    }

    public void habilidad1()
    {

        esHab1 = true;
        switch (per.GetComponent<Personaje>().idPer)
        {
            case 0:
                hab1zorem(per);
                break;
            case 1:

                break;
            case 2:
                hab1austin(per);
                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 1;
       // per.GetComponent<Personaje>().imprimePh();
        usoHab = true;
    }
    public void habilidad2()
    {
        esHab2 = true;
        switch (per.GetComponent<Personaje>().idPer)
        {
            case 0:
                //hab2zorem();
                break;
            case 2:

                break;
            case 5:
                hab2leonn(per);
                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 2;
        //per.GetComponent<Personaje>().imprimePh();
        usoHab = true;
    }
    public void habilidad3()
    {
        esHab3 = true;
        switch (per.GetComponent<Personaje>().idPer)
        {
            case 0:
                hab3zorem(per);
                break;
            case 2:

                break;
            case 5:
                hab3leonn(per);
                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 3;
        //per.GetComponent<Personaje>().imprimePh(per);
        usoHab = true;
    }

    //---------------------------------------------ZOREM---------------------------------------------
    public void hab1zorem(GameObject perZ1)
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        perZ1.GetComponent<Animator>().SetBool("hab1", true);
    }
    public void terhab1zor(GameObject perZ1f)
    {
        if (tiempo >= 1.8f && condiZor1 == false)
        {
            float newposx;
            newposx = perZ1f.GetComponent<Personaje>().transform.position.x + 6;
            if (GetComponent<Dado>().jugador == 1) { GetComponent<CrearPersonaje>().posx = newposx; } else { GetComponent<CrearPersonaje>().posxP2 = newposx; }
            perZ1f.transform.localPosition = new Vector3(newposx, perZ1f.GetComponent<Personaje>().transform.position.y);
            condiZor1 = true;
        }
        if (tiempo >= 2.5f)
        {

                GetComponent<Dado>().btnHab1.SetActive(false);
                
        }
        if (tiempo >= 3.5f)
        {
          
            perZ1f.GetComponent<Personaje>().casillaActual = perZ1f.GetComponent<Personaje>().casillaActual + 3;
            perZ1f.GetComponent<Animator>().SetBool("hab1", false);
            //per.GetComponent<Personaje>().imprimeCasilla();
            verCasiHab1Zor = true;
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            esHab1 = false;
            condiZor1 = false;
        }
    }
    //---------------------hab3 Zorem---------------------
    public void hab3zorem(GameObject perZ3)
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        perZ3.GetComponent<Animator>().SetBool("hab3", true);
        perZ3.GetComponent<Personaje>().esBuff = true;
        GetComponent<Dado>().buff = true;
    }
    public void terhab3zor(GameObject perZ3f)
    {
        if (tiempo >= 3.5f)
        {
            scripts.GetComponent<Dado>().valorMax = 12;
            perZ3f.GetComponent<Animator>().SetBool("hab3", false);
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            esHab3 = false;
        }
    }
    //----------------------------------------AUSTIN-----------------------------------------------------------------
    //---------------------hab1 Austin---------------------
    public void hab1austin(GameObject perA1)
    {
        btnCasillas.SetActive(true);
        GetComponent<Dado>().esTurno = false;
        perA1.GetComponent<Animator>().SetBool("hab1", true);
        perA1.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
        verifBotones(perA1);
    }

    public void verifBotones(GameObject perA1)
    {
        if (perA1.GetComponent<Personaje>().casillaActual <= 4)
        {
            dif = 6 - perA1.GetComponent<Personaje>().casillaActual;
            for (int i = 0; i <= dif - 1; i++)
            {
                botones[i].SetActive(false);
            }
        }
        if (perA1.GetComponent<Personaje>().casillaActual >= 194)
        {
            dif = perA1.GetComponent<Personaje>().casillaActual - 194;
            dif = 9 - dif;
            for (int i = 9; i >= dif; i--)
            {
                botones[i].SetActive(false);
            }
        }
        if (perA1.GetComponent<Personaje>().casillaActual <= 5) { dif1 = 5 - perA1.GetComponent<Personaje>().casillaActual; } else { dif1 = 0; }

        for (int x = dif1; x <= 4; x++)
        {
            verifCasilla = perA1.GetComponent<Personaje>().casillaActual - (5 - x);
            if (GetComponent<CrearCasilla>().casillas[verifCasilla].GetComponent<Casilla>().esOcupada == true)
            {
                botones[x].SetActive(false);
            }
        }
        if (perA1.GetComponent<Personaje>().casillaActual >= 195) { dif2 = perA1.GetComponent<Personaje>().casillaActual - 190; } else { dif2 = 9; }

        for (int x = dif2; x >= 5; x--)
        {
            verifCasilla = perA1.GetComponent<Personaje>().casillaActual + (x - 4);
            if (GetComponent<CrearCasilla>().casillas[verifCasilla].GetComponent<Casilla>().esOcupada == true)
            {
                botones[x].SetActive(false);
            }
        }
    }
    public void terhab1austin(GameObject perA1f)
    {
        if (presionado1 == true && condiHab1Aus == false)
        {
            btnCasillas.SetActive(false);
            perA1f.GetComponent<Animator>().SetFloat("lanzoPintura", 1);
            actTiempo = true;
            if (tiempo >= 2)
            {
                GetComponent<CrearCasilla>().casillas[casillaAPintar].GetComponent<Casilla>().esPintada = true;
                perA1f.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
                condiHab1Aus = true;
                btnCasillas.SetActive(true);
                actTiempo = false;
                tiempo = 0;
            }

        }
        if (presionado1 == true && presionado2 == true)
        {
            btnCasillas.SetActive(false);
            perA1f.GetComponent<Animator>().SetFloat("lanzoPintura", 1);
            actTiempo = true;
            if (tiempo >= 2)
            {
                GetComponent<CrearCasilla>().casillas[casillaAPintar].GetComponent<Casilla>().esPintada = true;
                perA1f.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
            }
            if (tiempo >= 3) { actTiempo = false; tiempo = 0; presionado1 = false; presionado2 = false; condiHab1Aus = false;
                GetComponent<Dado>().esTurno = true; perA1f.GetComponent<Animator>().SetBool("hab1", false);
            }
        }
        if (GetComponent<Dado>().caminando == true)
        {
            esHab1 = false;
            hayPint1 = true;
        }
    }
    public void presiono()
    {
        if (presionado1 == false) { presionado1 = true; casiModif1 = casillaAPintar; } else { presionado2 = true; casiModif2 = casillaAPintar; }
    }

    public void pres1()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 5;
        presiono();
    }
    public void pres2()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 4;
        presiono();
    }
    public void pres3()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 3;
        presiono();
    }
    public void pres4()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 2;
        presiono();
    }
    public void pres5()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 1;
        presiono();
    }
    public void pres6()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual + 1;
        presiono();
    }
    public void pres7()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual + 2;
        presiono();
    }
    public void pres8()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual + 3;
        presiono();
    }
    public void pres9()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual + 4;
        presiono();
    }
    public void pres10()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual + 5;
        presiono();
    }

    //---------------------hab3 Austin---------------------
    public void terhab3austin(GameObject perA3f)
    {

        if (GetComponent<Dado>().caminando == false && GetComponent<Dado>().esTurno == false)
        {
            casRecorridas = GetComponent<Dado>().destino;
            for (int i = 0; i <= casRecorridas; i++)
            {
                GetComponent<CrearCasilla>().casillas[perA3f.GetComponent<Personaje>().casillaActual - i].GetComponent<Casilla>().esPintada = true;
                hayPint = true;
                if (GetComponent<Dado>().caminando == false)
                {
                    esHab3 = false;
                }
            }
        }
    }
    //  -----------------------------------------LEONN--------------------------------------------------------
    // --------------------------------HAB 2 LEONN --------------------------------
    public void hab2leonn(GameObject perL1)
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        perL1.GetComponent<Animator>().SetBool("hab2", true);
    }
    public void terhab2leonn(GameObject perL1f)
    {
        if (tiempo >= 2f)
        {
            perL1f.GetComponent<Animator>().SetBool("hab2", false);
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            if (GetComponent<CrearCasilla>().casillas[perL1f.GetComponent<Personaje>().casillaActual].GetComponent<Casilla>().esDeshabilidad == true)
            {
                GetComponent<CrearCasilla>().casillas[perL1f.GetComponent<Personaje>().casillaActual].GetComponent<Casilla>().esDesLeonn2 = true;
                casiModif = perL1f.GetComponent<Personaje>().casillaActual;
            }
            else
            {
                casiModif = perL1f.GetComponent<Personaje>().casillaActual;
                GetComponent<CrearCasilla>().casillas[casiModif].GetComponent<Casilla>().esDesLeonn = true;
            }
            GetComponent<IndicadoresCasilla>().desLeonn(casiModif);
        }
        if (GetComponent<Dado>().caminando == true)
        {
            esHab2 = false;
            hayHab2Leonn = true;
        }
    }
    // --------------------------------HAB 3 LEONN --------------------------------
    public void hab3leonn(GameObject perL3)
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        perL3.GetComponent<Animator>().SetBool("hab3", true);
        perL3.GetComponent<Personaje>().esBuff = true;
        repite = true;
        GetComponent<Dado>().buff = true;
    }
    public void terhab3leonn(GameObject perL3f)
    {
        
        if (tiempo >= 3.5f)
        {
            perL3f.GetComponent<Animator>().SetBool("hab3", false);
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            
        }
    }
    //------------------------------------------------------------------------------------------------------------
    public void terminarHabilidades(GameObject jugador)
    {
        if (esHab1 == true)
        {
           
            switch (jugador.GetComponent<Personaje>().idPer)
            {
                case 0:
                    terhab1zor(jugador);
                    break;
                case 2:
                    terhab1austin(jugador);
                    break;
                case 5:

                    break;
                default:
                    break;
            }
        }
        if (esHab2 == true)
        {
            
            switch (jugador.GetComponent<Personaje>().idPer)
            {
                case 0:
                    //terhab2zor();
                    break;
                case 2:
                   
                    break;
                case 5:
                    terhab2leonn(jugador);
                    break;
                default:
                    break;
            }

        }
        if (esHab3 == true)
        {
           
            switch (jugador.GetComponent<Personaje>().idPer)
            {
                case 0:
                    terhab3zor(jugador);
                    break;
                case 2:
                    terhab3austin(jugador);
                    break;
                case 5:
                    terhab3leonn(jugador);
                    break;
                default:
                    break;
            }
        }
      /*  if(hayPint==true&& GetComponent<Dado>().esTurno == true)
        {
            for (int i = 0; i <= casRecorridas; i++)
            {
                GetComponent<CrearCasilla>().casillas[per.GetComponent<Personaje>().casillaActual - i].GetComponent<Casilla>().esPintada = false;
            }
            hayPint = false;
            RestablecerCasilla.inicializarPint();
        }
        if (hayHab2Leonn == true && GetComponent<Dado>().esTurno == true)
        {
            GetComponent<CrearCasilla>().casillas[casiModif].GetComponent<Casilla>().esDesLeonn = false;
            GetComponent<CrearCasilla>().casillas[casiModif].GetComponent<Casilla>().esDesLeonn2 = false;
            hayHab2Leonn = false;
            Destroy(tronco);
        }
        if(hayPint1 == true && GetComponent<Dado>().esTurno == true)
        {
            GetComponent<CrearCasilla>().casillas[casiModif1].GetComponent<Casilla>().esPintada = false;
            GetComponent<CrearCasilla>().casillas[casiModif2].GetComponent<Casilla>().esPintada = false;
            hayPint1 = false;
            
        }*/
    }
}
