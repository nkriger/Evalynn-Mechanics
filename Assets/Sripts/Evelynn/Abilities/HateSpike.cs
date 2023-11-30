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
    public Vector3 SpikeDirection;
    
    public override void Activate()
    {
        UpdateAbilityTarget();
        Instantiate(SpikePrefab, SpikePrefab.transform.position, SpikePrefab.transform.rotation);
        SpikeDirection = AbilityTarget - SpikePrefab.transform.position;
    }
}
