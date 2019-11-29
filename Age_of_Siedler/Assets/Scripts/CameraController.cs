//Autor: Stöckmann Timo
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }
}
