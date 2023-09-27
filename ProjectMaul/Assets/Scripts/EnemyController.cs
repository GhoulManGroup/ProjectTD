using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject pathManager;
    PathController pathScript;
    LevelManager levelScript;

    [Header("Enemy Variables")]

    int startingHealth = 100;
    int currentHealth;

    int damage = 50;

    int bounty = 10;

    [SerializeField]
    float movementSpeed = 3;

    [Header("Pathfinding")]
    private bool destinationReached = false; // reached the end of the path.
    int path; //Which path we are using from the path list.
    int currentPoint; // Which point in the path we are currently going towards.

    // Start is called before the first frame update
    void Start()
    {
        pathManager = GameObject.FindGameObjectWithTag("PathManager");
        pathScript = pathManager.GetComponent<PathController>();
        levelScript = pathManager.GetComponent<LevelManager>();
        currentHealth = startingHealth;
        AssignPath();
        StartCoroutine("Movement");
    }

    public void AssignPath()
    {
        path = 0;
        currentPoint = 0;
        this.transform.position = pathManager.GetComponent<PathController>().LevelPaths[0].Levelpath[currentPoint].transform.position;
    }

    public IEnumerator Movement()
    {
        while(destinationReached == false)
        {
            Destination();
            Speed();
            yield return null;
        }
    }

    private void Destination()
    {

        if (transform.position == pathScript.LevelPaths[0].Levelpath[currentPoint].transform.position)
        {
            if (currentPoint == pathScript.LevelPaths[0].Levelpath.Count - 1)
            {
                Debug.Log("Reached End");
                destinationReached = true;
                GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().TakeDamage(damage);
                StartCoroutine("RemoveMe");
            }
            else
            {
                currentPoint += 1;
            }
        }
    }

    private void Speed()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathScript.LevelPaths[0].Levelpath[currentPoint].transform.position, movementSpeed * Time.deltaTime);
    }

    public void UpdateMovementSpeed(float newValue)
    {
        movementSpeed = newValue;
    }

    public void TakeDamage(int damage, GameObject source )
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.LogError("DEAD!");
            levelScript.playerGold += bounty;
            GameObject.FindGameObjectWithTag("CanvasManager").GetComponentInChildren<TowerPickController>().AffordanceCheck();
            StartCoroutine("RemoveMe");
        }
    }

    public IEnumerator RemoveMe()
    {
        for (int i = 0; i < GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers.Contains(this.gameObject))
            {
                GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers[i].GetComponent<TowerController>().targetList.Remove(this.gameObject);
                GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers[i].GetComponent<TowerController>().objectCurrentTarget = null;
               GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers[i].GetComponent<TowerController>().pickTarget();
            }
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    
}
