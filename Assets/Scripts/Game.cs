using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Transform spawnPosition;
    public GameObject enemy;
    public float spawnTime = 1f;

    public Transform[] wayPointList;
    public Transform spawnPoints;


    void Start () {
        Invoke("SpawnEnemy", spawnTime);
	}
	
	
	//void Update () {
		
	//}

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPosition.position, Quaternion.Euler(0, 0, 0));
        int children = spawnPoints.childCount;
        for (int i = 0; i < children ; i++)
        {
            this.wayPointList[i] = spawnPoints.GetChild(i);
        }
        enemy.GetComponent<Enemy>().wayPointList = this.wayPointList;
    }

}
