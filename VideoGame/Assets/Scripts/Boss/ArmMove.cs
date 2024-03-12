using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ArmMove : MonoBehaviour
{
    public Transform arm;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    public GameObject me;

    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        arm.position = Vector2.Lerp(arm.position, target, speed * Time.deltaTime);

        float distance= (target - (Vector2)arm.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }

        if (distance <= 0.1f && direction == 1)
        {
            Destroy(me);
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if(arm!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(arm.transform.position, startPoint.position);
            Gizmos.DrawLine(arm.transform.position, endPoint.position);
        }
    }
}
