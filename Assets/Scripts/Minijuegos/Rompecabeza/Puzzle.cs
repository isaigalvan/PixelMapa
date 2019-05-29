using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Puzzle : MonoBehaviour {

    [Tooltip("Se debe tomar una imagen cuadrada, " +
        "dependiendo del numero de fichas se hace la operacion (pixelesImg/numFichas)," +
        "ese es el numero que se debe escribir en Pixel Per Unit en el sprite de la imagen," +
        "cuando recortemos la imagen le indicamos que el pivote sea button left")]
    public List<Sprite> fichaImg=new List<Sprite>();
	public GameObject fichaPrfb, bordePrfb;
	public Sprite fichaEscondidaImg;
	public GameObject textoGanador;

    private GameObject fichaEscondida;
    private int numCostado;
    private GameObject padreFichas;
    private GameObject padreBordes;
    private List<Vector3> posicionesIniciales = new List<Vector3>();
    private GameObject[] _fichas;
    private bool mostrar = false;
    tiempoImg tiempoImg; 

	void Awake()
    {
		padreFichas=GameObject.Find("Fichas");
		padreBordes = GameObject.Find ("Bordes");
        tiempoImg = GameObject.Find("Scripts").GetComponent(typeof(tiempoImg)) as tiempoImg;
    }

    void Start ()
    {
        if (Mathf.Sqrt(fichaImg.Count) == Mathf.Round(Mathf.Sqrt(fichaImg.Count)))
        {
            CrearFichas();
        }

    }

    private void Update()
    {
        if (tiempoImg.tiempoObjeto == -1)
        {
            mostrar = true;
        }
    }

    void CrearFichas(){
		int contador=0;
		numCostado = (int) Mathf.Sqrt (fichaImg.Count);

		for (int alto = numCostado+2; alto >0; alto--)
        {
			for (int ancho = 0; ancho < numCostado+2; ancho++)
            {
				Vector3 posicion = new Vector3 (ancho - (numCostado / 2), alto - (numCostado / 2),0);

				if (alto == 1 || alto == numCostado +2 || ancho == 0 || ancho == numCostado+1)
                { 	
					GameObject borde = Instantiate (bordePrfb, posicion, Quaternion.identity);		 
					borde.transform.parent = padreBordes.transform;									
				}
                else
                {																			
					GameObject ficha = Instantiate (fichaPrfb, posicion, Quaternion.identity);		
					ficha.GetComponent<SpriteRenderer> ().sprite = fichaImg [contador];				
					ficha.transform.parent = padreFichas.transform;
					ficha.name=fichaImg [contador].name;											
					if (ficha.name == fichaEscondidaImg.name)
                    {										
						fichaEscondida  = ficha;													
					}
					contador++;
				}
			}
		}
			
		fichaEscondida.gameObject.SetActive(false);
		_fichas=(GameObject.FindGameObjectsWithTag("Ficha"));
		for (int i = 0; i < _fichas.Length; i++) {
			posicionesIniciales.Add(_fichas [i].transform.position);
		}

        for (int i = 1; 1 < 5; i++)
        {
            Barajar();
        }
	}

	void Barajar()
    {
		int aleatorio;

		for (int i = 0; i < _fichas.Length; i++)
        {
			aleatorio = Random.Range (i, _fichas.Length);								
			Vector3 posTemp = _fichas [i].transform.position;							
			_fichas [i].transform.position = _fichas [aleatorio].transform.position  ;	 
			_fichas [aleatorio].transform.position  = posTemp;																										
		}
	}

    public void ComprobarGanador()
    {
        for (int i = 0; i < _fichas.Length; i++)
        {
            if (posicionesIniciales[i] != _fichas[i].transform.position)
            {
                return;                             
            }
        }

        fichaEscondida.gameObject.SetActive(true); 
        textoGanador.gameObject.SetActive(true);
    }
}
