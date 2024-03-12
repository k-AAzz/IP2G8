using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public int damage = 35;

    public Enemy enemy;
    public FlyingEnemy flyingEnemy;
    public enum WeaponType { Melee, Bullet}
    public WeaponType weaponType;

    public float bulletLife = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {         
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(damage);
        }

    }

    private void Update()
    {
        if (weaponType == WeaponType.Bullet)
        {
            Destroy(this.gameObject, bulletLife);

        }
    }

}
