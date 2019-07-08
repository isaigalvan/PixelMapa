using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seleccion : MonoBehaviour
{
    public GameObject btnLeonn, btnAustin, btnZorem, somLeonn, somAustin, somZorem, jug;
    public int Player=1, j1, j2;
    public SpriteRenderer SR;
    public Sprite jug2;
    // Start is called before the first frame update
    void Start()
    {
        SR = jug.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selLeonn()
    {
        somLeonn.SetActive(true);
        btnLeonn.SetActive(false);
        if (Player == 1)
        {
            RestablecerValores.idPersonaje = 5;
            Player++;
            SR.sprite = jug2;
            j1 = 5;
        }
        else
        {
           
            RestablecerValores.idPersonaje2 = 5;
            SceneManager.LoadScene("01-Mapa");
        }
    }
    public void selZorem ()
    {
        somZorem.SetActive(true);
        btnZorem.SetActive(false);
        if (Player == 1)
        {
            j1 = 0;
            RestablecerValores.idPersonaje = 0;
            Player++;
            SR.sprite = jug2;
        }
        else
        {
            RestablecerValores.idPersonaje2 = 0;
            SceneManager.LoadScene("01-Mapa");
        }
    }
    public void selAustin()
    {
        somAustin.SetActive(true);
        btnAustin.SetActive(false);
        if (Player == 1)
        {
            j1 = 2;
            RestablecerValores.idPersonaje = 2;
            Player++;
            SR.sprite = jug2;
        }
        else
        {
            RestablecerValores.idPersonaje2 = 2;
            SceneManager.LoadScene("01-Mapa");

        }
    }
}
