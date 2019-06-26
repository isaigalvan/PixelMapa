using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PUNMovimiento : MonoBehaviour
{
    public GameObject playerCam;
    public float velocidad = 100f;

    private void Update()
    {
        checkInput();
    }

    private void checkInput()
    {
        var moviendo = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += moviendo * velocidad * Time.deltaTime;

    }

}
