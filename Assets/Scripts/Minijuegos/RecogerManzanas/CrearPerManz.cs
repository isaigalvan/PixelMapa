using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPerManz : MonoBehaviour
{
    public GameObject perPrefab, per;
    public Transform perParent;
    public int idPersonaje;
    public int posx, posy;
    public BoxCollider2D box;
    void Start()
    {
        idPersonaje = RestablecerValores.idPersonaje;
        Crear();
    }

    public void Crear()
    {
        GameObject personajeTemp = Instantiate(perPrefab, new Vector3(posx, -3.7f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp.transform.parent = perParent;
        per = GameObject.FindGameObjectWithTag("Personaje");
        box = per.GetComponent<BoxCollider2D>();
        // AsignarNombres();
        //AsignarTamanos();
        asignarTexturas();
    }

    public void asignarTexturas()
    {
        switch (idPersonaje)
        {
            case 0:
                per.GetComponent<Animator>().SetFloat("personaje", 0f);
                break;
            case 1:
                per.GetComponent<Animator>().SetFloat("personaje", 1f);
                per.transform.localScale = new Vector3(0.25f, 0.25f);
                box.size = new Vector3(4.487646f, 10.94228f);
                box.offset = new Vector3(-0.6909554f, -0.6937857f);
                break;
            case 2:
                per.GetComponent<Animator>().SetFloat("personaje", 2f);
                per.transform.localScale = new Vector3(0.25f, 0.25f);
                box.size = new Vector3(4.487646f, 9.222645f);
                box.offset = new Vector3(-0.6909554f, -0.3500805f);
                break;
            case 3:
                per.GetComponent<Animator>().SetFloat("personaje", 3f);
                per.transform.localScale = new Vector3(0.25f, 0.25f);
                box.size = new Vector3(4.487646f, 10.77853f);
                box.offset = new Vector3(-0.6909554f, -1.93709f);
                break;
            case 4:
                per.GetComponent<Animator>().SetFloat("personaje", 4f);
                per.transform.localScale = new Vector3(0.23f, 0.23f);
                box.size = new Vector3(4.487646f, 10.77853f);
                box.offset = new Vector3(-0.6909554f, -1.93709f);
                break;
            case 5:
                per.GetComponent<Animator>().SetFloat("personaje", 5f);
                per.transform.localScale = new Vector3(0.23f, 0.23f);
                box.size = new Vector3(4.487646f, 10.77853f);
                box.offset = new Vector3(-0.6909554f, -1.93709f);
                break;
            default:
                break;
        }
    }
}
