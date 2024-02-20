using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : MonoBehaviour
{

    [SerializeField] Transform target;

    NavMeshAgent agent;

    public float attackRange;

    public LayerMask whatIsPlayer;

    public bool playerInAttackRange;

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && timer > 2)
        {
            AttackPlayer();
            timer = 0;
        }
        else if(!playerInAttackRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.right = target.position - transform.position;

        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
