using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineScale : MonoBehaviour
{
    public float speed;
    float theta;

    Vector3 startScale;
    void Start()
    {
        startScale = transform.localScale;
    }
    void Update()
    {
        theta += speed*Time.deltaTime;
        transform.localScale = startScale + Mathf.Sin(theta)*startScale/10;
    }
}
