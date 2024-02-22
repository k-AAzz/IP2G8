using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform target;

    NavMeshAgent agent;

    public float health = 100;
    bool isDead = false;
    public GameObject me;
    public GameObject items;

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
        agent.SetDestination(target.position);

        if (isDead == true)
        {
            Destroy(me);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(35);
        }
    }

    public void TakeDamage(int damage = 35) //Take damage function
    {
        health -= damage;

        if (health < 0)
        {
            isDead = true; //If health is less than 0, enemy is dead
            items.GetComponent<ItemChooser>().SpawnRandomItem();
        }
    }
}
