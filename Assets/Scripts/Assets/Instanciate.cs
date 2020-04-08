﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public Rigidbody arrow;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody p = Instantiate(arrow, transform.position, transform.rotation);
        p.velocity = transform.forward * speed;
    }

}