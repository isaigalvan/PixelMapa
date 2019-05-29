using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandaTrans : MonoBehaviour
{
    public Sprite[] banda;
    public float tiempoBand;
    public int valorAnimBand;
    public SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoBand = Time.deltaTime + tiempoBand;
        animaBand();
    }
    public void animaBand()
    {
       
        if (tiempoBand >= 0.1f)
        {
            tiempoBand = 0;
            if (valorAnimBand == 3)
            { valorAnimBand = 0; }
            else { valorAnimBand++; }
        }
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = banda[valorAnimBand];
    }
}
