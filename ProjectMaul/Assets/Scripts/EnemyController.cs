using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject pathManager;
    PathController pathScript;

    [Header("Enemy Variables")]

    int startingHealth = 100;
    int currentHealth;
    int damage;
    float movementSpeed;

    [Header("Pathfinding")]
    private bool destinationReached = false; // reached the end of the path.
    int path; //Which path we are using from the path list.
    int currentPoint; // Which point in the path we are currently going towards.

    // Start is called before the first frame update
    void Start()
    {
        pathScript = pathManager.GetComponent<PathController>();
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        CheckState();
    }

    private void CheckState()
    {
        if (currentHealth >= 0)
        {
            // contact wave manager and say I died
            // move me off screen away from the rest of the game.
            this.gameObject.SetActive(false);
        }
    }
}
