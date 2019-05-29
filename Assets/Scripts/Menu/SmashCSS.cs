using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmashCSS : MonoBehaviour {

    //[HideInInspector] Hace que una variable no aparezca en el inspector, sino que se serialice.
    //[Header("")]Se utiliza para agregar un encabezado sobre algunos campos en el Inspector.
    //[Space] Se utiliza para agregar algo de espacio en el inspector.

    private GridLayoutGroup gridLayout;
    [HideInInspector]
    public Vector2 slotArtworkSize;


    public static SmashCSS instance;
    [Header("Characters List")]
    public List<Character> characters = new List<Character>();
    [Space]
    [Header("Public References")]
    public GameObject charCellPrefab;
    public GameObject gridBgPrefab;
    public Transform playerSlotsContainer;
    [Space]
    [Header("Current Confirmed Character")]
    public Character confirmedCharacter;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        gridLayout = GetComponent<GridLayoutGroup>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayout.cellSize.x * 5, gridLayout.cellSize.y * 2);
        RectTransform gridBG = Instantiate(gridBgPrefab, transform.parent).GetComponent<RectTransform>();
        gridBG.transform.SetSiblingIndex(transform.GetSiblingIndex());
        gridBG.sizeDelta = GetComponent<RectTransform>().sizeDelta;

        slotArtworkSize = playerSlotsContainer.GetChild(0).Find("artwork").GetComponent<RectTransform>().sizeDelta;

        //Se encarga de crear el numero de cada uno de los slots de los personajes
        foreach(Character character in characters)
        {
            SpawnCharacterCell(character);
        }

	}

    /// <summary>
    /// Esta función se encarga de que los valores que tiene el archivo ".assent" sean acomodados en los campos del
    /// prefab charCell, ademas de que modifica el pivote de la imagen que esta contenida en el campo artwork del prefab.
    /// </summary>
    /// <param name="character"> es un archivo .assent creado por el script Character</param>
    private void SpawnCharacterCell(Character character)
    {
        GameObject charCell = Instantiate(charCellPrefab, transform);

        charCell.name = character.characterName;

        Image artwork = charCell.transform.Find("artwork").GetComponent<Image>();
        TextMeshProUGUI name = charCell.transform.Find("nameRect").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = character.characterSprite;
        name.text = character.characterName;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        artwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
    }

    /// <summary>
    /// Esta función se encargará de mostrar la imagen del personaje que el cursor tenga en ese momento modificando el contenido que 
    /// tiene el prefab de playerSlotsContainer
    /// </summary>
    /// <param name="player"> variable que almacena el numero de jugador</param>
    /// <param name="character"> variable que almacena el nombre del personaje</param>
    public void ShowCharacterInSlot(int player, Character character)
    {
        bool nullChar = (character == null);

        Color alpha = nullChar ? Color.clear : Color.white;
        Sprite artwork = nullChar ? null : character.characterSprite;
        string name = nullChar ? string.Empty : character.characterName; 
        string playernickname = "Player " + (player + 1).ToString();
        string playernumber = "P" + (player+1).ToString();

        Transform slot = playerSlotsContainer.GetChild(player);

        Transform slotArtwork = slot.Find("artwork");
        Transform slotIcon = slot.Find("icon");

        Sequence s = DOTween.Sequence();
        s.Append(slotArtwork.DOLocalMoveX(-300, .05f).SetEase(Ease.OutCubic));
        s.AppendCallback(() => slotArtwork.GetComponent<Image>().sprite = artwork);
        s.AppendCallback(() => slotArtwork.GetComponent<Image>().color = alpha);
        s.Append(slotArtwork.DOLocalMoveX(300, 0));
        s.Append(slotArtwork.DOLocalMoveX(0, .05f).SetEase(Ease.OutCubic));

        if (nullChar)
        {
            slotIcon.GetComponent<Image>().DOFade(0, 0);
        }
        else
        {
            slotIcon.GetComponent<Image>().sprite = character.characterIcon;
            slotIcon.GetComponent<Image>().DOFade(.3f, 0);
        }

        if (artwork != null)
        {
            slotArtwork.GetComponent<RectTransform>().pivot = uiPivot(artwork);
            slotArtwork.GetComponent<RectTransform>().sizeDelta = slotArtworkSize;
            slotArtwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
        }
        slot.Find("name").GetComponent<TextMeshProUGUI>().text = name;
        slot.Find("player").GetComponentInChildren<TextMeshProUGUI>().text = playernickname;
        slot.Find("iconAndPx").GetComponentInChildren<TextMeshProUGUI>().text = playernumber;
    }

    /// <summary>
    /// Esta función se encarfa de verificar si el jugador ha escogido un personaje para luego almacenarlo
    /// </summary>
    /// <param name="player"> variable que almacena el numero de jugador</param>
    /// <param name="character"> variable que almacena el nombre del personaje</param>
    public void ConfirmCharacter(int player, Character character)
    {
        if (confirmedCharacter == null)
        {
            confirmedCharacter = character;
            playerSlotsContainer.GetChild(player).DOPunchPosition(Vector3.down * 3, .3f, 10,1);
        }
    }

    /// <summary>
    /// Esta función se encarga de acomodar correctamente el pivote del sprite del personaje y posteriormente
    /// encuadra el sprite en el su sección correspondiente del prefap
    /// </summary>
    /// <param name="sprite"></param>
    /// <returns></returns>
    public Vector2 uiPivot (Sprite sprite)
    {
        Vector2 pixelSize = new Vector2(sprite.texture.width, sprite.texture.height);
        Vector2 pixelPivot = sprite.pivot;
        return new Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);
    }

}
