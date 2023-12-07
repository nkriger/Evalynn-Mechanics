using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Whiplash : AbilitySO
{
    public GameObject WhiplashPrefab;
    public GameObject player;
    public GameObject[] enemies;
    public Vector3 highlightedPos;
    public bool Ehit;

    public int currentHp;
    public override void Activate()
    {
        Debug.Log("Whiplash");
        if (AbilityParent.instance.EReady == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    Enemy enemyScript = enemy.GetComponent<Enemy>();
                    if (enemyScript != null)
                    {
                        //check if highlighted
                        if (enemyScript.highlighted == true)
                        {
                            //highlightedPos = highlightedEnemy.transform.position;

                            AbilityParent.instance.eImage.fillAmount = 1;

                            // Update the target of the ability
                            UpdateTarget();
                            EvalynnStats.instance.isMoving = false;
                            Instantiate(WhiplashPrefab, enemy.transform.position, enemy.transform.rotation, enemy.transform);
                            EvalynnStats.instance.targetToDash = enemy.transform.position;                         
                            lookAtTarget();                          
                            Debug.Log("Instantiates Whiplash");
                            EvalynnStats.instance.isDashing = true;
                            //EvalynnStats.instance.isMoving = true;
                            if (Ehit == true)
                            {
                                enemyScript.health -= damage;
                                AbilityParent.instance.EReady = false;
                            }                         
                        }
                    }
                    else
                    {
                        Debug.Log("Target Not found");
                    }
                }
            }
            else
            {
                Debug.Log("No enemies found");
            }
        }
        else
        {
            Debug.Log("Whiplash not ready");
        }
    }
    
   
}

