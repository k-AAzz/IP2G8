using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePosition - transform.position;

        // the negatives make it work
        float rotZ = Mathf.Atan2(-rotation.x, -rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -rotZ);
    }
}
