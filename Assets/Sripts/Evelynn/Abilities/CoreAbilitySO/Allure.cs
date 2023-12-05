using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Allure : AbilitySO
{
    public GameObject AllurePrefab;

    
    public override void Activate()
    {

        Debug.Log("Allure");

        if (AbilityParent.instance.WReady == true)
        {
            AbilityParent.instance.wImage.fillAmount = 1;
            // Update the target of the ability
            UpdateTarget();
            EvalynnStats.instance.isMoving = false;
            AbilityTarget = Movement.instance.currentMoveTarget;

            lookAtTarget();  

            // Instantiate the AllurePrefab at the player's position and rotation
            Instantiate(AllurePrefab, playerPos, playerRot);
            //GameObject Allure2 = Instantiate(AllureT2, playerPos, playerRot);

            // If you want the Allure to move towards the AbilityTarget, you could add a Rigidbody component to the AllurePrefab and apply a force to it
            Rigidbody rb = Allure.GetComponent<Rigidbody>();
            //Rigidbody rb2 = Allure2.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (AbilityTarget - playerPos).normalized;
                rb.AddForce(direction * AllureT2Timer, ForceMode.Impulse);
                //rb2.AddForce(direction * AllureT2Timer, ForceMode.Impulse);
            }
            EvalynnStats.instance.isMoving = true;
            AbilityParent.instance.WReady = false;
            Debug.Log("Allure");
        }
        else
        {
            Debug.Log("On Cooldown");
            return;
        }

    }
}
