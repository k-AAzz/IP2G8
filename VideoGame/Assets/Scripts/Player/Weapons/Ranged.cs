using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    [Header("Ranged Variables")]
    private WeaponAim weaponScript;
    private float rangedDamage;
    public float bulletLife = .75f;

    public AudioSource audioPlayer;

    private void Start()
    {
        weaponScript = FindFirstObjectByType<WeaponAim>();
        rangedDamage = weaponScript.rangedDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(rangedDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(rangedDamage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(this.gameObject, bulletLife);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioPlayer.Play();

        }



    }

}
