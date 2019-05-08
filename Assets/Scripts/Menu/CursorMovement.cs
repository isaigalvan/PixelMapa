using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {

    public float speed;

    /// <summary>
    /// Esta función se encarga de mover el cursor en todo el espacio donde se encuentra la camará, ademas de que
    /// la velocidad del cursor es asignada desde el inspector 
    /// </summary>
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;

        Vector3 worldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -worldSize.x, worldSize.x),
            Mathf.Clamp(transform.position.y, -worldSize.y, worldSize.y),
            transform.position.z);


    }
}
