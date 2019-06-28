using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public GameObject btnLeonn, btnAustin, btnZorem, somLeonn, somAustin, somZorem, jug;
    public int Player=1;
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
        }
        else
        {
            RestablecerValores.idPersonaje2 = 5;
        }
    }
    public void selZorem ()
    {
        somZorem.SetActive(true);
        btnZorem.SetActive(false);
        if (Player == 1)
        {
            RestablecerValores.idPersonaje = 0;
            Player++;
            SR.sprite = jug2;
        }
        else
        {
            RestablecerValores.idPersonaje2 = 0;
        }
    }
    public void selAustin()
    {
        somAustin.SetActive(true);
        btnAustin.SetActive(false);
        if (Player == 1)
        {
            RestablecerValores.idPersonaje = 2;
            Player++;
            SR.sprite = jug2;
        }
        else
        {
            RestablecerValores.idPersonaje2 = 2;
        }
    }
}
