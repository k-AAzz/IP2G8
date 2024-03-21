using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [Header("Melee Variables")]
    private WeaponAim weaponScript;
    private float meleeDamage;

    //Track which enemies have already been hit
    private HashSet<Collider2D> hitEnemies = new HashSet<Collider2D>();

    void Start()
    {
        weaponScript = FindFirstObjectByType<WeaponAim>();
        meleeDamage = weaponScript.meleeDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !hitEnemies.Contains(collision))
        {
            collision.GetComponent<Enemy>().TakeDamage(meleeDamage);
            hitEnemies.Add(collision);
        }

        if (collision.CompareTag("Enemy2") && !hitEnemies.Contains(collision))
        {
            collision.GetComponent<FlyingEnemy>().TakeDamage(meleeDamage);
            hitEnemies.Add(collision);
        }
    }

    public void OnAttackAnimationFinished()
    {
        //Clear hash list and deactivate attack
        hitEnemies.Clear(); 
        weaponScript.meleeSlash.SetActive(false);
    }
}
