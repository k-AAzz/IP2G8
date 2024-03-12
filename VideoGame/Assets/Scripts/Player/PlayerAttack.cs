using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Melee
    private GameObject attackArea;
    public bool isAttacking = false;
    public float timeToAttack = 0.25f;
    public float meleeTimer = 0f;

    // Ranged
    public Transform Aim;
    public GameObject bullet;
    public bool canShoot = true;
    public float fireForce = 10f;
    public float timeBetweenShooting = 0.25f;
    public float shootTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).GetChild(0).gameObject;

        attackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {       
        CheckMeleeTimer();
        CheckCanShoot();

        if (Input.GetMouseButtonDown(0))
        {

            MeleeAttack();
        }

        if (Input.GetMouseButtonDown(1) && canShoot)
        {
            Shoot();
        }
    }

    private void MeleeAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            attackArea.SetActive(isAttacking);
        }
    }

    void Shoot()
    {
        canShoot = false;    
        GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
        intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);
        
    }
    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            meleeTimer += Time.deltaTime;

            if (meleeTimer >= timeToAttack)
            {
                meleeTimer = 0f;
                isAttacking = false;
                attackArea.SetActive(false);
            }
        }
    }

    void CheckCanShoot()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer > timeBetweenShooting)
            {
                canShoot = true;
                shootTimer = 0f;
            }
        }
    }
}    


