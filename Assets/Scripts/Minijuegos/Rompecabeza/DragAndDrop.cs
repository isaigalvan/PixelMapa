using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	private Vector3 screenSpace;
    private Vector3 offset;
    private Sensores sensores;
    private Vector3 posInicial;
    private Puzzle puzzle;
	private bool moviendoLeft, moviendoRight, moviendoUp, moviendoDown;
    private int numMovimientos = 0;

	void Awake(){
		sensores = GetComponentInChildren(typeof(Sensores)) as Sensores;
		puzzle = GameObject.Find ("Scripts").GetComponent (typeof(Puzzle)) as Puzzle;
	}

	void OnMouseDown(){
		screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
		posInicial = transform.position;
	}

	void OnMouseDrag () {
		Vector3 posicion=new Vector3 (Input.mousePosition.x, Input.mousePosition.y , 0); 
		Vector3 curScreenSpace = posicion;  
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;	
			
		if (!sensores.ocupadoLeft  || !sensores.ocupadoRight) {				
			curPosition = new Vector3 (curPosition.x, transform.position.y, 0);
			if (!sensores.ocupadoLeft && !moviendoLeft && !moviendoRight) {
				moviendoLeft = true;
			}
			if (!sensores.ocupadoRight && !moviendoRight && !moviendoLeft) {
				moviendoRight = true;
			}
		} else if (!sensores.ocupadoUp  || !sensores.ocupadoDown) {					
			curPosition = new Vector3 (transform.position.x, curPosition.y, 0);
			if (!sensores.ocupadoUp && !moviendoUp && !moviendoDown) {
				moviendoUp = true;
			}
			if (!sensores.ocupadoDown && !moviendoDown && !moviendoUp) {
				moviendoDown = true;
			}
		} else {
			return;																	
		}


		if (moviendoLeft) {
			if (curPosition.x > posInicial.x) {
				return;
			}
		}
		if (moviendoRight) {
			if (curPosition.x < posInicial.x) {
				return ;
			}
		}
		if (moviendoUp) {
			if (curPosition.y < posInicial.y) {
				return;
			}
		}
		if (moviendoDown) {
			if (curPosition.y > posInicial.y) {
				return ;
			}
		}

		if(Vector3.Distance(curPosition,posInicial)>1){return;}						
		transform.position = curPosition;												
	}



	void OnMouseUp(){
		transform.position=new Vector3(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y),0);
		moviendoLeft = false;
		moviendoRight = false;
		moviendoUp = false;
		moviendoDown = false;
		puzzle.ComprobarGanador();

        numMovimientos ++;
        Debug.Log(numMovimientos);
    }
}
