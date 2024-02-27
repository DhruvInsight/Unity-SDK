using System.Collections.Generic;
using InsightXR.Utils;
using UnityEngine;

namespace InsightXR.Core
{

    public class Component : MonoBehaviour
    {
        private List<SpatialPathDataModel> componentHistory;

        //TODO :- 
        //we are making a queue here and the data is collected it will be send to the server.
        //this will not slow down the data collection system.
        private readonly Queue<SpatialPathDataModel> componentHistoryQueus;

        private SpatialPathDataModel tempDataCollector;

        private void OnEnable(){
            componentHistory = new();
        }
        private void FixedUpdate(){
            tempDataCollector = new(transform.position, transform.rotation);
            componentHistory.Add(tempDataCollector);
        }
    }
}
