using System.Collections;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private GameObject attackArea;

    [Header("Melee Settings")]
    public GameObject meleeSlash;
    public float meleeDamage = 2.5f;
    public float meleeAttackSpeed = 0.25f;
    public float meleeTimer = 0f;
    public bool isAttacking = false;
    public float knockbackForce = 6f;


    [Header("Ranged Settings")]
    public Transform Aim;
    public GameObject bullet;
    public float rangedDamage = 2.5f;
    public float fireForce = 10f;
    public float rangedAttackSpeed = 0.25f;
    public float shootTimer = 0f;
    public bool canShoot = true;

    [Header("Weapon Aim Settings")]
    public SpriteRenderer weaponSpriteRenderer;
    public SpriteRenderer playerSpriteRenderer;

    // Camera reference
    private Camera mainCam;
    private Vector3 mousePosition;
    public Camera bossCam;

    // Other References
    public Melee meleeScript;
    public AudioManager audioManager;
    public BossRoom room;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        meleeSlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeleeTimer();
        CheckCanShoot();

        if (!meleeSlash.activeSelf)
        {
            AimWeapon();
        }


        if (Input.GetMouseButtonDown(0) && !isAttacking && canShoot)
        {
            Melee();
        }

        if (Input.GetMouseButtonDown(1) && canShoot && !isAttacking)
        {
            Shoot();
        }
    }

    public void Melee()
    {
        isAttacking = true;
        meleeSlash.SetActive(true);
        audioManager.PlayAudio("AttackSlash");
        StartCoroutine(HideMelee());
    }

    private IEnumerator HideMelee()
    {
        yield return new WaitForSeconds(0.25f);
        meleeSlash.SetActive(false);
        meleeScript.OnAttackAnimationFinished();
    }

    void Shoot()
    {
        canShoot = false;
        GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
        intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);
        audioManager.PlayAudio("ThrowingSound");
    }

    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            meleeTimer += Time.deltaTime;

            if (meleeTimer >= meleeAttackSpeed)
            {
                meleeTimer = 0f;
                isAttacking = false;

            }
        }
    }

    void CheckCanShoot()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer > rangedAttackSpeed)
            {
                canShoot = true;
                shootTimer = 0f;
            }
        }
    }

    void AimWeapon()
    {
        // Get the mouse position in world coordinates
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure z-coordinate is 0 (assuming 2D)

        // Calculate the direction vector from the player's position to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Add a 90-degree offset to the angle
        angle += 90f;

        // Apply the rotation to the weapon
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Adjust the weapon's sorting order based on rotation
        if (angle < 90 && angle > -90)
        {
            weaponSpriteRenderer.sortingLayerName = playerSpriteRenderer.sortingLayerName;
            weaponSpriteRenderer.sortingOrder = playerSpriteRenderer.sortingOrder - 1;
        }
        else
        {
            weaponSpriteRenderer.sortingLayerName = playerSpriteRenderer.sortingLayerName;
            weaponSpriteRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + 1;
        }

        // Debug log the rotation angle
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Rotation Angle: " + angle);
        }
    }



    //Item Functions
    public void ItemDamageIncrease()
    {
        meleeDamage = (float)(meleeDamage * 1.3);
        rangedDamage = (float)(meleeDamage * 1.3);
    }
}
