﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activatable
{
    public Vector3 openRotation;
    public Vector3 closedRotation;
    public float maxOpenSpeed = 45;
    public bool open;

    bool isMoving;

    void Start()
    {
        isMoving = false;

        if(open)
        {
            transform.rotation = Quaternion.Euler(openRotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(closedRotation);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            if(open)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), maxOpenSpeed * Time.deltaTime);
                if(Quaternion.Angle(transform.rotation, Quaternion.Euler(openRotation)) < 0.1f)
                {
                    isMoving = false;
                }
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(closedRotation), maxOpenSpeed * Time.deltaTime);
                if (Quaternion.Angle(transform.rotation, Quaternion.Euler(closedRotation)) < 0.1f)
                {
                    isMoving = false;
                }
            }
        }
    }

    public override void Activate(GameObject player)
    {
        Debug.Log("Door Moving");
        open = !open;

        isMoving = true;
    }
}
