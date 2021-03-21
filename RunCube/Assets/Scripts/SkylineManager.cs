using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylineManager : MonoBehaviour
{
    public Transform prefab;
    public int numberOfObjects;
    public Vector3 startPosition;
    public float recycleOfSet;
    public Vector3 minSize, maxSize;

    Vector3 nextPosition;
    Queue<Transform> objectQueue;
    void Start()
    {
        objectQueue = new Queue<Transform>(numberOfObjects);
        for(int i = 0; i < numberOfObjects; i++)
        {
            objectQueue.Enqueue((Transform)Instantiate(prefab));
        }
        nextPosition = startPosition;
        for(int i = 0; i< numberOfObjects; i++)
        {
            Recycle();
        }
        
    }

    
    void Update()
    {
        if(objectQueue.Peek().localPosition.x + recycleOfSet< Runner.distanceTraveled)
        {
            Recycle();
        }
    }
    private void Recycle()
    {
        Transform o = objectQueue.Dequeue();
        o.localPosition = nextPosition;
        nextPosition.x += o.localScale.x;
        objectQueue.Enqueue(o);
    } 
}
