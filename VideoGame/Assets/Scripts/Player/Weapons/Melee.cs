using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [Header("Melee Variables")]
    private WeaponAim weaponScript;
    private float meleeDamage;

    public AudioManager audioManager;
    public string[] hitSoundOptions = { "HitSoundOne", "HitSoundTwo", "HitSoundThree" };

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
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(meleeDamage);
                hitEnemies.Add(collision);
                enemy.hitFlash = true;

                string randomSound = hitSoundOptions[Random.Range(0, hitSoundOptions.Length)];
                audioManager.PlayAudio(randomSound);
            }
        }

        if (collision.CompareTag("Enemy2") && !hitEnemies.Contains(collision))
            {
                collision.GetComponent<FlyingEnemy>().TakeDamage(meleeDamage);
                hitEnemies.Add(collision);

                string randomSound = hitSoundOptions[Random.Range(0, hitSoundOptions.Length)];
                audioManager.PlayAudio(randomSound);
            }
        }


    public void OnAttackAnimationFinished()
    {
        //Clear hash list and deactivate attack
        hitEnemies.Clear(); 
        weaponScript.meleeSlash.SetActive(false);
    }
}
