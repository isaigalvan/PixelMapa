using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonesAyuda : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MantaInicio, MantaCasillas, MantaMinijuegos, MantaPersonajes;
    public int pagMinijuegos, pagPersonajes;
    public bool esPersonajes, esMinijuegos;

    public Sprite[] personaje;
    public Sprite[] icono;
    public SpriteRenderer icono1, icono2, icono3, per;
    public GameObject tamañoPer;
    public TextMeshProUGUI nombre, desc1, desc2, desc3;

    public TextMeshProUGUI nombreM, desc, saltarSeleccion;
    public Sprite[] iconoMini;
    public GameObject controlSeleccion, nombreSelecion, controlesG, cursor, arriba, space;
    public SpriteRenderer iconoMinijuego;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (esPersonajes) { paginasPersonajes(); }
        if (esMinijuegos) { paginasMinijuegos(); }
    }

    public void abrirCasillas()
    {
        MantaCasillas.SetActive(true);
        MantaInicio.SetActive(false);
        MantaMinijuegos.SetActive(false);
        MantaPersonajes.SetActive(false);
        esPersonajes = false;
        esMinijuegos = false;
    }

    public void abrirMinijuegos()
    {
        pagMinijuegos = 0;
        MantaMinijuegos.SetActive(true);
        MantaInicio.SetActive(false);
        MantaCasillas.SetActive(false);
        MantaPersonajes.SetActive(false);
        esPersonajes = false;
        esMinijuegos = true;
    }

    public void abrirPersonajes()
    {
        pagPersonajes = 0;
        MantaPersonajes.SetActive(true);
        MantaInicio.SetActive(false);
        MantaMinijuegos.SetActive(false);
        MantaCasillas.SetActive(false);
        esPersonajes = true;
        esMinijuegos = false;
    }

    public void aumentarPagPersonajes()
    {
        if (pagPersonajes == 2)
        {
            pagPersonajes = 0;
        }
        else
        {
            pagPersonajes++;
        }
    }
    public void reducirPagPersonajes()
    {
        if (pagPersonajes == 0)
        {
            pagPersonajes = 2;
        }
        else
        {
            pagPersonajes--;
        }
    }

    public void aumentarPagMinijuegos()
    {
        if (pagMinijuegos == 6)
        {
            pagMinijuegos = 0;
        }
        else
        {
            pagMinijuegos++;
        }
    }
    public void reducirPagMinijuegos()
    {
        if (pagMinijuegos == 0)
        {
            pagMinijuegos = 6;
        }
        else
        {
            pagMinijuegos--;
        }
    }

    //0.7 zorem, 0.3 leonn austin
    public void paginasPersonajes()
    {
        switch (pagPersonajes)
        {
            case 0:
                tamañoPer.transform.localScale = new Vector3(0.7f, 0.7f);
                nombre.text = "zorem";
                per.sprite = personaje[0];
                icono1.sprite = icono[0];
                icono2.sprite = icono[1];
                icono3.sprite = icono[2];
                desc1.text = "Se teletransporta 3 casillas adelante ";
                desc2.text = "El siguiente tiro del oponente sera maximo 3 puntos";
                desc3.text = "Potencia su dado haciendo que pueda obtener un maximo de 12 puntos";
                break;
            case 1:
                tamañoPer.transform.localScale = new Vector3(0.3f, 0.3f);
                nombre.text = "austin";
                per.sprite = personaje[1];
                icono1.sprite = icono[3];
                icono2.sprite = icono[4];
                icono3.sprite = icono[5];
                desc1.text = "Pinta 2 casillas cerca de el";
                desc2.text = "Pinta al contrincante (los jugadores pintados no podran lanzar habilidades)";
                desc3.text = "Pinta todas las casillas por las que el pase en su siguiente tiro";
                break;
            case 2:
                tamañoPer.transform.localScale = new Vector3(0.3f, 0.3f);
                nombre.text = "leonn";
                per.sprite = personaje[2];
                icono1.sprite = icono[6];
                icono2.sprite = icono[7];
                icono3.sprite = icono[8];
                desc1.text = "Se cubre con sus hojas, si alguien pasa sobre el, quedara bloqueado";
                desc2.text = "Planta una semilla, si caen en esa casilla leonn robara 1PH";
                desc3.text = "Potencia su dado, tira 2 veces";
                break;
        }
    }

    public void paginasMinijuegos()
    {
        switch (pagMinijuegos)
        {
            case 0:
                nombreM.text = "Adivina el cofre";
                desc.text = "Camina hacia los cofres y adivina cual es el que tiene el tesoro ";
                iconoMinijuego.sprite = iconoMini[0];
                cursor.SetActive(false);
                controlesG.SetActive(true);
                controlSeleccion.SetActive(true);
                arriba.SetActive(false);
                break;
            case 1:
                nombreM.text = "Dardos";
                desc.text = "Toma el dardo y revienta el mayor numero de globos posibles";
                iconoMinijuego.sprite = iconoMini[1];
                controlesG.SetActive(false);
                cursor.SetActive(true);
                controlSeleccion.SetActive(false);
                arriba.SetActive(false);
                space.SetActive(true);
                saltarSeleccion.text = "Seleccion";
                break;
            case 2:
                nombreM.text = "Infla el globo";
                desc.text = "Se el primero que reviente el globo";
                iconoMinijuego.sprite = iconoMini[2];
                cursor.SetActive(false);
                controlesG.SetActive(false);
                controlSeleccion.SetActive(true);
                space.SetActive(false);
                arriba.SetActive(true);
                saltarSeleccion.text = "Inflar";
                break;
            case 3:
                nombreM.text = "Atrapa Manzanas";
                desc.text = "Atrapa la mayor cantidad de manzanas antes que caigan al suelo";
                iconoMinijuego.sprite = iconoMini[3];
                controlesG.SetActive(true);
                controlSeleccion.SetActive(true);
                cursor.SetActive(false);
                arriba.SetActive(false);
                space.SetActive(true);
                saltarSeleccion.text = "Saltar";
                break;
            case 4:
                nombreM.text = "Memorama";
                desc.text = "Encuentra la mayor cantidad de pares en el memorama";
                iconoMinijuego.sprite = iconoMini[4];
                cursor.SetActive(true);
                controlesG.SetActive(false);
                controlSeleccion.SetActive(false);
                saltarSeleccion.text = "Seleccion";
                break;
            case 5:
                nombreM.text = "Ordena pasteles";
                desc.text = "Toma y guarda el pastel que te toco en su respectiva caja";
                iconoMinijuego.sprite = iconoMini[5];
                controlesG.SetActive(true);
                controlSeleccion.SetActive(true);
                cursor.SetActive(false);
                break;
            case 6:
                nombreM.text = "Atrapa el robot";
                desc.text = "Camina por la arena y atrapa los robots";
                iconoMinijuego.sprite = iconoMini[6];
                controlesG.SetActive(true);
                controlSeleccion.SetActive(false);
                break;
        }
    }
}
