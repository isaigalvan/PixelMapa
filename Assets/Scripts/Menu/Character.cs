using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [CreateAssetMenu()] incluye automáticamente en el submenú Assets/Create las instancias del tipo puedan crearse 
/// y las almacenarse fácilmente en el proyecto como archivos ".asset".
/// 
/// fileName: Da un nombre al archivo predeterminado utilizado por las instancias recién creadas de este tipo.
/// menuName: Da un nombre para mostrar en el menú Assets/Create.
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    /// <summary>
    /// Son variables publicas que el script que almacenan el nombre, la imagen, el icono y el zoom del caracter.
    /// Solo se pueden usar estas variables desde el menú de inteacción.
    /// </summary>
    public string characterName;
    public Sprite characterSprite;
    public Sprite characterIcon;
    public float zoom = 1;

}
