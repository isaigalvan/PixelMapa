﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PerRobot : MonoBehaviourPun
{
    public SpriteRenderer sr;
    public GameObject pruebaFondo;
    public float velocidadMovimiento = 5;
    public GameObject playerCam;

    void Awake()
    {
        if (photonView.IsMine)
        {
            ///La camara unicamente estara habilitada si es de "nuestra"
            playerCam.SetActive(true);
        }
    }
    
    void Update()
    {
        if (photonView.IsMine)
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            mover();
        }
            
    }

    public void mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(-0.07f, 0, 0);
            
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0.07f, 0, 0);
            
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0, +0.07f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", true);
            this.transform.position += new Vector3(0, -0.07f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            gameObject.GetComponent<Animator>().SetBool("caminando", false);
        }
    }
}
