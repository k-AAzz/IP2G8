using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [Header("Melee Variables")]
    private WeaponAim weaponScript;
    private float meleeDamage;

    void Start()
    {
      weaponScript = FindFirstObjectByType<WeaponAim>();
      meleeDamage = weaponScript.meleeDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<Enemy>().TakeDamage(meleeDamage);
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(meleeDamage);
        }
        weaponScript.meleeSlash.SetActive(false);
    }
}
