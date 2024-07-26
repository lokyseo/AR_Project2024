using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpaceShipSlot : MonoBehaviour
{
    [SerializeField]
    GameData gameData;

    public void Initalsize(Item item)
    {
        LoadSprite(item.imageAddress, this.gameObject.transform.GetChild(0).GetComponent<Image>());

        for (int i = 0; i < item.needPartID.Count; i++)
        {
            int id = item.needPartID[i];
            Image image = this.gameObject.transform.GetChild(i + 2).GetComponent<Image>();


            LoadSprite(gameData.items[id].imageAddress, image);
        }
    }


    private void LoadSprite(string s,Image image)
    {
        Addressables.LoadAssetAsync<Sprite>(s).Completed += handle =>
        {
            image.sprite = handle.Result;
        };
    }
}
