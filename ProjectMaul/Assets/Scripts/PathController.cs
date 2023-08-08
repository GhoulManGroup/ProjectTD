using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public static PathController pathController;

    [System.Serializable] 
    public class SerializableClass
    {
        public List<GameObject> Levelpath;
    }
    public List<SerializableClass> LevelPaths = new List<SerializableClass>();

    public void DirectEnemey(int List, int currentGameObject)
    {

    }

}
