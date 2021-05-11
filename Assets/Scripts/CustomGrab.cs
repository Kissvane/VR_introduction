using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrab : MonoBehaviour
{
    public VrPointer VrPointer;
    public OVRInput.Button GrabButton;
    public OVRInput.Controller Controller;
    public Transform GrabTransform;

    //
    public GameObject Grabbed;
    public Transform GrabbedParent;
    public Rigidbody Rigidbody;

    // Update is called once per frame
    void Update()
    {
        if (VrPointer.Hovered != null && Grabbed == null && OVRInput.GetDown(GrabButton, Controller))
        {
            Grab();
        }
        else if (Grabbed != null && OVRInput.GetUp(GrabButton, Controller))
        {
            UnGrab();
        }

    }

    void Grab()
    {
        Grabbed = VrPointer.Hovered;
        GrabbedParent = Grabbed.transform.parent;
        Grabbed.transform.SetParent(GrabTransform);
        Rigidbody = Grabbed.GetComponent<Rigidbody>();
        if (Rigidbody != null)
        {
            Rigidbody.isKinematic = true;
        }
    }

    void UnGrab()
    {
        Grabbed.transform.SetParent(GrabbedParent);
        Grabbed = null;
        if (Rigidbody != null)
        {
            Rigidbody.isKinematic = false;
            Rigidbody = null;
        }
    }
}
