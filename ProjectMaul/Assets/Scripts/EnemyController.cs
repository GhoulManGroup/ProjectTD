using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Variables")]
    int health;
    int damage;
    int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        AssignPath();
        StartCoroutine("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool destinationReached;
    int path;
    int currentPoint;
    public void AssignPath()
    {
        GameObject.FindGameObjectWithTag("PathController");
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
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
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
