using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineDrawManager : MonoBehaviour
{
    LineRenderer lineRenderer;

    private List<Transform> points = new List<Transform>();
    private bool isDrawing = false;

    public GameObject[] dots_Object;
    GameObject nowConnected_Object;
    int lineCount;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material.color = Color.black;
        lineRenderer.widthMultiplier = 20.0f;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (touch.phase == TouchPhase.Began)
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Point"))
                {
                    nowConnected_Object = hit.collider.gameObject;

                    points.Add(hit.transform);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPosition(points.Count - 1, hit.transform.position);
                    isDrawing = true;
                }
            }

            if (touch.phase == TouchPhase.Moved && isDrawing)
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Point") &&
                    nowConnected_Object.GetComponent<Dots_Property>().nearDots.Contains(hit.collider.gameObject))
                {
                    bool isAlreadyConnected = false;
                    for (int i = 0; i < lineRenderer.positionCount - 1; i++)
                    {
                        Vector3 start = lineRenderer.GetPosition(i);
                        Vector3 end = lineRenderer.GetPosition(i + 1);

                        if ((nowConnected_Object.transform.position == start && hit.transform.position == end) ||
                            (nowConnected_Object.transform.position == end && hit.transform.position == start))
                        {
                            isAlreadyConnected = true;
                        }
                    }

                    if(!isAlreadyConnected)
                    {
                        nowConnected_Object = hit.collider.gameObject;

                        points.Add(hit.transform);
                        lineRenderer.positionCount = points.Count;
                        lineRenderer.SetPosition(points.Count - 1, hit.collider.gameObject.transform.position);
                        lineCount++;

                        if(lineCount >= 6)
                        {
                            SceneManager.LoadScene("MainScene");
                        }

                    }
                    else
                    {
                        lineRenderer.positionCount = points.Count + 1;
                        lineRenderer.SetPosition(points.Count, mousePos);
                    }
                }
                else
                {
                    lineRenderer.positionCount = points.Count + 1;
                    lineRenderer.SetPosition(points.Count, mousePos);
                }

            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (isDrawing && lineCount < 6)
                {
                    lineCount = 0; 
                    lineRenderer.positionCount = 0;
                    points.Clear();
                    for (int i = 0; i < dots_Object.Length; i++)
                    {
                        dots_Object[i].GetComponent<Dots_Property>().isFailed = true;
                    }
                    isDrawing = false;
                }
            }
        }
    }
}
