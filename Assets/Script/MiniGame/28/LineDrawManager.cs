using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineDrawManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points;
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 0;
        points = new List<Vector3>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                points.Clear();
                lineRenderer.positionCount = 0;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10f; // 카메라에서의 거리
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], worldPos) > 0.1f)
                {
                    points.Add(worldPos);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
    }
}
