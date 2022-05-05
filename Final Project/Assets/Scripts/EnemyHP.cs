using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public Slider currentHealth;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundMask, playerMask;

    public Vector3 walkPoint;

    public GameObject HealthPack;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;

    public bool playerInSightRange;

    public bool isFlying;

    public float timeBetweenAttack;
    bool attacked;

    public float attackRange;

    public bool playerInAttackRange;

    public AudioSource fireProjectile = null;

    public GameObject projectile;

    private int RNG;

    public GameObject healthPack;

    public ProgressTrack tracker;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();

        tracker = GameObject.Find("Counter").GetComponent<ProgressTrack>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (isFlying)
        {
            if(!playerInSightRange && !playerInAttackRange){
                Patrol();
            }

            if(playerInSightRange && !playerInAttackRange){
                Chase();
            }

            if(playerInSightRange && playerInAttackRange){
                Attack();
            }
        }
        else
        {
            if (!playerInSightRange)
            {
                Patrol();
            }
            if (playerInSightRange)
            {
                Chase();
            }
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
            temp.y = 0.0141f;
            Instantiate(healthPack, temp, Quaternion.identity);
        }
        tracker.UpdateCount();
         
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Attack(){
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!attacked){
            Vector3 temp = transform.position;
            temp.y = temp.y + 0.5f;
            transform.position = temp;
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
            rb.AddForce(transform.up * 15f, ForceMode.Impulse);
            if(fireProjectile != null){
                fireProjectile.Play();
            }

            attacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttack);
        }
    }

    private void resetAttack(){
        attacked = false;
    }   
}
