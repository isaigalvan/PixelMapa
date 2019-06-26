using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun.Demo.PunBasics;
using Photon.Pun;

public class PUNLauncher : MonoBehaviourPunCallbacks
{

    #region Private Serializable Fields

    [Tooltip("El Panel Ui para permitir al usuario ingresar el nombre, conectarse y jugar")]
    [SerializeField]
    private GameObject controlPanel;

    [Tooltip("El texto Ui para informar al usuario sobre el progreso de la conexión")]
    [SerializeField]
    private Text feedbackText;

    [Tooltip("El número máximo de jugadores por sala")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [Tooltip("La UI Loader Anime")]
    [SerializeField]
    private LoaderAnime loaderAnime;
    #endregion

    #region Private Fields
    bool isConnecting;
    string gameVersion = "1";

    #endregion

    #region MonoBehaviour CallBacks
    void Awake()
    {
        if (loaderAnime == null)
        {
            Debug.LogError("<Color=Red><b>Missing</b></Color> loaderAnime referenciado.", this);
        }

        // #Critical
        // Esto asegura que podamos usar PhotonNetwork.LoadLevel () en el cliente maestro
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #endregion
}
