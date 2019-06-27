using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearGranizo : MonoBehaviour
{
    public float tiempo, posx, posy, segMin=1, segMax=1.2f;
    public bool actTiempo, creo;
    public int total, cont;
    public GameObject granizoPrefab;
    public Transform ListaGranizo;
    public List<GameObject> granizos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        Crear();
    }

    public void Crear()
    {
        total = 5;
        actTiempo = true;
        if (tiempo >= segMin && tiempo <= segMax && creo == false)
        {
            posy = 8;
            posx = Random.Range(-3.1f, 4.8f);
            GameObject GranizoTemp = Instantiate(granizoPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            granizos.Add(GranizoTemp);
            GranizoTemp.name = "Granizo" + cont + "";
            GranizoTemp.transform.parent = ListaGranizo;
            cont ++;
            segMax = segMax + 0.7f;
            segMin = segMin + 0.7f;
            creo = true;    
        }
        if (tiempo <= segMax)
        {
            creo = false;
        }
            

        
    }
}
