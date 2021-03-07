using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkript : MonoBehaviour
{
    private void Awake()
    {
        Self = this;
    }
    public static PlayerSkript Self { get; private set; }
    public Rigidbody rb;
     Vector3 directionX = new Vector3(1, 0, 0);
     Vector3 directionZ = new Vector3(0, 0, 1);
    public float speed; 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + directionZ.normalized * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + directionZ.normalized * (speed*-1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + directionX.normalized * (speed*-1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + directionX.normalized * speed);
        }
    }
}
