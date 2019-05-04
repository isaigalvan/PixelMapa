using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPerPastel : MonoBehaviour
{
    public GameObject perPrefab;
    public Transform perParent;
    public int idPersonaje;
    public int posx, posy;
    // Start is called before the first frame update
    void Start()
    {
        Crear();
    }


    public void Crear()
    {
        GameObject personajeTemp = Instantiate(perPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp.transform.parent = perParent;
        // AsignarNombres();
        //AsignarTamanos();
        asignarTexturas();
    }

    public void asignarTexturas()
    {
        switch (idPersonaje)
        {
            case 0:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 0f);
                break;
            case 1:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 1f);
                break;
            case 2:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 2f);
                break;
            case 3:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 3f);
                break;
            case 4:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 4f);
                break;
            case 5:
                perPrefab.GetComponent<Animator>().SetFloat("personaje", 5f);
                break;
            default:
                break;
        }
    }
}
