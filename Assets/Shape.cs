using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] protected string shapeName;

    public Rigidbody2D rb;
    public Vector2 velocity;
    protected virtual void Start()
    {
        Debug.Log("hoo");
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
