using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public ARSession session;

    public PlaceablePrefabs[] prefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    [SerializeField]
    private GameData gameData;

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
        for (int i = 1; i < 5; i++)
        {
            spawnedPrefabs["test" + i].SetActive(false); 
        }

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
        Debug.Log("Updating image " + img.referenceImage.name + " at " + img.transform.position + "   " + img.trackingState);

        if (img.trackingState == TrackingState.Tracking)
        {

            spawned.transform.position = img.transform.position;
            spawned.transform.rotation = img.transform.rotation;
            spawned.SetActive(true);
            session.Reset();

            for(int i = 1; i <= 10; i++)
            {
                if (name == "test" + i)
                {
                    int id = Random.Range(3, 13);
                    //SceneManager.LoadScene(gameData.stages[id].sceneName);
                    SceneManager.LoadScene(id);
                }
            }
        }
        else
        {
            spawned.SetActive(false);
        }
    }
}