using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerManz : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        sr= gameObject.GetComponent<SpriteRenderer>();
    }

    public void mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            sr.flipX = true;
            this.transform.position += new Vector3(-0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            sr.flipX = false;
            this.transform.position += new Vector3(0.07f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
        }
    }
}
