using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPickController : MonoBehaviour
{

    [SerializeField]
    List<Tower> towerList = new List<Tower>();
    [SerializeField]
    List<Button> towerPickBTNs = new List<Button>();
    public LevelManager testing;

    public void activeTower(int towerPicked)
    {
        GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().activeTower = towerList[towerPicked];
    }

    public void Start()
    {
        AffordanceCheck();
        testing = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<LevelManager>();
    }

    public void AffordanceCheck()
    {
        for (int i = 0; i < towerList.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().playerGold < towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = false;
            }else if (GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().playerGold >= towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = true;
            }
        }
    }
}
