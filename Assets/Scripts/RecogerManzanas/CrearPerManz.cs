using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPerManz : MonoBehaviour
{
    public GameObject perPrefab, per, per2;
    public Transform perParent;
    public int idPersonaje, idPersonaje2;
    public int posx, posy;
    public BoxCollider2D box, box2;
    void Start()
    {
      idPersonaje = RestablecerValores.idPersonaje;
      idPersonaje2 = RestablecerValores.idPersonaje2;
        Crear();
    }

    public void Crear()
    {
        GameObject personajeTemp = Instantiate(perPrefab, new Vector3(posx + 3, -3f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp.transform.parent = perParent;
        personajeTemp.name = "jugador1";

        GameObject personajeTemp1 = Instantiate(perPrefab, new Vector3(posx - 3, -3f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        personajeTemp1.transform.parent = perParent;
        personajeTemp1.name = "jugador2";

        per = GameObject.Find("jugador1");
        per.GetComponent<PerManz>().numJugador = 1;
        box = per.GetComponent<BoxCollider2D>();

        per2 = GameObject.Find("jugador2");
        per2.GetComponent<PerManz>().numJugador = 2;
        box2 = per2.GetComponent<BoxCollider2D>();

        asignarTexturas(per,idPersonaje,box);
        asignarTexturas(per2,idPersonaje2,box2);
    }

    public void asignarTexturas(GameObject per, int idPer, BoxCollider2D box)
    {
        switch (idPer)
        {
            case 0:
                per.GetComponent<Animator>().SetFloat("personaje", 0f);
                break;
            case 2:
                per.GetComponent<Animator>().SetFloat("personaje", 2f);
                per.transform.localScale = new Vector3(0.25f, 0.25f);
                box.size = new Vector3(4.487646f, 9.222645f);
                box.offset = new Vector3(-0.6909554f, -0.3500805f);
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
