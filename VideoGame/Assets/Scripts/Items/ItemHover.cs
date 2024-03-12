using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHover : MonoBehaviour
{

    [Header("Variables")]
    public float hoverSpeed = 2f; 
    public float hoverHeight = 0.1f; 
    private Vector3 startPos;

    void Start()
    {
        //Initial Position
        startPos = transform.position;
    }

    void Update()
    {
        //Calculate the new y for the object based on calculation
        float newY = startPos.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        //Update position
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
