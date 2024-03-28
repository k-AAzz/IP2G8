using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class FlyingEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 3.5f;
    private float originalMoveSpeed;
    private NavMeshAgent agent;

    [Header("Combat")]
    public float attackRange;
    public LayerMask whatIsPlayer;
    private bool playerInAttackRange;
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    [Header("Health")]
    public float health = 10f;
    private bool isDead = false;
    public bool hitFlash = false;
    public GameObject me;

    [Header("Enemy Drops")]
    public Sprite[] enemyDrop;
    public GameObject spawnLocation;
    public int damage = 1;

    [Header("References")]
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public AudioSource audioPlayer;





    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = moveSpeed;
        originalMoveSpeed = moveSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindFirstObjectByType<GameManager>();

        //Store the original material
        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && timer > 2)
        {
            AttackPlayer();
            timer = 0;
        }
        else if (!playerInAttackRange)
        {
            ChasePlayer();
        }

        if (isDead)
        {
            Destroy(me);
        }

        if (hitFlash)
        {
            StartCoroutine(HitFlash());
        }

        agent.speed = moveSpeed;
    }

    void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    void AttackPlayer()
    {
        // Set destination to current position to stop the enemy
        agent.SetDestination(transform.position);

        transform.right = target.position - transform.position;

        // Instantiate bullet or any other attack mechanism here
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


    void SpawnDrop(Sprite[] itemsArray)
    {
        if (itemsArray != null && itemsArray.Length > 0)
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            int randomIndex = UnityEngine.Random.Range(0, itemsArray.Length);
            //Debug.Log("Random Index: " + randomIndex);
            //Debug.Log("Array Length: " + itemsArray.Length);

            Sprite chosenItem = itemsArray[randomIndex];

            //Create the item above the pedestal
            GameObject newItem = new GameObject("EnemyDrop");

            newItem.transform.position = spawnLocation.transform.position;

            //Add a sprite renderer with values
            SpriteRenderer spriteRenderer = newItem.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = chosenItem;
            spriteRenderer.sortingOrder = 2;

            //Change the scale of the sprite / My references are too small can be removed later on
            float scaleMultiplier = 1f;
            newItem.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1.0f);

            //Attach item script to the object and run internal function
            EnemyItem item = newItem.AddComponent<EnemyItem>();
            item.InitializeItem(chosenItem, itemsArray);

            //Attach 2D collider with trigger so it can be interacted with
            BoxCollider2D collider = newItem.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
        }
    }

    public void TakeDamage(float damage)
    {
        bool isFrozen = gameManager.frozenSphere;
        if (isFrozen)
        {
            StartCoroutine(ApplyFreeze());
        }

        health -= damage;

        if (health <= 0)
        {
            isDead = true;

            float dropChance = gameManager.enemyDropChance;

            if (Random.value * 100 <= dropChance)
            {
                SpawnDrop(enemyDrop);
            }
        }
    }

    IEnumerator ApplyFreeze()
    {
        float frozenMultiplier = gameManager.frozenMultiplier;
        float reductionAmount = moveSpeed * frozenMultiplier;

        moveSpeed -= reductionAmount;

        //Change the material
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Material frozenMaterial = gameManager.frozenMaterial;
        if (spriteRenderer != null && frozenMaterial != null)
        {
            spriteRenderer.material = frozenMaterial;
        }

        yield return new WaitForSeconds(3f);

        moveSpeed += reductionAmount;

        //Revert the material
        if (spriteRenderer != null && originalMaterial != null)
        {
            spriteRenderer.material = originalMaterial;
        }
    }

    IEnumerator HitFlash()
    {
        Material hitFlashMaterial = gameManager.hitFlashMaterial;

        if (hitFlashMaterial != null)
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            spriteRenderer.GetPropertyBlock(materialPropertyBlock);
            materialPropertyBlock.SetColor("_Color", Color.red);
            spriteRenderer.SetPropertyBlock(materialPropertyBlock);
        }

        yield return new WaitForSeconds(0.25f);
        hitFlash = false;

        // Reset material property block to original material
        spriteRenderer.SetPropertyBlock(null);
    }

    void OnGUI()
    {
        if (target != null && !isDead)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y += 40;
            GUI.Label(new Rect(screenPosition.x, Screen.height - screenPosition.y, 100, 20), "HP: " + health);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioPlayer.Play();

        }



    }


}
