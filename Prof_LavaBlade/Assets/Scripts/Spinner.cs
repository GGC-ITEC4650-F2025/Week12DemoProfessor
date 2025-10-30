using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 spinVec;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles += spinVec * Time.deltaTime;
    }

    //runs exact same speed on all computers
    //shoudl provide identical simulation
    void FixedUpdate()
    {
        transform.eulerAngles += spinVec * Time.fixedDeltaTime;
    }

}
