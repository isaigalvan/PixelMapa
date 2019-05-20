using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearMapa : MonoBehaviour
{
    // Start is called before the first frame update
    private int total, total2;
    private float posx, posy;
    public GameObject pisoPrefab, paredPrefab;
    public Transform pisoParent, paredParent;
    // Start is called before the first frame update
    void Start()
    {
        crearPiso();
        crearPared();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void crearPiso()
    {
        total = 18;
        posy = -5f; posx = -12f;
        for (int i = 0; i < total; i++)
        {

            GameObject pisoTemp = Instantiate(pisoPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            pisoTemp.name = "" + i + "";
            pisoTemp.transform.parent = pisoParent;
            posx = posx + 5;
            if (i == 5 || i == 11 )
            {
                posy = posy + 5;
                posx = -12;
            }
        }
    }

    public void crearPared()
    {
        total = 30;
        total2 = 12;
        posy = -6.5f; posx = -13.5f;
        for (int i = 0; i < total; i++)
        {

            GameObject paredTemp = Instantiate(paredPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            paredTemp.name = "" + i + "";
            paredTemp.transform.parent = paredParent;
            posx = posx + 2;
            if (i == 14)
            {
                posy = 6.5f;
                posx = -13.5f;
            }
        }
        posy = -4.5f; posx = -13.5f;
        for (int i = 0; i < total2; i++)
        {

            GameObject paredTemp = Instantiate(paredPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            paredTemp.name = "" + i + "";
            paredTemp.transform.parent = paredParent;
            posy = posy + 2;
            if (i == 5)
            {
                posy = -4.5f;
                posx = 14.5f;
            }
        }
    }
}
