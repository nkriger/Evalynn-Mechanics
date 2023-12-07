using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static AbilityParent;
using static UnityEngine.GraphicsBuffer;

public class AbilitySO : ScriptableObject
{

    public string AbilityName;
    public float activeTime;
    public int castTime;
    public Vector3 playerPos;
    public Quaternion playerRot;
    public int damage;

    
    public Vector3 AbilityTarget;
    public KeyCode abilityKey;
    

    
   
    public virtual void Activate()
    {

    }
    public void Update()
    {
        //always keep track of the players Position and Rotation
        playerPos = EvalynnStats.instance.playerPos;
        playerRot = EvalynnStats.instance.playerRot;
    }
    public void lookAtTarget()
    {
        UpdateTarget();
        
        Vector3 abilityPosition = new Vector3(AbilityTarget.x, playerPos.y, AbilityTarget.z);

        // Look at and move to new directions
        EvalynnStats.instance.transform.LookAt(abilityPosition);
    }
    public void UpdateTarget()
    {
        //Update the Vector 3 to be the mouses position at time of ability press
        AbilityTarget = Movement.instance.mousePos;
    }
}
