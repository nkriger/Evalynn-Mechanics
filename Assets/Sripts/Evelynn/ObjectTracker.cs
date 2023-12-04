using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTracker : MonoBehaviour
{
    public static ObjectTracker instance;

    public GameObject[] enemies;
    public GameObject nearestEnemyOBJ;
    public Vector3 objectPOS;
    
    private float distance;
    private float nearestEnemy = 1000000;
    public bool isTracking;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ObjectTracker found!");
            return;
        }
        instance = this;
    }
    public void findNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            //check distance between player and enemy
            distance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distance < nearestEnemy)
            {
                nearestEnemyOBJ = enemies[i];
                nearestEnemy = distance;
            }
        }

    }
}
