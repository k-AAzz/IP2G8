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
    private Melee meleeScript;
    public AudioManager audioManager;
    public BossRoom room;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        meleeScript = FindFirstObjectByType<Melee>();
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
        

        if (room.weaponchange == true)
        {
            mousePosition = bossCam.ScreenToViewportPoint(Input.mousePosition);
        }
        else
        {
            mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(-rotation.x, -rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -rotZ);

        if (rotZ < 90 && rotZ > -90)
        {
            weaponSpriteRenderer.sortingLayerName = playerSpriteRenderer.sortingLayerName;
            weaponSpriteRenderer.sortingOrder = playerSpriteRenderer.sortingOrder - 1;
        }
        else
        {
            weaponSpriteRenderer.sortingLayerName = playerSpriteRenderer.sortingLayerName;
            weaponSpriteRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Rotation Angle: " + rotZ);
        }
    }

    //Item Functions
    public void ItemDamageIncrease()
    {
        meleeDamage = (float)(meleeDamage * 1.3);
        rangedDamage = (float)(meleeDamage * 1.3);
    }
}
