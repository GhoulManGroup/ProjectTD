using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    public GameObject Parent;

    float projectileSpeed = 0.03f;
    bool targetReached = false;
    GameObject target;

    public void startShoot(GameObject enemy)
    {
        StartCoroutine(shootAt(enemy));
    }
    public IEnumerator shootAt(GameObject targetEnemy = null, Transform targetPoint = null)
    {
        targetReached = false;
        if (targetEnemy != null) { target = targetEnemy; }

        while (targetReached == false)
        {
            yield return null;
            if (targetEnemy == null && targetPoint == null)
            {
                Debug.LogError("No target deleteing projectile");
                Destroy(this.gameObject);
            }
            else if (targetEnemy != null && targetPoint == null)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, projectileSpeed);

            } else if (targetEnemy == null && targetPoint != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, projectileSpeed * Time.deltaTime);

                if (transform.position == targetPoint.position)
                {
                    targetReached = true;
                }
            }
        }
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            other.GetComponent<EnemyController>().TakeDamage(25, Parent);
            Destroy(this.gameObject);
            targetReached = true;
        }
    }


}

