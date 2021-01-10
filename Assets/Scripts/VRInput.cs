using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;

    public float triggerValue;
    public float GripValue;

    public Vector3 velocity;
    public Vector3 angularVelocity;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    private string triggerAxis;
    private string gripAxis;

    
    // Start is called before the first frame update
    
    
    void Awake()
    {
        if(isLeftHand)
        {
            triggerAxis = "LeftTrigger";
            gripAxis = "LeftGrip";
        }
        else
        {
            triggerAxis = "RightTrigger";
            gripAxis = "RightGrip";
        }
    }

    // Update is called once per frame
    void Update()
    {
        triggerValue = Input.GetAxis(triggerAxis);
        GripValue = Input.GetAxis(gripAxis);

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;


    }
}
