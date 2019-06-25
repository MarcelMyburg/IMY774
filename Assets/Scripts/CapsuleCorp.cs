using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCorp : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float timeToSpawn = 5f;
    public GameObject blockPrfab;
    public float spanRate = 6f;

	// Use this for initialization
	void Spawnblocks () {
        int randIndex = Random.Range(0, SpawnPoints.Length);

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if(randIndex == i)
            {
                Instantiate(blockPrfab, SpawnPoints[i].position, Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time >= timeToSpawn)
        {
            Spawnblocks();
            timeToSpawn = Time.time + spanRate;            
        }
	}

    
}
