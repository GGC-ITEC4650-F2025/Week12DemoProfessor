using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetMan : MonoBehaviourPunCallbacks
{
    Spinner lavaBladeSpinner;
    public GameObject playerPrefab;
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        lavaBladeSpinner = GameObject.Find("LavaBlade").GetComponent<Spinner>();
    }

    //Runs on each laptop when they join the game
    public override void OnJoinedRoom()
    {
        float netTime = (float)PhotonNetwork.Time;
        lavaBladeSpinner.transform.eulerAngles =
            lavaBladeSpinner.spinVec * netTime;

        Vector3 pos = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
    }

    //RUNS ON SERVER WHEN PLAYER ENTERS GAME
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //Create ball after 4 players join.
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 4) {
            PhotonNetwork.Instantiate(ballPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }
}
