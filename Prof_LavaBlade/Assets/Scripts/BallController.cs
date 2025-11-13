using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallController : MonoBehaviourPunCallbacks
{
    public Color[] colors;
    Renderer myRend;
    // Start is called before the first frame update
    void Awake()
    {
        myRend = GetComponent<Renderer>();
        myRend.material.color = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if(PhotonNetwork.IsMasterClient) //THIS IS THE SERVER
        {
            if(otherGO.tag == "Player")
            {
                //PlayerController pc = otherGO.GetComponent<PlayerController>();
                //pc.increaseScore(10);
                PhotonView pv = otherGO.GetComponent<PhotonView>();
                
                if(myRend.material.color == colors[0]) {
                    pv.RPC("increaseScore", RpcTarget.AllBuffered, -10);
                    photonView.RPC("setColor", RpcTarget.AllBuffered, 1);
                }
                else {
                    pv.RPC("increaseScore", RpcTarget.AllBuffered, 10);
                    photonView.RPC("setColor", RpcTarget.AllBuffered, 0);
                }
            }
        }
    }

    [PunRPC]
    public void setColor(int i)
    {
        myRend.material.color = colors[i];
    }
}
