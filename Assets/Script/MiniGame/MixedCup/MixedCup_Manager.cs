using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MixedCup_Manager : MonoBehaviour, IPointerDownHandler
{
    public GameObject totalPosition;
    public Transform RotateGroup;

    Transform objectA;
    Transform objectB;
    float swapCoolTime;
    int swapCount;
    bool isSwapFinish;

    float rotationSpeed = 360.0f;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name.Contains("Center") && isSwapFinish)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    void Start()
    {
        isSwapFinish = false;
        swapCoolTime = 1.0f;
        swapCount = 8;
        StartCoroutine(SwapPositionsCoroutine());

    }
    void Update()
    {
        swapCoolTime -= Time.deltaTime;
        if (swapCoolTime < 0.0f && swapCount > 0)
        {
            swapCoolTime = 1.0f;
            StartCoroutine(SwapPositionsCoroutine());
            swapCount--;
        }
        if(swapCount <= 0)
        {
            isSwapFinish = true;
        }
    }
    IEnumerator SwapPositionsCoroutine()
    {
        int firstIndex = Random.Range(0, 3);
        int secondIndex;

        do
        {
            secondIndex = Random.Range(0, 3);
        } while (secondIndex == firstIndex);

        Debug.Log(firstIndex + "     " + secondIndex);
        objectA = totalPosition.transform.GetChild(firstIndex).gameObject.transform;
        objectB = totalPosition.transform.GetChild(secondIndex).gameObject.transform;

        Vector3 midpoint = (objectA.position + objectB.position) / 2;

        float elapsedTime = 0.0f;
        float duration = 180.0f / rotationSpeed;

        Vector3 startPosA = objectA.position - midpoint;
        Vector3 startPosB = objectB.position - midpoint;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float angle = Mathf.Lerp(0, 180.0f, elapsedTime / duration);

            objectA.position = midpoint + RotatePointAroundPivot(startPosA, Vector3.zero, angle);
            objectB.position = midpoint + RotatePointAroundPivot(startPosB, Vector3.zero, angle);

            yield return null;
        }

        objectA.position = midpoint + startPosB;
        objectB.position = midpoint + startPosA;
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(0, 0, angle) * dir;
        point = dir + pivot;
        return point;
    }
}
