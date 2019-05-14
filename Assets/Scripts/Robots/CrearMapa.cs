using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearMapa : MonoBehaviour
{
    // Start is called before the first frame update
    private int total;
    private float posx, posy;
    public GameObject pisoPrefab, ladrilloPrefab;
    public Transform pisoParent, ladrilloParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crearPiso();
    }

    public void crearPiso()
    {
        total = 40;
        posy = -6f; posx = -12f;
        for (int i = 0; i < total; i++)
        {

            GameObject maderaTemp = Instantiate(pisoPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            maderaTemp.name = "" + i + "";
            maderaTemp.transform.parent = pisoParent;
            posx = posx + 3;
            if (i == 7 || i == 15 || i == 23 || i == 31 )
            {
                posy = posy + 3;
                posx = -12;
            }
        }
    }
}
