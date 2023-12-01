using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EvalynnStats : MonoBehaviour
{
    public static EvalynnStats instance;

    public int health = 100;
    public int mana = 100;
    public int moveSpeed = 5;
    public int AbilityPower = 100;
    public float cooldownReduction = 0.2f;
    public Vector3 target;
    // public Vector3 currentRot;
    public GameObject player;
    public Movement move;  // Declare the Movement variable at the class level
    public  Vector3 playerPos;
    public  Quaternion playerRot;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EvalynnStats found!");
            return;
        }

        instance = this;
    }
    void Start()
    {
        
        //move = GetComponent<Movement>();
        if (move != null)
        {
            UpdateTarget();
            Debug.Log("move is not null");
        }
        Debug.Log("move is null");
        //transform.rotation = new Vector3 currentRot;
    }

    void Update()
    {
        playerPos = transform.position;
        playerRot = transform.rotation;
        // Only update the target if currentMoveTarget changes
        if (move != null)
        {
            UpdateTarget();
        }

        //set the new target position
        float targetX = target.x;
        float targetZ = target.z;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, targetZ);

        //look at and move to new directions
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Call the moveToPoint method if needed
        //moveToPoint();
    }

    void UpdateTarget()
    {
        //Update the target to always match currentMoveTarget
        target = move.currentMoveTarget;
    }
}


