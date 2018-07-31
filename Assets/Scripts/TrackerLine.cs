using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerLine : MonoBehaviour {

  public LineDataCopy lineData;
  private LineRenderer lineRenderer;
  public int resolution;
  private Vector3 startPosition;
  private Vector3 endPosition;

  private Vector3 GetCurvePoint(float t)
  {
    Vector3 helperPoint = startPosition;
    helperPoint.y = 0;

    Vector3 mid1 = Vector3.Lerp(startPosition, helperPoint, t);
    Vector3 mid2 = Vector3.Lerp(helperPoint, endPosition, t);

    Vector3 result = Vector3.Lerp(mid1, mid2, t);

    return result;
  }

  private void UpdatePoints()
  {
    Vector3[] curvePoints = new Vector3[resolution];

    for (int i = 0; i < resolution; i++)
    {
      float t = (float)i / resolution;
      curvePoints[i] = GetCurvePoint(t);
    }

    lineRenderer.positionCount = resolution;
    lineRenderer.SetPositions(curvePoints);
  }
	// Use this for initialization
	void Start () {
    lineRenderer = GetComponent<LineRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
    startPosition = transform.position;
    endPosition = lineData.GetClosestPoint(transform.position);//transform.position + Vector3.forward + Vector3.down;
    UpdatePoints();
	}
}
