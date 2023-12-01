using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

[CreateAssetMenu]
public class HateSpike : AbilitySO
{
    public float SpikeSpeed;
    
    public GameObject SpikePrefab;
   
    
    public override void Activate()
    {
        // Update the target of the ability
        UpdateAbilityTarget();

        // Instantiate the SpikePrefab at the player's position and rotation
        GameObject spike = Instantiate(SpikePrefab, playerPos, playerRot);

        // If you want the spike to move towards the AbilityTarget, you could add a Rigidbody component to the SpikePrefab and apply a force to it
        Rigidbody rb = spike.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (AbilityTarget - playerPos).normalized;
            rb.AddForce(direction * SpikeSpeed, ForceMode.Impulse);
        }

        Debug.Log("Hate Spike");
    }
}
