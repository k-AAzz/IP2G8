using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject maincam;
    public GameObject bosscam;

    CameraController cam;
    public IdleState change;
    public bool weaponchange;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bosscam.SetActive(true);
            maincam.SetActive(false);
            change.canSeePlayer = true;
            weaponchange = true;
        }
    }

}
