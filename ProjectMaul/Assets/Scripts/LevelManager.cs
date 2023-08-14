using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PathController pathScript;

    int playerLife = 100;
    int playerGold;
    int currentLevel;
    int levelCap;

    float waveTimer;

    public GameObject EnemyToSpawn;
    int enimiesToSpawn = 8;

    public List<GameObject> currentTowers = new List<GameObject>();

    //We need to track player defeat progress should the enemys reach the goal.
    // need to manage spawning in the enemy waves.
    // Start is called before the first frame update

    public void Start()
    {
        pathScript = this.GetComponent<PathController>();
        StartCoroutine("SpawnWave");
    }
    public IEnumerator SpawnWave()
    {
        int spawned = 0;

        while (spawned < enimiesToSpawn)
        {
            Instantiate(EnemyToSpawn, pathScript.LevelPaths[0].Levelpath[0].gameObject.transform);
            spawned ++;
            yield return new WaitForSeconds(3f);
        }
        yield return null;
    }

    public void TakeDamage(int damage)
    {
        playerLife -= damage;

        if (playerLife < 0)
        {
            Debug.LogError("Game Over");
        }
    }
}
