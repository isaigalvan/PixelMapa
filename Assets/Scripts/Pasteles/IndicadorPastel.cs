using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorPastel : MonoBehaviour
{
    public GameObject indi, indi2, per1, per2;
    public Sprite[] pasteles = new Sprite[4];
    public SpriteRenderer spriteR1, spriteR2;
   
    // Start is called before the first frame update
    void Start()
    {
        spriteR1 = indi.GetComponent<SpriteRenderer>();
        spriteR2 = indi2.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        per1 = GameObject.Find("jugador1");
        per2 = GameObject.Find("jugador2");
        mostrarPastel(per1.GetComponent<PerPastel>().idPastel, spriteR1);
        mostrarPastel(per2.GetComponent<PerPastel>().idPastel, spriteR2);
    }

    public void mostrarPastel(int idPer, SpriteRenderer sr)
    {
        switch (idPer)
        {
            case 1:
                sr.sprite = pasteles[0];
                break;
            case 2:
                sr.sprite = pasteles[1];
                break;
            case 3:
                sr.sprite = pasteles[2];
                break;
            case 4:
                sr.sprite = pasteles[3];
                break;
        }
    }
}
