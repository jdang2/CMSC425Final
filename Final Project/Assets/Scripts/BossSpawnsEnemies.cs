using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnsEnemies : MonoBehaviour
{
    public GameObject walkers;

    private float x;
    private float z;
    public int enemyCount;

    public int maxEnemies = 3;
    // Start is called before the first frame update

    public void SpawnEnemies(){
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn(){
        while(enemyCount < maxEnemies){
            x = Random.Range(-9f, 9f);
            z = Random.Range(30f, 53.45f);

            Instantiate(walkers, new Vector3(x, 50f, z), Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
            enemyCount += 1;
        }
    }
}
