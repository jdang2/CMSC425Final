using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WalkerBossScript : MonoBehaviour
{
public Slider currentHealth;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundMask, playerMask;

    public Vector3 walkPoint;

    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;

    public bool playerInSightRange;

    private int RNG;

    public GameObject healthPack;

    public BossSpawnsEnemies tracker;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();

        tracker = GameObject.Find("WalkerSpawner").GetComponent<BossSpawnsEnemies>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        

            if (!playerInSightRange)
            {
                Patrol();
            }
            if (playerInSightRange)
            {
                Chase();
            }
        

    }

    private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distance = transform.position - walkPoint;

        if (distance.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);


        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
        {
            walkPointSet = true;
        }
    }
    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    public void TakeDamage(float amount)
    {
        currentHealth.value -= amount;
        if (currentHealth.value <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        RNG = Random.Range(0, 10);
        if(RNG >= 8){
            Vector3 temp = transform.position;
            temp.y = 50.0677f;
            Instantiate(healthPack, temp, Quaternion.identity);
        }
        tracker.enemyCount -= 1;
         
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
