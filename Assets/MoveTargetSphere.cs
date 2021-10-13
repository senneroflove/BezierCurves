using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time;
        this.transform.position = new Vector3(5f + Mathf.Sin(elapsedTime) * 5, 5f, 0f);
    }
}
