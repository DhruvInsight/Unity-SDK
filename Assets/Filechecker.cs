using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using File = System.IO.File;

public class Filechecker : MonoBehaviour
{
    public TMP_Text path;

    public TMP_Text filethere;

    public string camData = "";
    
    
    // Start is called before the first frame update
    void Start()
    {
        path.text = Application.dataPath + "/Saves";
        filethere.text = File.Exists(path.text + "/Save.savefile").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
