using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpaceShipParts : MonoBehaviour
{
    [SerializeField]
    GameObject partsSlot;

    [SerializeField]
    Transform contants;

    [SerializeField]
    GameData gameData;

    [SerializeField]
    List<Item> spaceShipParts;

    private void Start()
    {
        Debug.Log(CalculateLineCount());
        CalculateLineCount();

        foreach(var spaceShipPart in spaceShipParts)
        {
            GameObject slot = Instantiate(partsSlot, contants);
            slot.GetComponent<SpaceShipSlot>().Initalsize(spaceShipPart);
        }
    }

    private int CalculateLineCount()
    {
        spaceShipParts = gameData.items.Where(item => item.needPartID.Count != 0).ToList();
        return spaceShipParts.Count;
    }


}
