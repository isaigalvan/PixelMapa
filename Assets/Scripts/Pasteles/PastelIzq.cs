using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelIzq : MonoBehaviour
{
    public float posx=-10, posy=2.85f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover();
    }
   
  
    public void mover()
    {
        if (posx <= -2f)
        {
            gameObject.transform.localPosition = new Vector3(posx, posy);
            posx = posx + 0.05f;
        }
        else
        {
            if (posy <= 4.3f)
            {
                posy = posy + 0.05f;
                posx = posx + 0.035f;
                gameObject.transform.localPosition = new Vector3(posx, posy);
            }
            else
            {
                posy = posy + 0.05f;
                gameObject.transform.localPosition = new Vector3(posx, posy);
            }
           
        }
        if (posy >= 7)
        {
            Destroy(gameObject);
        }
    }

   
}
