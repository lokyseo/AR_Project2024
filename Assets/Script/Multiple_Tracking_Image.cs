using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public struct PlaceablePrefabs
{
    public string name; // name corresponding to the tracked image name
    public GameObject prefab;
}

public class Multiple_Tracking_Image : MonoBehaviour
{
    private ARTrackedImageManager imgManager;

    public PlaceablePrefabs[] prefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        imgManager = GetComponent<ARTrackedImageManager>();

        foreach (PlaceablePrefabs prefab in prefabs)
        {
            GameObject instantiated = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
            instantiated.name = prefab.name;
            spawnedPrefabs.Add(instantiated.name, instantiated);
            instantiated.SetActive(false);

        }
    }

    private void OnEnable()
    {
        imgManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        imgManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage img in args.added)
        {
            UpdateSpawned(img);
        }

        foreach (ARTrackedImage img in args.updated)
        {
            UpdateSpawned(img);
        }

        foreach (ARTrackedImage img in args.removed)
        {
            spawnedPrefabs[img.referenceImage.name].SetActive(false);
        }

    }

    private void UpdateSpawned(ARTrackedImage img)
    {
        string name = img.referenceImage.name;

        GameObject spawned = spawnedPrefabs[name];

        if (img.trackingState == TrackingState.Tracking)
        {
            Debug.Log("Updating image " + img.referenceImage.name + " at " + img.transform.position);

            spawned.transform.position = img.transform.position;
            spawned.transform.rotation = img.transform.rotation;
            spawned.SetActive(true);
        }
        else
        {
            spawned.SetActive(false);

        }
    }
}