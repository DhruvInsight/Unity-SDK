using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LoadCamData : MonoBehaviour
{
    private List<VRPlayerRecord> MotionRecord;

    public int frame = 0;
    public int totalframes;

    public bool loaded;
    // Start is called before the first frame update
    void Start()
    {
        MotionRecord = JsonConvert.DeserializeObject<List<VRPlayerRecord>>(File.ReadAllText(Application.dataPath + "/Saves/Save.json"));
        loaded = true;
        totalframes = MotionRecord.Count;
        frame = 0;
        Debug.Log("Loaded Data");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S pressed");
            MotionRecord = JsonConvert.DeserializeObject<List<VRPlayerRecord>>(File.ReadAllText(Application.dataPath + "/Saves/Save.json"));
            loaded = true;
            Debug.Log("Loaded Data");
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && loaded && frame > 0)
        {
            frame--;
        
            transform.position = MotionRecord[frame].position;
            transform.rotation = MotionRecord[frame].rotation;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && loaded && frame < MotionRecord.Count-1)
        {
            frame++;
        
            transform.position = MotionRecord[frame].position;
            transform.rotation = MotionRecord[frame].rotation;
        }

        // if (frame < 0)
        // {
        //     frame = 0;
        // }
        //
        // if (frame > MotionRecord.Count - 1)
        // {
        //     frame = MotionRecord.Count - 1;
        // }
        //
        // transform.position = MotionRecord[frame].position;
        // transform.rotation = MotionRecord[frame].rotation;
    }
}
