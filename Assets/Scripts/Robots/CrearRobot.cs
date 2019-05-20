using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearRobot : MonoBehaviour
{
    public bool estaEnJuego;
    public int direc;
    public GameObject robotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Crear();
    }

    public void Crear()
    {
        if (estaEnJuego == false)
        {
            GameObject robotTemp;
            direc = Random.Range(1, 13);
            switch (direc)
            {

                case 1:
                    robotTemp = Instantiate(robotPrefab, new Vector3(-12.5f, -4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 2:
                    robotTemp = Instantiate(robotPrefab, new Vector3(-12.5f, 0, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 3:
                    robotTemp = Instantiate(robotPrefab, new Vector3(-12.5f, 4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 4:
                    robotTemp = Instantiate(robotPrefab, new Vector3(12.5f, 4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 5:
                    robotTemp = Instantiate(robotPrefab, new Vector3(12.5f, 0, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 6:
                    robotTemp = Instantiate(robotPrefab, new Vector3(12.5f, -4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 7:
                    robotTemp = Instantiate(robotPrefab, new Vector3(-8.5f, 5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 8:
                    robotTemp = Instantiate(robotPrefab, new Vector3(0, 5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 9:
                    robotTemp = Instantiate(robotPrefab, new Vector3(8.5f, 5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 10:
                    robotTemp = Instantiate(robotPrefab, new Vector3(8.5f, -4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 11:
                    robotTemp = Instantiate(robotPrefab, new Vector3(0, -4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
                case 12:
                    robotTemp = Instantiate(robotPrefab, new Vector3(-8.5f, -4.5f, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
                    break;
            }
            estaEnJuego = true;
        }
    }
}


               