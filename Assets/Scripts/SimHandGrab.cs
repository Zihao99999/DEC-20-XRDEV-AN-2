﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 angularVelocity;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    public bool gripHeld;                   // prevent us from grabbing every frame
    public bool isheld;                     // object is held

    public float throwForce = 1;

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        #region velocity
        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
        #endregion

        if (Input.GetKeyDown(KeyCode.Mouse1) && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                // Do the grabbing
                Grab();
            }
        }

        if(Input.GetKeyUp(KeyCode.Mouse1) && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                Release();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            heldObject.BroadcastMessage("Interact");
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
        rb.velocity = velocity * throwForce;
        rb.angularVelocity = angularVelocity * throwForce;

        //resetting the held object
        rb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
