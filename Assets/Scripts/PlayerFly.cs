using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    public Transform Eye;
    public OVRInput.Controller Controller;
    public OVRInput.Button ElevationButton;

    public OVRInput.Controller secondaryController;
    //public CharacterController CharacterController;

    public float Speed = 10f;
    Transform myTransform;
    
    // Start is called before the first frame update
    void Awake()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, Controller);

        if (axis != Vector2.zero)
        {
            if (OVRInput.Get(ElevationButton, Controller))
            {
                myTransform.position += (Eye.up * axis.y) * Speed * Time.deltaTime;
                //CharacterController.Move((Eye.up * axis.y) * Speed * Time.deltaTime);
            }
            else
            {
                myTransform.position += (Eye.forward * axis.y + Eye.right * axis.x) * Speed * Time.deltaTime;
                //CharacterController.Move((Eye.forward * axis.y + Eye.right * axis.x) * Speed * Time.deltaTime);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, secondaryController))
        {
            myTransform.localEulerAngles += Vector3.up * -90f * Mathf.Sign(axis.x);
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, secondaryController))
        {
            myTransform.localEulerAngles += Vector3.up * 90f * Mathf.Sign(axis.x);
        }
    }
}
