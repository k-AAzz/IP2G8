using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    CameraController cam;

    public Vector2 cameraChange;
    public Vector3 playerChange;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //moves camera
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;

            // player offset
            other.transform.position += playerChange;
        }

    }
}
