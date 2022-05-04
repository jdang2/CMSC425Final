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
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;

    public bool playerInSightRange;

    public bool isFlying;
  

    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update(){
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);

        if(!playerInSightRange){
            Patrol();
        }
        if(playerInSightRange){
            Chase();
        }

    }

    private void Patrol(){
        if(!walkPointSet){
            SearchWalkPoint();
        }

        if(walkPointSet){
            agent.SetDestination(walkPoint);
        }
        
        Vector3 distance = transform.position - walkPoint;

        if(distance.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        
        if(Physics.Raycast(walkPoint, -transform.up, 2f, groundMask)){
            walkPointSet = true;
        }
    }
    private void Chase(){
        agent.SetDestination(player.position);
    }

    public void TakeDamage(float amount){
        currentHealth.value -= amount;
        if(currentHealth.value <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
