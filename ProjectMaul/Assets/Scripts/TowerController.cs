using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class TowerController : MonoBehaviour
{

    public GameObject objectCurrentTarget = null; // current target;

    public List<GameObject> targetList = new List<GameObject>(); // stores all possible targets.

    public GameObject Projectile;

    public Tower MyTower;

    [Header("Attack Details")]
    float attackTimer = 3;
    int damage;
    public int myCost = 25;

    public void Start()
    {
        GameObject.FindGameObjectWithTag("PathManager").GetComponent<LevelManager>().currentTowers.Add(this.gameObject);
        
    }

    public void pickTarget()
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] == null)
            {
                targetList.RemoveAt(i);
                Debug.Log("found bugger");
            }
        }

        if (objectCurrentTarget != null)
        {

        }
        else
        {
            if (targetList.Count != 0)
            {
                objectCurrentTarget = targetList[0];
                StartCoroutine("attack");
            }
            else
            {
                Debug.Log("No Targets");
            }
        }
    }

    IEnumerator attack()
    {
        GameObject Shot = Instantiate(Projectile, transform.position, Quaternion.identity);
        Shot.GetComponent<Projectile>().Parent = this.gameObject;
        Shot.GetComponent<Projectile>().startShoot(objectCurrentTarget);
        yield return new WaitForSeconds(attackTimer);
        if (objectCurrentTarget != null)
        {
            StartCoroutine("attack");
        }
        yield return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            targetList.Add(other.gameObject);
            pickTarget();
        }
        else
        {
            Debug.Log("wJHY");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        targetList.Remove(other.gameObject);
        pickTarget();
    }

}
