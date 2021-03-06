﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput controller;

    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    public bool gripHeld;                   // prevent us from grabbing every frame
    public bool isheld;                     // object is held

    public float throwForce = 1;

    void Awake()
    {
        controller = GetComponent<VRInput>();
    }


    
    void Update()
    {
        if(controller.GripValue > 0.8 && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                // Do the grabbing
                Grab();
            }
        }

        else if(controller.GripValue < 0.8 && gripHeld == true)
        {
            gripHeld = false;

            if(heldObject)
            {
                Release();
            }
        }

        if(controller.triggerValue > 0.8f)
        {
            heldObject.BroadcastMessage("Interact");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    public void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        //throw
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.velocity = controller.velocity * throwForce;
        rb.angularVelocity = controller.angularVelocity * throwForce;

        //resetting the held object
        rb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}

