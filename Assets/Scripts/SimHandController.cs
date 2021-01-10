using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandController : MonoBehaviour  
{
    #region Variables
    // variables!
    public float moveSpeed;
    public float sprintSpeed;
    public float turnSpeed;
    public Transform location;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = location.position;

        #region Translatioal movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }


        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }


        if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }


        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }


        //Sprint

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= sprintSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= sprintSpeed; 
        }
        #endregion


        #region Rotation using keyboard
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.Self);
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.Self);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.Self);
        }
        #endregion

        #region Rotation usinng Mouse

        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);

        //transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self);
        #endregion



    }
}
