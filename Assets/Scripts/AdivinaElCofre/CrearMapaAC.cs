using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearMapaAC : MonoBehaviour
{
    public int total, cofre;
    private float posx, posy;
    public GameObject pisoPrefab, piedraPrefab, cofre1, cofre2, cofre3;
    public Transform pisoParent, piedraParent;
    // Start is called before the first frame update
    void Start()
    {
        Crear();
        cofre = Random.Range(1, 4);
        cofre1 = GameObject.Find("cofre1");
        cofre2 = GameObject.Find("cofre3");
        cofre3 = GameObject.Find("cofre2");
        
    }

    // Update is called once per frame
    void Update()
    {
        asigTesoro();
    }

    public void asigTesoro()
    {
        if( cofre == cofre1.GetComponent<Caja>().idCaja)
        {
            cofre1.GetComponent<Caja>().tesoro = true;
        }
        if (cofre == cofre2.GetComponent<Caja>().idCaja)
        {
            cofre2.GetComponent<Caja>().tesoro = true;
        }
        if (cofre == cofre3.GetComponent<Caja>().idCaja)
        {
            cofre3.GetComponent<Caja>().tesoro = true;
        }
    }
    public void Crear()
    {
        crearMadera();
    }

    public void crearMadera()
    {
        total = 190;
        posy = -5.5f; posx = -11f;
        for (int i = 0; i < total; i++)
        {

            GameObject maderaTemp = Instantiate(pisoPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            maderaTemp.name = "" + i + "";
            maderaTemp.transform.parent = pisoParent;
            posx = posx + 1.2f;
            if (i == 18 || i == 37 || i == 56 || i == 75 || i == 94 || i == 113 || i == 132 || i == 151 || i == 170 || i == 189)
            {
                posy = posy + 1.2f;
                posx = -11;
            }
        }
    }
}
