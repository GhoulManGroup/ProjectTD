using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTile : MonoBehaviour
{
    public GameObject SpawnTower;
    public void OnMouseDown()
    {
        Instantiate(SpawnTower, new Vector3(this.transform.position.x, 0.6f, this.transform.position.z), Quaternion.identity);
    }


}
