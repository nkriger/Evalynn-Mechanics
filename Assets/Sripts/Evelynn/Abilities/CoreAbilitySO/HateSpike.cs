using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu]
public class HateSpike : AbilitySO
{
    public GameObject hateReap; 
    public float SpikeSpeed;
    public GameObject SpikePrefab;
    public float castRange;
    //public int damage;
    //public bool isOnCooldown;
    public int cooldownTime;
    public int HateReap;
    //AbilityParent AbilityParent;

    public override async void Activate()
    {
        if (AbilityParent.instance.QReady == true)
        {
            AbilityParent.instance.qImage.fillAmount = 1;
            AbilityParent.instance.QReady = false;
            // Update the target of the ability
            UpdateTarget();
            EvalynnStats.instance.isMoving = false;
            AbilityTarget = Movement.instance.currentMoveTarget;

            lookAtTarget();

            await Task.Delay(castTime);
            // Instantiate the SpikePrefab at the player's position and rotation

            GameObject spike = Instantiate(SpikePrefab, playerPos, playerRot);
            /*
            Rigidbody rb = spike.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (AbilityTarget - playerPos).normalized;
                rb.AddForce(direction * SpikeSpeed, ForceMode.Impulse);
            }
            */
            EvalynnStats.instance.isMoving = true;
            HateReap = 3;
            Debug.Log("Hate Spike");

        }
        else
        {
            if (HateReap != 0)
            {
                //pull from the ObjectTracker class to find nearest Enemy
                ObjectTracker.instance.findNearestEnemy();
                GameObject nearestEnemyOBJ = ObjectTracker.instance.nearestEnemyOBJ;

                if (nearestEnemyOBJ != null)
                {
                    // Calculate the direction towards the enemy
                    Vector3 directionToEnemy = nearestEnemyOBJ.transform.position - playerPos;

                    // Create a rotation that looks in the direction of the enemy
                    Quaternion rotationToEnemy = Quaternion.LookRotation(directionToEnemy);
                    //create a sepearte position equal to player position
                    Vector3 reapPos = playerPos;                   

                    // Instantiate the hateReap at the new position and rotate it to face the nearestenemy
                    Instantiate(hateReap, reapPos, rotationToEnemy);
                    HateReap--;
                }
                else
                {
                    Debug.Log("No enemy found");
                }
            }
            else
            {
                Debug.Log("On Cooldown");
                return;
            }
            
        }
    }
}
