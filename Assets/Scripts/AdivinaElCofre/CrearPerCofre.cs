using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPerCofre : MonoBehaviour
{
    public GameObject perPrefab, per, per2;
    public Transform perParent;
    public int idPersonaje, idPersonaje2;
    public int posx, posy;
    // Start is called before the first frame update
    void Start()
    {
        idPersonaje = RestablecerValores.idPersonaje;
        idPersonaje2 = RestablecerValores.idPersonaje2;
        Crear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Crear()
    {
        GameObject personajeTemp = Instantiate(perPrefab, new Vector3(9,2.2f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp.transform.parent = perParent;
        personajeTemp.name = "jugador1";

        GameObject personajeTemp1 = Instantiate(perPrefab, new Vector3(9,-1.4f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp1.transform.parent = perParent;
        personajeTemp1.name = "jugador2";

        per = GameObject.Find("jugador1");
        per.GetComponent<PerCofre>().numJugador = 1;

        per2 = GameObject.Find("jugador2");
        per2.GetComponent<PerCofre>().numJugador = 2;
        asignarTexturas(per, idPersonaje);
        asignarTexturas(per2, idPersonaje2);
    }

    public void asignarTexturas(GameObject per, int idPer)
    {
        switch (idPer)
        {
            case 0:
                per.GetComponent<Animator>().SetFloat("personaje", 0f);
                break;
            case 2:
                per.GetComponent<Animator>().SetFloat("personaje", 2f);
                break;
            case 5:
                per.GetComponent<Animator>().SetFloat("personaje", 5f);
                break;
            default:
                break;
        }
    }
}
