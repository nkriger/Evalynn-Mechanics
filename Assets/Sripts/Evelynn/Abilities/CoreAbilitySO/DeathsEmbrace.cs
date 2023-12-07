using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DeathsEmbrace : AbilitySO
{
    public GameObject slashingEmbrace;
    public override void Activate()
    {
        if (AbilityParent.instance.RReady == true)
        {
            AbilityParent.instance.rImage.fillAmount = 1;
            AbilityParent.instance.RReady = false;
            // Update the target of the ability
            UpdateTarget();
            EvalynnStats.instance.isMoving = false;
            AbilityTarget = Movement.instance.currentMoveTarget;

            lookAtTarget();         
            // Instantiate the SpikePrefab at the player's position and rotation
            Instantiate(slashingEmbrace, playerPos, playerRot);
            //EvalynnStats.instance.isMoving = true;
            
            Debug.Log("Deaths Embrace!!!");
        }
    }
}
