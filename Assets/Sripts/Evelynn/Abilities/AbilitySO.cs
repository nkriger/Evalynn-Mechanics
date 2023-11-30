using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AbilitySO : ScriptableObject
{
    public new string AbilityName;
    public float activeTime;
    public float castTime;
    
    public Vector3 AbilityTarget;
    public KeyCode abilityKey;

    void Start()
    {
        if (Movement.instance != null)
        {
            UpdateAbilityTarget();
            Debug.Log("move is not null");
        }
        Debug.Log("move is null");
    }
    public void UpdateAbilityTarget()
    {
        //Update the target to always match currentMoveTarget
        AbilityTarget = Movement.instance.mousePos;
    }
    public virtual void Activate()
    {

    }

    
}
