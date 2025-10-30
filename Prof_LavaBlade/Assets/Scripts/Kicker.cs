using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    Rigidbody myBod;
    public Vector3 kickVec;
    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = kickVec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
