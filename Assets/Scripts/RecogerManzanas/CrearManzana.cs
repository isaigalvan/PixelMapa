using System.Collections.Generic;
using UnityEngine;

public class CrearManzana : MonoBehaviour
{
    public float tiempo, posx, posy, segMin = 1, segMax = 1.2f;
    public bool actTiempo, creo;
    public int total, cont;
    public GameObject manzanaPrefab;
    public Transform ListaManzana;
    public List<GameObject> manzanas = new List<GameObject>();
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
            posx = Random.Range(-8.8f, 8.8f);
            GameObject ManzanaTemp = Instantiate(manzanaPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            manzanas.Add(ManzanaTemp);
            ManzanaTemp.name = "Manzana" + cont + "";
            ManzanaTemp.transform.parent = ListaManzana;
            cont++;
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
