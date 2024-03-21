using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private WeaponAim weaponScript;
    private float meleeDamage;
    // Start is called before the first frame update
    void Start()
    {
      weaponScript = FindFirstObjectByType<WeaponAim>();
      meleeDamage = weaponScript.meleeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<Enemy>().TakeDamage(meleeDamage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(meleeDamage);
            Destroy(this.gameObject);
        }
        weaponScript.meleeSlash.SetActive(false);
    }
}
