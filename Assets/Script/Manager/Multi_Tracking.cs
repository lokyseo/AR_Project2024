using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Multi_Tracking : MonoBehaviour
{
    public float _timer;
    public ARTrackedImageManager trackedManager;
    public List<GameObject> objectList = new List<GameObject>();
    private Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();
    private List<ARTrackedImage> trackedImage = new List<ARTrackedImage>();
    private List<float> trackedTimer = new List<float>();


    private void Awake()
    {
        foreach(GameObject obj in objectList)
        {
            string tName = obj.name;
            prefabDictionary.Add(tName, obj);
        }
    }

   void Update()
   {
       if(trackedImage.Count > 0)
       {
           List<ARTrackedImage> tNumList = new List<ARTrackedImage>();
           for(var i = 0; i <trackedImage.Count; i++)
           {
               if(trackedImage[i].trackingState == TrackingState.Limited)
               {
                   if (trackedTimer[i] > _timer)
                   {
                       string name = trackedImage[i].referenceImage.name;
                       GameObject tobj = prefabDictionary[name];
                       tobj.SetActive(false);
                       tNumList.Add(trackedImage[i]);
                   }
                   else
                   {
                       trackedTimer[i] += Time.deltaTime;
                   }
               }
           }
   
           if(tNumList.Count > 0)
           {
               for(var i = 0;i < tNumList.Count;i++)
               {
                   int num = trackedImage.IndexOf(tNumList[i]);
                   trackedImage.Remove(trackedImage[num]);
                   trackedTimer.Remove(trackedTimer[num]);
   
               }
           }
       }
   
   }

    private void OnEnable()
    {
        trackedManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image_t in eventArgs.added)
        {
            if (!trackedImage.Contains(image_t))
            {
                trackedImage.Add(image_t);
                trackedTimer.Add(0);
            }
            else
            {
                int num = trackedImage.IndexOf(image_t);
                trackedTimer[num] = 0;
            }
            UpdateImage(image_t);


        }


    }
    private void UpdateImage(ARTrackedImage image_t)
    {
        string name = image_t.referenceImage.name;
        GameObject tobj = prefabDictionary[name];
        tobj.transform.position = image_t.transform.position;
        tobj.transform.rotation = image_t.transform.rotation;
        tobj.SetActive(true);
    }
}
