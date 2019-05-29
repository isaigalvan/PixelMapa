using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaraMinijuego : MonoBehaviour
{
    public GameObject per;
    public float posx, posy;
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
        gameObject.transform.position = new Vector3(posx, posy,-10);
    }
}
