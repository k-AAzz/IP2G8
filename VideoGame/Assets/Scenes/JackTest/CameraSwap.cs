using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public Transform newTarget;
    public Vector3 playerChange;

    private CameraNew cam;

    [SerializeField]
    private GameObject[] objectsToEnable;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraNew>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //moves camera
            cam.SetTarget(newTarget);

            // player offset
            other.transform.position += playerChange;

            EnemyEnable();

        }
    }

    void EnemyEnable()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }

}
