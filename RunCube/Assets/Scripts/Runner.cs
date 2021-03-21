using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public static float distanceTraveled;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(5f * Time.deltaTime, 0, 0);
        distanceTraveled = transform.localPosition.x;
    }
}
