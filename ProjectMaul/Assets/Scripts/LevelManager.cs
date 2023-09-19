using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    PathController pathScript;

    public int playerLife = 100;
    public int playerGold = 100;
    public int currentLevel;
    public int levelCap;

    public float waveTimer;

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

    public Tower activeTower;
    public void ChooseTower(Tower myTower)
    {
        activeTower = myTower;
    }

    #region SpawnLevelQuickly
    [SerializeField]
    int width;
    [SerializeField]
    int height;
    [SerializeField]
    GameObject PrefabToSpawn;
    [ContextMenu("Spawn level tile grid 1x1 quickly using this method")]
    public void SpawnLevelTemplate()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(PrefabToSpawn, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }

    #endregion
}
