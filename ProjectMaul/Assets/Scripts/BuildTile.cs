using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTile : MonoBehaviour
{
    public GameObject SpawnTower;

    public GameObject MyTower = null;


    [SerializeField] LevelManager lvlRef;

    public void Start()
    {
        lvlRef = GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>();
    }

    public void OnMouseDown()
    {
        if (lvlRef.activeTower != null && MyTower == null)
        {
            if (lvlRef.playerGold >= lvlRef.activeTower.Cost)
            {
                Debug.Log("Inside Stuff");
                lvlRef.playerGold -= lvlRef.activeTower.Cost;
                Instantiate(SpawnTower, new Vector3(this.transform.position.x, 0.6f, this.transform.position.z), Quaternion.identity);
                MyTower = SpawnTower;
                SpawnTower.GetComponent<TowerController>().MyTower = lvlRef.activeTower;
                GameObject.FindGameObjectWithTag("CanvasManager").GetComponentInChildren<TowerPickController>().AffordanceCheck();
            }
            else
            {
                Debug.Log("Not Enough Gold To Build This!");
            }
        }
        else
        {
            Debug.Log("Currently Occupied");
        }
    }


}
