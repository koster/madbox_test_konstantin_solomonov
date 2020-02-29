﻿using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Main.instance.Win();
    }
}