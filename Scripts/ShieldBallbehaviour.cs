﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBallbehaviour : MonoBehaviour
{
    public float speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed);
    }
}
