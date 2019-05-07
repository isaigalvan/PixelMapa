using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorPastel : MonoBehaviour
{
    public GameObject indi;
    public Sprite[] pasteles = new Sprite[4];
    public SpriteRenderer spriteR;
    public float tiempo;
    public bool actTiempo, termino;
    // Start is called before the first frame update
    void Start()
    {
        actTiempo = true;
    }

    // Update is called once per frame
    void Update()
    {
        indi = GameObject.Find("IndicadorPas");
        mostrarPastel();
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        
    }

    public void mostrarPastel()
    {
        if(termino == false)
        {
            if (tiempo >= 2.5f)
            {
                indi.SetActive(false);
                actTiempo = false;
                tiempo = 4;
                termino = true;
            }
            else
            {
                spriteR = indi.GetComponent<SpriteRenderer>();
                if (GetComponent<PerPastel>().idPastel == 1)
                {
                    spriteR.sprite = pasteles[0];
                }
                if (GetComponent<PerPastel>().idPastel == 2)
                {
                    spriteR.sprite = pasteles[1];
                }
                if (GetComponent<PerPastel>().idPastel == 3)
                {
                    spriteR.sprite = pasteles[2];
                }
                if (GetComponent<PerPastel>().idPastel == 4)
                {
                    spriteR.sprite = pasteles[3];
                }
            }
        }
        
    }
}
