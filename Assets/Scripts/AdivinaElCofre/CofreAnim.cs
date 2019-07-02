using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreAnim : MonoBehaviour
{
    public GameObject scripts, cofre1,cofre2,cofre3;
    public SpriteRenderer sr1, sr2, sr3;
    public Sprite[] cofres;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cofre1 = GameObject.Find("cofre1");
        cofre2 = GameObject.Find("cofre3");
        cofre3 = GameObject.Find("cofre2");
        sr1 = cofre1.GetComponent<SpriteRenderer>();
        sr2 = cofre2.GetComponent<SpriteRenderer>();
        sr3 = cofre3.GetComponent<SpriteRenderer>();
        AbrirCofres();
    }

    public void AbrirCofres()
    {
        if (GetComponent<ControlTiempo>().seAbrio == true)
        {
            verCofre(cofre1, sr1);
            verCofre(cofre2, sr2);
            verCofre(cofre3, sr3);
        }
    }

    public void verCofre(GameObject cofre, SpriteRenderer sr)
    {
        if (cofre.GetComponent<Caja>().tesoro == true)
        {
            sr.sprite = cofres[1];
        }
        else
        {
            sr.sprite = cofres[0];
        }
    }
}
