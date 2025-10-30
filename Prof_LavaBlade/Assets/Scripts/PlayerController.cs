using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myBod;
    public float moveForce;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        myBod.AddForce(moveForce * (new Vector3(h, v, 0)) * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        health--;
    }
}
