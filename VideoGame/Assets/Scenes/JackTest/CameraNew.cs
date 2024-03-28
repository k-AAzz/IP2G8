using UnityEngine;

public class CameraNew : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    private void Update()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
