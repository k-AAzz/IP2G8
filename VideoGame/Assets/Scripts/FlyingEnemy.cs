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
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange)
        {
            AttackPlayer();
        }
        else
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
    }
}
