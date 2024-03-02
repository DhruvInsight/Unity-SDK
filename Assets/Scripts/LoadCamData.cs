using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LoadCamData : MonoBehaviour
{
    private List<VRPlayerRecord> MotionRecord;

    public int frame = 0;
    public int totalframes;

    public bool loaded;
    private string path;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadStreamingAsset());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && loaded && frame > 0)
        {
            frame--;

            transform.position = MotionRecord[frame].position;
            transform.rotation = MotionRecord[frame].rotation;
        }

        if (Input.GetKey(KeyCode.RightArrow) && loaded && frame < MotionRecord.Count - 1)
        {
            frame++;

            transform.position = MotionRecord[frame].position;
            transform.rotation = MotionRecord[frame].rotation;
        }
    }
    
    private IEnumerator LoadStreamingAsset()
    {
        string filePath = Application.streamingAssetsPath + "/SaveCam/CameraData.json";

        // Create a UnityWebRequest to load the file content
        using (UnityWebRequest www = UnityWebRequest.Get(filePath))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Process the loaded content (e.g., parse XML, JSON, etc.)
                string fileContent = www.downloadHandler.text;
                Debug.Log(fileContent);
               
                 MotionRecord = JsonConvert.DeserializeObject<List<VRPlayerRecord>>(fileContent);
                 loaded = true;
                 totalframes = MotionRecord.Count;
                 frame = 0;
                 Debug.Log("Loaded Data");
                
                 loaded = true;
            }
            else
            {
                Debug.LogError("Error");
            }
        }
    }
}