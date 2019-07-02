using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearMapaAC : MonoBehaviour
{
    private int total;
    private float posx, posy;
    public GameObject pisoPrefab, piedraPrefab;
    public Transform pisoParent, piedraParent;
    // Start is called before the first frame update
    void Start()
    {
        Crear();
    }

    // Update is called once per frame
    void Update()
    {

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
