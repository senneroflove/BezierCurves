using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DrowBezierCurves : MonoBehaviour
{
    public GameObject prefabObj;
    public GameObject lineRendererObj;
    private Vector3 startPoint;
    private Vector3 midPoint;
    private Vector3 endPoint;
    private Vector3[] drawPoints;
   
    private GameObject[] sphereArray;
    public GameObject targetSphere;
    
    private LinePoints[]linePoints;
    private LineRenderer[] lineRenderers;

    struct LinePoints
    {
        public Vector3 startPoint;
        public Vector3 endPoint;
    };

    // Start is called before the first frame update
    void Start()
    {
        drawPoints = new Vector3[100];
        sphereArray = new GameObject[100];
        linePoints = new LinePoints[100];
        lineRenderers = new LineRenderer[100];
        //lineRenderers = new LineRenderer[100];
        for (int i = 0; i < 100; i++)
        {

            lineRenderers[i] = Instantiate(lineRendererObj, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
        }
        CreatePoints();
        CreateSpheres();
        CreateLines();
        SetPoints();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
        SetPoints();
    }
    
    private void CreatePoints()
    {
        startPoint = new Vector3(0f, 0f, 0f);
        midPoint = new Vector3(5f, 3f, 0f);
        endPoint = new Vector3(10f, 0f, 0f);
        
        Vector3 p0, p1, p2;
        p0 = startPoint;
        p1 = midPoint;
        p2 = endPoint;

        for (int i = 0; i < 100; i++)
        {
            float x1 = p0.x + (p1.x - p0.x) * i / 100;
            float y1 = p0.y + (p1.y - p0.y) * i / 100;
            float x2 = p1.x + (p2.x - p1.x) * i / 100;
            float y2 = p1.y + (p2.y - p1.y) * i / 100;
            float cx = x1 + (x2 - x1) * i / 100;
            float cy = y1 + (y2 - y1) * i / 100;
            drawPoints[i] = new Vector3(cx, cy, 0.0f);
            linePoints[i].startPoint = new Vector3(x1, y1, 0f);
            linePoints[i].endPoint = new Vector3(x2, y2, 0f);
        }
    }
    
    private void CreateSpheres()
    {
        for (int i = 1; i < 100; i++)
        {
            sphereArray[i] = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
        }
    }
    
    private void CreateLines()
    {
        for (int i = 0; i < 100; i++)
        {
            lineRenderers[i].SetPosition(0, linePoints[i].startPoint);
            lineRenderers[i].SetPosition(1, linePoints[i].endPoint);
            lineRenderers[i].startWidth = 0.01f;
            lineRenderers[i].endWidth = 0.01f;
        }
    }
    
    private void UpdatePoints()
    {
        startPoint = new Vector3(0f, 0f, 0f);
        midPoint = targetSphere.transform.position;
        endPoint = new Vector3(10f, 0f, 0f);

        Vector3 p0, p1, p2;
        p0 = startPoint;
        p1 = midPoint;
        p2 = endPoint;

        for (int i = 0; i < 100; i++)
        {
            float x1 = p0.x + (p1.x - p0.x) * i / 100;
            float y1 = p0.y + (p1.y - p0.y) * i / 100;
            float x2 = p1.x + (p2.x - p1.x) * i / 100;
            float y2 = p1.y + (p2.y - p1.y) * i / 100;
            float cx = x1 + (x2 - x1) * i / 100;
            float cy = y1 + (y2 - y1) * i / 100;
            drawPoints[i] = new Vector3(cx, cy, 0.0f);
            linePoints[i].startPoint = new Vector3(x1, y1, 0f);
            linePoints[i].endPoint = new Vector3(x2, y2, 0f);
        }
    }
    
    private void SetPoints()
    {
        for (int i = 1; i < 100; i++)
        {
            sphereArray[i].transform.position = drawPoints[i];
            lineRenderers[i].SetPosition(0,linePoints[i].startPoint);
            lineRenderers[i].SetPosition(1, linePoints[i].endPoint);
        }
    }
    
    
}
