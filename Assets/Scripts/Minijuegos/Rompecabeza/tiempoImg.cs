using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoImg : MonoBehaviour
{
    public float tiempoObjeto;
    public GameObject objetoPrefab;
    public Sprite objetoImg;

    private GameObject objetoOculto;
    private GameObject padreObjeto;

    private void Awake()
    {
        padreObjeto = GameObject.Find("Objeto");
    }

    private void Start()
    {
        GameObject objeto = Instantiate(objetoPrefab, new Vector3(1.5f, 2.5f, -1), Quaternion.identity);
        objeto.GetComponent<SpriteRenderer>().sprite = objetoImg;
        objeto.transform.parent = padreObjeto.transform;
        objeto.name = objetoImg.name;

        if(objeto.name == objetoImg.name)
        {
            objetoOculto = objeto;
        }
    }

    private void Update()
    {
        if (tiempoObjeto <= 0.0f)
        {
            tiempoObjeto = -1;
            objetoOculto.SetActive(false);
        }
        else
        {
            tiempoObjeto -= UnityEngine.Time.deltaTime;
        }
    }
}
