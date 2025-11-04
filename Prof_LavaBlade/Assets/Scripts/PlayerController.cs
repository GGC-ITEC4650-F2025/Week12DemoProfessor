using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody myBod;
    public float moveForce;
    public int health;
    Transform healthBar;
    Text namePlate;
    
    //happens at game object creation time
    void Awake()
    {
        myBod = GetComponent<Rigidbody>();
        healthBar = transform.Find("Canvas/GreenHealth").transform;
        namePlate = transform.Find("Canvas/NamePlate").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        namePlate.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        //ONLY MOVE THE CUBE I OWN
        if (photonView.IsMine)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            myBod.AddForce(moveForce * (new Vector3(h, v, 0)) * Time.deltaTime);
            //SEND POS AND VEL OVER NETWORK TO ALL OTHER PLAYERS
            //Done by photonRigidbodyView component
        }
        else
        {
            //recieve pos and vel from other players
            //update this rigibody
            //Done by photonRigidbodyView component
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (photonView.IsMine)
        {
            health--;
            if (health < 0)
                health = 0;
            healthBar.localScale = new Vector3(health / 100f, 1, 1);
        }
    }
}
