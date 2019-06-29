using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaLogo : MonoBehaviour
{

    public float tiempo;
    public GameObject Logo;
    public SpriteRenderer LogoR;
    public Sprite[] LogoSprite;
    public bool direcc;
    public int valor; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        animaLogo();
    }

    public void animaLogo()
    {
        if (tiempo >= 0.25f)
        {
            tiempo = 0;
            if (direcc == false)
            {
                if (valor == 2)
                {
                    direcc = true;
                }
                else
                {
                    valor++;
                }
            }
            else
            {
                if (valor == 0)
                {
                    direcc = false;
                }
                else
                {
                    valor--;
                }
            }
        }
        LogoR = Logo.GetComponent<SpriteRenderer>();
        LogoR.sprite = LogoSprite[valor];
    }
}
