using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrearPersonaje : MonoBehaviour
{
    public float posx, posy, posx2, posy2;
    public int idPersonaje,total;
    public GameObject personajePrefab, per,personajeTemp;
    public Transform personajeParent;
    public Sprite[] sprites;
    public GameObject IconoPrefab;
    public Transform IconoParent;
    public List<GameObject> iconos = new List<GameObject>();

    /// <summary>
    /// Update
    /// Se llama una vez por cada frame e invoca el metodo "actualizar"
    /// </summary>
    private void Update()
    {
        actualizar();
    }


    /// <summary>
    /// Start
    /// Este metodo se invoca al ejecutar el programa e invoca a los metodos "crearPer" y "crearIconos"
    /// </summary>
    void Start()
    {
        crearPer();
        crearIconos();
    }


    /// <summary>
    /// Crear
    /// Este metodo es llamado por "crearPer", crea un nuevo objeto el cual sera el personaje a jugar 
    /// se obtiene el valor de la variable "posx" mediante el metodo "obtenerPosx" de la clase estatica RestablecerValores
    /// se llama al metodo "AsignarCoord", se instancia en "personajeTemp" el objeto "personajeParent" con las cordenadas "posx" y "posy"
    /// se manda a llamar el metodo "AsignarNombres", se guardara dentro de la variable "per" el objeto con la etiqueta "PerPref", se manda 
    /// a llamar el metodo "AsignarTamanos" y por ultimo se manda a llamar el metodo "AsignarTexturas"
    /// </summary>
    public void Crear()
    {
            posx = RestablecerValores.obtenerPosx();
            AsignarCoord();
            personajeTemp = Instantiate(personajePrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            personajeTemp.transform.parent = personajeParent;
            AsignarNombres();
            per = GameObject.FindGameObjectWithTag("PerPref");
            per.GetComponent<Personaje>().AsignarTamanos();
            AsignarTexturas();         
        
    }

    /// <summary>
    /// crearPer
    /// Este metodo es invocado por "Start", en caso de que sea la primera vez creandose el personaje, se crea con los valores default de lo contrario
    /// se adquieren los datos si hay datos modificados del personaje y se crea el personaje con esos valores adquiridos.
    /// Si la variable booleana "respawn" de la clase estatica "RestablecerValores" es falso, se invoca el metodo "Crear" y se le otorga
    /// el valor true a la variable "respawn". en caso de que "respawn" sea verdadero se invoca el metodo "Crear" y "asignarDatos"
    /// </summary>
    public void crearPer()
    {
        if ((RestablecerValores.obtenerRespawn()) == false)
        {
            Crear();
            RestablecerValores.ponerRespawn(true);
        }
        else
        {
            Crear();
            asignarDatos();
        }
    }

    /// <summary>
    /// crearIconos
    /// Este metodo es llamado por "Start", crea los objetos los cuales seran los iconos de las habilidades
    /// se inicializa la variable "total" en 3, "posx2" en 2.57 y "posy2" en -1.45, despues se entra a un for comenzando con una variable "i"
    /// hasta que "i" sea menor que total con un incremento de 1, dentro del for se instancia en "iconoTemp" el objeto "iconoPrefab" con las cordenadas
    /// "posx2" y "posy2", se agrega el objeto "iconoTemp" a la lista "iconos" y por ultimo se le asigna a la variable "posx2" el valor "posx2"
    /// + 1.92, despues del for se manda a llamar el metodo "iconosPersonajes"
    /// </summary>
    public void crearIconos()
    {
        total = 3;
        posx2 = 2.57f;
        posy2 = -1.45f;
        for (int i = 0; i < total; i++)
        {

            GameObject iconoTemp = Instantiate(IconoPrefab, new Vector3(posx2, posy2, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            iconos.Add(iconoTemp);
            iconoTemp.transform.parent = IconoParent;
            posx2 = posx2 + 1.92f;
        }
        iconosPersonajes();
    }

    /// <summary>
    /// iconosPersonajes
    /// este metodo es invocado por el metodo "crearIconos", se asignan los inconos de las habilidades en la barra inferior dependiendo del personaje, a partir del valor de la variable 
    /// "idPersonaje" se entra en un switch en donde el caso 0 el "icono 0" se le asigna el sprite numero 0, el "icono 1" se le asigna
    /// el sprite numero 1, el "icono 2" se le asigna el sprite 2, caso 1 el "icono 0" se le asigna el sprite numero 3, el "icono 1"
    /// se le asigna el sprite numero 4, el "icono 2" se le asigna el sprite 5, caso 2 el "icono 0" se le asigna el sprite numero 6,
    /// el "icono 1" se le asigna el sprite numero 7, el "icono 2" se le asigna el sprite 8, caso 3 el "icono 0" se le asigna el sprite 
    /// numero 9, el "icono 1" se le asigna el sprite numero 10, el "icono 2" se le asigna el sprite 11, caso 4 el "icono 0" se le asigna
    /// el sprite numero 12, el "icono 1" se le asigna el sprite numero 13, el "icono 2" se le asigna el sprite 14, caso 5 el "icono 0" 
    /// se le asigna el sprite numero 15, el "icono 1" se le asigna sprite numero 16, el "icono 2" se le asigna el sprite 17
    /// </summary>
    public void iconosPersonajes()
    {
        switch (idPersonaje)
        {
            case 0:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[0]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[1]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[2]);
                break;
            case 1:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[3]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[4]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[5]);
                break;
            case 2:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[6]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[7]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[8]);
                break;
            case 3:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[9]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[10]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[11]);
                break;
            case 4:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[12]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[13]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[14]);
                break;
            case 5:
                iconos[0].GetComponent<Icono>().AsignarTextura(sprites[15]);
                iconos[1].GetComponent<Icono>().AsignarTextura(sprites[16]);
                iconos[2].GetComponent<Icono>().AsignarTextura(sprites[17]);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// AsignarCoord
    /// Este metodo es invocado por "Crear", Asigna la posicion en el eje y del personaje
    /// A partir del valor de la variable "idPersonaje" se entra a un switch donde el caso 0, 4 y 5 la variable "posy" adquiere el valor
    /// de 2.7, en el caso 1 "posy" adquiere el valor de 2.5, en el caso 2 "posy" adquiere el valor de de 2.4, en el caso 3 "posy" adquiere 
    /// el valor de 2.1
    /// </summary>
    public void AsignarCoord()
    {
        switch (idPersonaje)
        {
            case 0:
            case 4:
            case 5:
                posy = 2.7f;
                break;
            case 1:
                posy = 2.5f;
                break;
            case 2:
                posy = 2.4f;
                break;
            case 3:
                posy = 2.1f;
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// AsignaNombres
    /// Este metodo es invocado por "Crear", llama al objeto del personaje dependiendo del personaje que se eligio
    /// A partir del valor de la variable "idPersonaje" se entra a un switch donde en el caso 0 el objeto "personajeTemp" se nombra "Zorem"
    /// caso 1 el objeto "personajeTemp" se nombra "Ian", caso 2 el objeto "personajeTemp" se nombra "Austin", caso 3 el objeto "personajeTemp"
    /// se nombra "Rubi", caso 4 el objeto "personajeTemp" se nombra "Stella", caso 5 el objeto "personajeTemp" se nombra "Leonn"
    /// </summary>
    public void AsignarNombres()
    {
        switch (idPersonaje)
        {
            case 0:
                personajeTemp.name = "Zorem";
                break;
            case 1:
                personajeTemp.name = "Ian";
                break;
            case 2:
                personajeTemp.name = "Austin";
                break;
            case 3:
                personajeTemp.name = "Rubi";
                break;
            case 4:
                personajeTemp.name = "Stella";
                break;
            case 5:
                personajeTemp.name = "Leonn";
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// AsignarTexturas
    /// Este metodo es invocado por "Crear", asigna valores a las variables del animator ya que este es el que controla los sprites y animaciones
    /// A partir del valor de "idPersonaje" se entra a un switch donde en el caso 0 se le asigna el valor 1 a la variable "personaje" del animator
    /// ,caso 1 se le asigna el valor 2 a la variable "personaje" del animator, caso 2 se le asigna el valor 3 a la variable "personaje" del animator
    /// ,caso 3 se le asigna el valor 4 a la variable "personaje" del animator, caso 4 se le asigna el valor 5 a la variable "personaje" del animator
    /// ,caso 5 se le asigna el valor 6 a la variable "personaje" del animator
    /// </summary>
    public void AsignarTexturas()
    {
        switch (idPersonaje)
        {
            case 0:
                per.GetComponent<Animator>().SetFloat("personaje", 1f);
                break;
            case 1:
                per.GetComponent<Animator>().SetFloat("personaje", 2f);
                break;
            case 2:
                per.GetComponent<Animator>().SetFloat("personaje", 3f);
                break;
            case 3:
                per.GetComponent<Animator>().SetFloat("personaje", 4f);
                break;
            case 4:
                per.GetComponent<Animator>().SetFloat("personaje", 5f);
                break;
            case 5:
                per.GetComponent<Animator>().SetFloat("personaje", 6f);
                break;
            default:
                break;
        }      

    }

    public void actualizar()
    {
        if (GetComponent<Dado>().caminando == true)
        {
            RestablecerValores.ponerPosx(posx);  //posx
            RestablecerValores.ponerPosy(posy); //posy 
            RestablecerValores.ponerPH(per.GetComponent<Personaje>().ph); //ph 
            RestablecerValores.ponerCasilla(per.GetComponent<Personaje>().casillaActual); //casillaActual

        }
        else
        {
            if (per.GetComponent<Personaje>().esPintado == true)
            {
                RestablecerValores.estados[0] = true;
            }
            if (per.GetComponent<Personaje>().esBloqueado == true)
            {
                RestablecerValores.estados[1] = true;
            }
            if (per.GetComponent<Personaje>().esInmune == true)
            {
                RestablecerValores.estados[2] = true;
            }
        }
    }

    /// <summary>
    /// asignarDatos
    /// este metodo es invocado por "crearPer", se asignan los datos gurdados del personaje de una clase estatica en caso de que vuelva
    /// a crear la escena, la variable "ph" del script "personaje" se le otorga el valor de "ph" de la clase "RestablecerValores", la 
    /// variable "casillaActual" se le otorga el valor de "obtenerCasilla" de la clase "RestablecerValores"
    /// en caso de que la variable "estado" numero 0 sea igual a true, el objeto "per" en su campo "esPintado" se le asigna el valor de true
    /// en caso de que la variable "estado" numero 1 sea igual a true, el objeto "per" en su campo "esBloqueado" se le asigna el valor de true
    /// en caso de que la variable "estado" numero 0 sea igual a true, el objeto "per" en su campo "esInmune" se le asigna el valor de true
    /// </summary>
    public void asignarDatos()
    {
        per.GetComponent<Personaje>().ph = RestablecerValores.obtenerPH();
        per.GetComponent<Personaje>().casillaActual = RestablecerValores.obtenerCasilla();
        if (RestablecerValores.estados[0] == true)
        {
            per.GetComponent<Personaje>().esPintado = true;
        }
        if (RestablecerValores.estados[1] == true)
        {
            per.GetComponent<Personaje>().esBloqueado = true;
        }
        if (RestablecerValores.estados[2] == true)
        {
            per.GetComponent<Personaje>().esInmune = true;
        }
    }
}