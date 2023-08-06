using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Variables")]
    int health;
    int damage;
    int movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool destinationReached;

    public IEnumerator Movement()
    {
        while(destinationReached == false)
        {
            Destination();
            Speed();
            yield return null;
        }

        yield return null;
    }

    private void Destination()
    {

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
