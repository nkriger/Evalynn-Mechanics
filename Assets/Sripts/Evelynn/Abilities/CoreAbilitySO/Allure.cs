using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

[CreateAssetMenu]
public class Allure : AbilitySO
{
    public GameObject AllurePrefab;
    public GameObject[] enemies;
    public GameObject highlightedPos;
    public GameObject Evalyn;

    public int currentHp;

    public override void Activate()
    {

        Debug.Log("Allure");
        

        if (AbilityParent.instance.WReady == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject Evalyn = GameObject.FindGameObjectWithTag("Player");
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

                            AbilityParent.instance.wImage.fillAmount = 1;

                            // Update the target of the ability
                            UpdateTarget();
                            EvalynnStats.instance.isMoving = false;

                            lookAtTarget();
                            Instantiate(AllurePrefab, enemy.transform.position, enemy.transform.rotation, enemy.transform);
                            Debug.Log("Instantiates Allure");
                            
                            EvalynnStats.instance.isMoving = true;
                            AbilityParent.instance.WReady = false;
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
                Debug.Log("no enemies detected");
            }
            
            
        }
        else
        {
            Debug.Log("On Cooldown");
            return;
        }

    }
}
