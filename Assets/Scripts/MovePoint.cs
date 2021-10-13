using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public GameObject prefabObj;
    public GameObject pt;
    private Vector3 startPoint;
    private Vector3 midPoint;
    private Vector3 endPoint;
    private Vector3 currrentPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(0f, 0f, 0f);
        midPoint = new Vector3(5f, 3f, 0f);
        endPoint = new Vector3(10f, 0f, 0f);
        currrentPoint = new Vector3(0f, 0f, 0f);

        StartCoroutine("DrawPoints");
    }

    IEnumerator DrawPoints()
    {
        Vector3 p0, p1, p2;
        p0 = startPoint;
        p1 = midPoint;
        p2 = endPoint;

        float delta = 0.01f;
        for (float tf = 0f; tf < 1; tf += delta)
        {
            float x1 = p0.x + (p1.x - p0.x) * tf;
            float y1 = p0.y + (p1.y - p0.y) * tf;
            float x2 = p1.x + (p2.x - p1.x) * tf;
            float y2 = p1.y + (p2.y - p1.y) * tf;
            float cx = x1 + (x2 - x1) * tf;
            float cy = y1 + (y2 - y1) * tf;
            currrentPoint = new Vector3(cx, cy, 0.0f);
            GameObject obj = Instantiate(prefabObj, currrentPoint, Quaternion.identity);
            //TODO: Connect (x1,y1) and (x2,y2) by Straight Line
            
            yield return new WaitForSeconds(delta);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
