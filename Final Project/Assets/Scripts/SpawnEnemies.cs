using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject walkers;

    private float x;
    private float z;
    public int enemyCount;

    public int maxEnemies = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(enemyCount < maxEnemies){
            x = Random.Range(0.05f, 45f);
            z = Random.Range(-0.6f, 45f);

            Instantiate(walkers, new Vector3(x, 0, z), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

}
