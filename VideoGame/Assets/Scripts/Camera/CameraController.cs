using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;

    public Vector2 maxPos;
    public Vector2 minPos;

    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            playerPosition.x = Mathf.Clamp(playerPosition.x, minPos.x, maxPos.x);
            playerPosition.y = Mathf.Clamp(playerPosition.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        }
    }
}
