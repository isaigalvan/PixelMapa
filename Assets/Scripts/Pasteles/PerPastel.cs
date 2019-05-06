using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerPastel : MonoBehaviour
{
    public int paso=0;
    public float tiempo;
    public bool actTiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        soltar();
       if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
    }

    public void mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando",true);
            this.transform.position += new Vector3(-0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0, +0.07f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0,-0.07f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)==false&& Input.GetKey(KeyCode.RightArrow) == false&& Input.GetKey(KeyCode.UpArrow) == false&&Input.GetKey(KeyCode.DownArrow) == false)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
        }
    }

    public void soltar()
    {
        if (tiempo >= 0.5f)
        {
            paso = 0;
            actTiempo = false;
            tiempo = 0;
        }
    }
}
