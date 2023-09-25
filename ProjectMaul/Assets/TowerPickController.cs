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

    public void activeTower(int towerPicked)
    {
        GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelManager>().activeTower = towerList[towerPicked];
    }

    public void AffordanceCheck()
    {
        for (int i = 0; i < towerList.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelManager>().playerGold < towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = false;
            }else if (GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelManager>().playerGold >= towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = true;
            }
        }
    }
}
