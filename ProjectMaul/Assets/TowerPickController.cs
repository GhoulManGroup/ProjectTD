using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerPickController : MonoBehaviour
{

    [SerializeField]
    List<Tower> towerList = new List<Tower>();
    [SerializeField]
    List<Button> towerPickBTNs = new List<Button>();
    LevelManager LvlManager;
    [SerializeField]
    TextMeshProUGUI Timer;
    [SerializeField]
    TextMeshProUGUI Gold;
    [SerializeField]
    TextMeshProUGUI Life;

    public void activeTower(int towerPicked)
    {
        GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().activeTower = towerList[towerPicked];
    }

    public void Start()
    {
        AffordanceCheck();
        LvlManager = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<LevelManager>();
    }

    public void AffordanceCheck()
    {
        for (int i = 0; i < towerList.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().playerGold < towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = false;
            }
            else if (GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().playerGold >= towerList[i].Cost)
            {
                towerPickBTNs[i].interactable = true;
            }
        }
    }

    public void UpdateGold()
    {
        Gold.text = "Current Gold : " + LvlManager.playerGold.ToString();
    }

    public void UpdateLife()
    {
        Life.text = "Current Life : " + LvlManager.playerLife.ToString();
    }
    
    public void UpdateTimer()
    {

    }
}
