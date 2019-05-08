using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CursorDetection : MonoBehaviour {

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Transform currentCharacter;

    public Transform token;
    public bool hasToken;

	void Start () {

        gr = GetComponentInParent<GraphicRaycaster>();

        SmashCSS.instance.ShowCharacterInSlot(0, null);

    }

    /// <summary>
    /// Esta funcion se encarga de identificar si el usuario confirmo un personaje por medio del token
    /// que puede ser verificado a travez del inspector.
    /// 
    /// El token es un circulo que esta junto al cursor que es dejado en el slot del personaje una vez
    /// es confirmado y se creara una pequeña animación, de lo contrario el token permanecera siguiendo al cursor.
    /// </summary>
    void Update () {

        //Confirma
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentCharacter != null)
            {
                TokenFollow(false);
                SmashCSS.instance.ConfirmCharacter(0, SmashCSS.instance.characters[currentCharacter.GetSiblingIndex()]);
            }
        }

        //Cancela
        if (Input.GetKeyDown(KeyCode.X))
        {
            SmashCSS.instance.confirmedCharacter = null;
            TokenFollow(true);
        }

        if (hasToken)
        {
            token.position = transform.position;
        }

        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (hasToken)
        {
            if (results.Count > 0)
            {
                Transform raycastCharacter = results[0].gameObject.transform;

                if (raycastCharacter != currentCharacter)
                {
                    if (currentCharacter != null)
                    {
                        currentCharacter.Find("selectedBorder").GetComponent<Image>().DOKill();
                        currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                    }
                    SetCurrentCharacter(raycastCharacter);
                }
            }
            else
            {
                if (currentCharacter != null)
                {
                    currentCharacter.Find("selectedBorder").GetComponent<Image>().DOKill();
                    currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                    SetCurrentCharacter(null);
                }
            }
        }
		
	}

    /// <summary>
    /// Es una función que se encarga de hacer vibrar el prefab de playerSlotsContainer mientras que lo cambia de color
    /// generando una animación que indica que se ha confirmado un personaje
    /// </summary>
    /// <param name="t"></param>
    void SetCurrentCharacter(Transform t)
    {
        
        if(t != null)
        {
            t.Find("selectedBorder").GetComponent<Image>().color = Color.white;
            t.Find("selectedBorder").GetComponent<Image>().DOColor(Color.red, .7f).SetLoops(-1);
        }

        currentCharacter = t;

        if (t != null)
        {
            int index = t.GetSiblingIndex();
            Character character = SmashCSS.instance.characters[index];
            SmashCSS.instance.ShowCharacterInSlot(0, character);
        }
        else
        {
            SmashCSS.instance.ShowCharacterInSlot(0, null);
        }
    }

    void TokenFollow (bool trigger)
    {
        hasToken = trigger;
    }
}
