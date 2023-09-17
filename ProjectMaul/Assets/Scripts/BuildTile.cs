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
        if (MyTower == null)
        {
            if (lvlRef.playerGold >= SpawnTower.GetComponent<TowerController>().myCost)
            {
                lvlRef.playerGold -= SpawnTower.GetComponent<TowerController>().myCost;
                Instantiate(SpawnTower, new Vector3(this.transform.position.x, 0.6f, this.transform.position.z), Quaternion.identity);
                MyTower = SpawnTower;
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
