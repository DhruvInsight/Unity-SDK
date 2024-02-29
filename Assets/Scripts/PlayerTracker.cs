using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.InputSystem.XR.XRController;


public class PlayerTracker : MonoBehaviour
{
    public ActionBasedController LeftHand;
    public ActionBasedController RightHand;
    public Camera XRhead;

    
    private Transform _Camtans;
    private RaycastHit hit;
    private Ray r;
    private string LookedObject;

    private VRPlayerRecord recordVR;
    
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        //Set active depending if everything is assigned
        //this.enabled = CheckRefs();
    }

    void Start()
    {
        _Camtans = XRhead.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Checking what the Player is seeing
        r = new Ray(_Camtans.position, _Camtans.forward);

        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            LookedObject = hit.collider.name;
        }
        else
        {
            Debug.Log("Did not hit anything");
        }

        //recordVR = new VRPlayerRecord(_Camtans.position, _Camtans.rotation, hit.collider.gameObject.name);
        // Debug.Log(JsonUtility.ToJson(recordVR));
        // recordVR.position = _Camtans.position;
        // recordVR.rotation = _Camtans.rotation;
        // recordVR.ObjectName = LookedObject;
        Debug.Log("Looking at: "+ LookedObject + " Position: "+ _Camtans.position+ " Rotation: "+ _Camtans.rotation);
        // Debug.Log(JsonUtility.ToJson(recordVR));

    }

    bool CheckRefs()
    {
        //Check if all the components are assigned
        string msg = "";
        
        if (LeftHand == null)
        {
            msg += " [Left Controller] ";
        }

        if (RightHand == null)
        {
            msg += " [Right Controller] ";
        }

        if (XRhead == null)
        {
            msg += " [Head Camera] ";
        }

        if (msg == "")
        {
            Debug.Log("All Reference Connected");
            return true;
        }
        else
        {
            //I could use Debug.logerror here, but the project has many errors, you cant see this one
            Debug.Log(msg+" Not Assigned");
            Debug.Log("Deactivating Tracking Component");
            return false;
        }
    }
    
    
}
