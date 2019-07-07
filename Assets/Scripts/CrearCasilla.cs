using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCasilla : MonoBehaviour
{
    public int total, posx, posy;
    public GameObject CasillaPrefab;
    public Transform CasillasParent;
    public List<GameObject> casillas = new List<GameObject>();
    public Sprite[] sprites;
    public GameObject IconoPrefab;
    public Transform IconoParent;
    public  bool condiFor=false, condIf=false;

    /// <summary>
    /// Crear
    /// Se invoca cuando se ejecuta el programa e invoca el metodo "crearCas"
    /// </summary>
    void Start()
    {
        crearCas();
    }

    /// <summary>
    /// Update
    /// Este metodo se invoca una vez cada frame, invoca el metodo "actualizar"
    /// </summary>
    private void Update()
    {
        actualizar();
    }

    /// <summary>
    /// Crear
    /// Este metodo es invocado por "crearCas", crea 200 casillas en forma de una fila asignandole una id a cada una de estas.
    /// Se fija en numero total de casillas guardado en la variable "total", se fija el punto de inicio de asignacion de las id guardado en la variable
    /// "cont" y se fija las posiciones de inicio para imprimir las casillas guardado en las variables "posy" y "posx", dentro de un for que comienza con 
    /// una variable creada llamada "i" con un valor de 0 y termina hasta que "i" sea menor que la variable "total", se le asignara una posicion al 
    /// objeto "casillaTemp" y este se agregara a la lista llamada "casillas", despues a "casillaTemp" se le guardara el valor dela variable "cont" en 
    /// la variable "idCasilla" del script "Casilla", despues la variable "posx" se icrementara por 2 y la variable "cont" se incrementara por 1
    /// al terminar el ciclo for, se invocara el metodo "AsignarTexturas"
    /// 
    /// </summary>
    public void Crear()
    {
        total = 200;
        int cont = 1;
        posy = 1; posx = 5;
        for (int i = 0; i < total; i++)
        {
            
                GameObject casillaTemp = Instantiate(CasillaPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                casillas.Add(casillaTemp);
                casillaTemp.name = ""+i+"";
                casillaTemp.GetComponent<Casilla>().idCasilla = cont;

                casillaTemp.transform.parent = CasillasParent;
                posx = posx + 2;

                cont++;
           
        }
        AsignarTexturas();
    }

    /// <summary>
    /// crearCas
    /// Este metodo es invocado por "Start", en caso de que sea la primera vez creandose el mapa, se crea con los valores default de lo contrario
    /// se adquieren los datos si hay casillas especiales creadas y se crea el mapa con esos valores adquiridos.
    /// Si la variable booleana "respawn" de la clase estatica "RestablecerCasilla" es falso, se invoca el metodo "Crear" y se le otorga
    /// el valor true a la variable "respawn". en caso de que "respawn" sea verdadero se invoca el metodo "Crear" y "asignarDatos"
    /// </summary>
    public void crearCas()
    {
        if ((RestablecerCasilla.obtenerRespawn()) == false)
        {
            Crear();
            
            RestablecerCasilla.ponerRespawn(true);
            
        }
        else
        {
            
            Crear();
            asignarDatos();
        }
    }
    /// <summary>
    /// AsignarRexturas
    /// Este metodo es llamado por "Crear", este metodo asigna un tipo de sprite dependiendo la id de la casilla y modificando variables booleanas indicando que tipo de 
    /// casilla es.
    /// Este metodo se realiza dentro de un for que va desde la variable "i" con valor de 0 hasta que "i" sea menor que el numero total de casillas creadas,
    /// al objeto "i" de la lista "casillas" se le asigna el sprite 0 se la lista, despues de asignarle la textura, se compara el valor de "i" con una lista
    /// de valores estaticos para cuando la casilla es del tipo habilidad, en caso de ser del tipo de habilidad, se le asigna el sprite 1 de la lista a la casilla
    /// con posicion "i" de la lista, y la variable "esHabilidad" del script "Casilla" se le asigna el valor true, en caso de no ser habilidad se repite el proceso para
    /// una lista de valores en caso de ser Negra, Deshabilidad, y minijuego, en caso de ser negra se le asigna el sprite 3 de la lista y se le asigna el valor true a 
    /// la variable "esNegra", en caso de ser Deshabilidad se le asigna el sprite 2 de la lista y se le asigna el valor true a la variable "esDeshabilidad", en caso 
    /// de ser Minijuego se le asigna el sprite 4 de la lista y se le asigna el valor true a la variable "esMinijuego",en caso 
    /// de ser inicio se le asigna el sprite 5 de la lista y se le asigna el valor true a la variable "esInicio", en caso 
    /// de ser final se le asigna el sprite 6 de la lista y se le asigna el valor true a la variable "esFinal" se llama al metodo "AsignarTextura" cada vez
    /// que le asignamos un sprite a la casilla
    /// </summary>
    void AsignarTexturas()
    {
        for (int i = 0; i < casillas.Count; i++)
        {
            
            casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[0]);
            if (i == 1 || i == 5 || i == 10 || i == 13 || i == 25 || i == 26 || i == 33 || i == 46 || i == 47 || i == 51 || i == 53 || i == 64 || i == 69 || i == 71 
                || i == 77 || i == 83 || i == 101 || i == 102 || i == 107 || i == 111 || i == 126 || i == 118 || i == 135 || i == 142 || i == 151 || i == 160 || i == 165
                || i == 177 || i == 184 || i == 185)                                                   //Habilidad
            {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[1]);
                casillas[i].GetComponent<Casilla>().esHabilidad = true;
            }
            if (i == 19 || i == 40 || i == 50 || i == 94 || i == 95 || i == 120 || i == 123 || i == 129 || i == 130 || i == 131 || i == 150 || i == 152 || i == 153
                || i == 167 || i == 168 || i == 169 || i == 175 || i == 179 || i == 189 || i == 190) //Negra
            {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[3]);
                casillas[i].GetComponent<Casilla>().esNegra = true;
            }
            if (i == 8 || i == 18 || i == 20 || i == 30 || i == 41 || i == 60 || i == 62 || i == 74 || i == 86 || i == 96 || i == 110 || i == 121 || i == 132
                || i == 133 || i == 148 || i == 157 || i == 163 || i == 164 || i == 172 || i == 181 || i == 183 || i == 188 || i == 192 || i == 195 || i == 196)                                                //Deshabilidad
            {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[2]);
                casillas[i].GetComponent<Casilla>().esDeshabilidad = true;
            }
            if (i == 9 || i == 17 || i == 21 || i == 29 || i == 35 || i == 36 || i == 49 || i == 61 || i == 63 || i == 70 || i == 80 || i == 89 || i == 90
                || i == 97 || i == 108 || i == 109 || i == 115 || i == 125 || i == 134 || i == 140 || i == 154 || i == 161 || i == 170 || i == 176 || i == 187)                                                 //Minijuego
            {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[4]);
                casillas[i].GetComponent<Casilla>().esMinijuego = true;
                
            }
            if (i == 0) {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[5]);casillas[i].GetComponent<Casilla>().esInicio = true;
            }
            if (i == 199)
            {
                casillas[i].GetComponent<Casilla>().AsignarTextura(sprites[6]); casillas[i].GetComponent<Casilla>().esFinal = true;
            }
        }
    }
    /// <summary>
    /// actualizar
    /// este metodo se invoca en "Update", este metodo actualizara los valores de las casillas modificadas almacenandolas en una clase 
    /// estatica.
    /// Si la variable "caminando" es verdadeda, la variable "condiFor" se le asigna false, "casiModif" de la clase estatica se le asigna
    /// el valor "casiModif" del script habilidades, "hayHab2" de la clase estatica se le asigna el valor "hayHab2Leonn" del script 
    /// habilidades, si la casilla numero "casiModif" es su propiedad "esDesLeonn" es igual a true, "esDes1" de la clase estatica se le
    /// asigna true, si la casilla numero "casiModif" es su propiedad "esDesLeonn2" es igual a true, "esDes2" de la clase estatica se le
    /// asigna true.
    /// si "caminando" es igual a false, "hayPint" de la clase estatica se le asigna el valor "hayPint" del script habilidades>,
    /// "hayPint1" de la clase estatica se le asigna el valor "hayPint1" del script habilidades>, "casRec" de la clase estatica se le 
    /// asigna el valor "casRecorridas" del script habilidades, si "condiFor" es igual a false se entrara a un for de 0 hasta "total"
    /// con incremento 1, y dentro del for si la casilla numero "i", es pintada se llamara el metodo "ponerPintada" de la clase estatica
    /// RestablecerCasilla con un parametro de entrada de valor "i"
    /// </summary>
    public void actualizar()
    {
        if (GetComponent<Dado>().caminando == true)
        {
            condiFor = false;
            RestablecerCasilla.casModif = GetComponent<Habilidades>().casiModif;
            RestablecerCasilla.hayHab2 = GetComponent<Habilidades>().hayHab2Leonn;

            if (casillas[RestablecerCasilla.casModif].GetComponent<Casilla>().esDesLeonn)
            {
                RestablecerCasilla.esDes1 = true;
            }
            if (casillas[RestablecerCasilla.casModif].GetComponent<Casilla>().esDesLeonn2)
            {
                RestablecerCasilla.esDes2 = true;
            }


        }
        else
        {
            RestablecerCasilla.hayPint = GetComponent<Habilidades>().hayPint;
            RestablecerCasilla.hayPint1 = GetComponent<Habilidades>().hayPint1;
            RestablecerCasilla.casRec = GetComponent<Habilidades>().casRecorridas;
            if (condiFor == false)
            {
                for (int i = 0; i < total; i++)
                {
                    if (casillas[i].GetComponent<Casilla>().esPintada == true)
                    {                      
                        RestablecerCasilla.ponerPintada(i);
                    }
                }
                condiFor = true;
               
            }

        }
    }
    /// <summary>
    /// asignaDatos
    /// Este metodo es llamado por "crearCas",en caso de haber cambiado de escena se restableceran los valores de las casillas
    /// que fueron cambiadas a partir de adquirir los valores guardados de una clase estatica.
    /// la variable "hayHab2Leonn" del script habilidades guarda el valor de "hayHab2" de la clase estatica "RestablecerCasilla"
    /// la variable "casiModif" del script habilidades guarda el valor de "casModif" de la clase estatica "RestablecerCasilla"
    /// la variable "hayPint" del script habilidades guarda el valor de "hayPint" de la clase estatica "RestablecerCasilla"
    /// la variable "hayPint1" del script habilidades guarda el valor de "hayPint1" de la clase estatica "RestablecerCasilla"
    /// la variable "casRecorridas" del script habilidades guarda el valor de "casRecorridas" de la clase estatica "RestablecerCasilla"
    /// Si "HayHab2Leonn" y la variable "esDes1" de la clase estatica "RestablecerCasilla" son verdaderas, la casilla numero "CasiModif"
    /// en su propiedad "esDesLeonn" se le asignara true y despues se llamara al metodo "desLeonn" con el valor de entrada de "casiModif"
    /// Si "HayHab2Leonn" y la variable "esDes2" de la clase estatica "RestablecerCasilla" son verdaderas, la casilla numero "CasiModif"
    /// en su propiedad "esDesLeonn2" se le asignara true y despues se llamara al metodo "desLeonn" con el valor de entrada de "casiModif"
    /// Si la variable "hayPint" es verdadera se entrara a un for de 0 hasta "contPint" con incremento de 1, dentro del for la casilla
    /// numero "pintadas[i]" en su propiedad "esPintada" se asignara true, terminando el for se llamara el metodo "inicializasPint"
    /// Si la variable "hayPint1" es verdadera se entrara a un for de 0 hasta "contPint" con incremento de 1, dentro del for la casilla
    /// numero "pintadas[i]" en su propiedad "esPintada" se asignara true, si "condIf" es falso "casiModif" se le asignara el valor de
    /// "pintadas[i]" y "condiIf" sera true, de lo contrario "casiModif2" se le asignara el valor de "pintadas[i]" terminando el for se llamara el metodo "inicializasPint" y "condIf"
    /// se le asignara false
    /// </summary>
    public void asignarDatos()
    {
        GetComponent<Habilidades>().hayHab2Leonn = RestablecerCasilla.hayHab2;
        GetComponent<Habilidades>().casiModif = RestablecerCasilla.casModif;
        GetComponent<Habilidades>().hayPint = RestablecerCasilla.hayPint;
        GetComponent<Habilidades>().hayPint1 = RestablecerCasilla.hayPint1;
        GetComponent<Habilidades>().casRecorridas = RestablecerCasilla.casRec;

        if (GetComponent<Habilidades>().hayHab2Leonn && RestablecerCasilla.esDes1 == true)
        {
            casillas[GetComponent<Habilidades>().casiModif].GetComponent<Casilla>().esDesLeonn = true;
            GetComponent<IndicadoresCasilla>().desLeonn(GetComponent<Habilidades>().casiModif);
        }
        if (GetComponent<Habilidades>().hayHab2Leonn && RestablecerCasilla.esDes2 == true)
        {
            casillas[GetComponent<Habilidades>().casiModif].GetComponent<Casilla>().esDesLeonn2 = true;
            GetComponent<IndicadoresCasilla>().desLeonn(GetComponent<Habilidades>().casiModif);
        }
        if (GetComponent<Habilidades>().hayPint==true)
        {
            for(int i =0; i<= RestablecerCasilla.contPint-1; i++)
            {
                casillas[RestablecerCasilla.pintadas[i]].GetComponent<Casilla>().esPintada = true;
            }
            RestablecerCasilla.inicializarPint();
        }
        if(GetComponent<Habilidades>().hayPint1 == true)
        {
            for (int i = 0; i <= RestablecerCasilla.contPint - 1; i++)
            {
                casillas[RestablecerCasilla.pintadas[i]].GetComponent<Casilla>().esPintada = true;
                if (condIf == false) { GetComponent<Habilidades>().casiModif1 = RestablecerCasilla.pintadas[i];condIf = true; } else { GetComponent<Habilidades>().casiModif2 = RestablecerCasilla.pintadas[i]; }
               
            }
            condIf = false;
            RestablecerCasilla.inicializarPint();
        }
    }
}
