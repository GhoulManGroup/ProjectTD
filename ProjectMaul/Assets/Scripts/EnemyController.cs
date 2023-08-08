using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    PathController PathManager;

    [Header("Enemy Variables")]
    int health;
    int damage;
    int movementSpeed;

    [Header("Pathfinding")]
    private bool destinationReached; // reached the end of the path.
    int path; //Which path we are using from the path list.
    int currentPoint; // Which point in the path we are currently going towards.

    // Start is called before the first frame update
    void Start()
    {
        PathController PathManager = GameObject.FindGameObjectWithTag("PathManager").GetComponent<PathController>();
        AssignPath();
        StartCoroutine("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AssignPath()
    {
        path = 0;
        currentPoint = 0;
        this.transform.position = PathManager.LevelPaths[0].Levelpath[currentPoint].transform.position;
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
        transform.position = Vector3.MoveTowards(transform.position, PathManager.LevelPaths[0].Levelpath[currentPoint].transform.position, 1);

        if (transform.position == PathManager.LevelPaths[0].Levelpath[currentPoint].transform.position)
        {
            currentPoint += 1;
        }
    }

    public void UpdateDestination()
    {

    }

    private void Speed()
    {

    }

    public void UpdateMovementSpeed()
    {

    }
}
