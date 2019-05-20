using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaFondo : MonoBehaviour
{
    public float posx, posy, mov, posx2, posy2;
    public GameObject per;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        per = GameObject.FindGameObjectWithTag("Personaje");
        posx = per.transform.position.x;
        posy = per.transform.position.y;
        mover();
    }

    public void mover()
    {
        gameObject.transform.position = new Vector3((posx*mov) + posx2, (posy* mov) + posy2, 0);
    }
}
