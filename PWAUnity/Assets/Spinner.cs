using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rate = 10f;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rate * Time.deltaTime, rate * 2 * Time.deltaTime, rate * 3 * Time.deltaTime);
    }
}
