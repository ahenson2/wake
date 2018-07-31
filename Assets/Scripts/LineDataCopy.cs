using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDataCopy : MonoBehaviour {

  public BezierCurve bezierCurve;
  public int resolution;
  private LineRenderer lineRenderer;
  private int currentIndex = 0;
  public float trackerLength;

  public void ReachIndex(int index)
  {
    currentIndex = index;
  }

  public Vector3 GetClosestPoint(Vector3 position)
  {
    float bestT = 0;
    float bestDistance = 10000f;

    int i = currentIndex;
    BezierPoint p0 = bezierCurve[i];
    BezierPoint p1 = bezierCurve[i + 1];
    for (int j = 1; j < resolution + 1; j++)
    {
      float t = (float)j / resolution;
      Vector3 currentPoint = BezierCurve.GetPoint(p0, p1, t);
      float distance = Vector3.Distance(position, currentPoint);
      if (distance < bestDistance)
      {
        bestDistance = distance;
        bestT = t;
      }
    }
    return BezierCurve.GetPoint(p0, p1, bestT + trackerLength);
  }

  private void PopulateCurve()
  {
    int totalPoints = /*(bezierCurve.pointCount - 1) * */ resolution;
    Vector3[] curvePoints = new Vector3[totalPoints];
    int index = 0;

    //for (int i = 0; i < bezierCurve.pointCount - 1; i++)
    //{
    int i = currentIndex;
    BezierPoint p0 = bezierCurve[i];
    BezierPoint p1 = bezierCurve[i + 1];

    //Vector3 lastPoint = p0.position;
    //Vector3 currentPoint = Vector3.zero;

    for (int j = 1; j < resolution + 1; j++)
    {
      Vector3 currentPoint = BezierCurve.GetPoint(p0, p1, (float) j / resolution);
      //Gizmos.DrawLine(lastPoint, currentPoint);
      curvePoints[index] = currentPoint;
      index++;

      //lastPoint = currentPoint;
      }
    //}
    lineRenderer.positionCount = totalPoints;
    lineRenderer.SetPositions(curvePoints);
  }

	// Use this for initialization
	void Start () {
    lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
    PopulateCurve();
	}
}
