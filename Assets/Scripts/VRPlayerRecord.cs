using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerRecord
{
    public Vector3 position;
    public Quaternion rotation;
    public string ObjectName;
    
    public VRPlayerRecord(Vector3 pos, Quaternion rot, string Lookname)
    {
        this.position = pos;
        rotation = rot;
        ObjectName = Lookname;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
