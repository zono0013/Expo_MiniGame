using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManeger : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0,30);
    }
}
