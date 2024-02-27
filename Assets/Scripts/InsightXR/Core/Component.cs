using System.Collections.Generic;
using InsightXR.Utils;
using UnityEngine;

namespace InsightXR.Core
{

    public class Component : MonoBehaviour
    {
        private List<SpatialPathDataModel> componentHistory;

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
