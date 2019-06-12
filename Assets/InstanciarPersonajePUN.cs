using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPersonajePUN : MonoBehaviour
{
    public GameObject playerPrefab;

    public void SpawnPlayer()
    {
        int random = Random.Range(1,5);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(random, 0, 0), Quaternion.identity, 0);
    }
}
