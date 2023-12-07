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
    public Movement move;  
    public  Vector3 playerPos;
    public  Quaternion playerRot;
   
    public Vector3 targetToDash;
    public GameObject targetedEnemy;
    public Whiplash whiplash;

    public bool isDashing;
    public bool isMoving = true;
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
        lookAtTarget();
        WhipDash();
       
    }

    void lookAtTarget()
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
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(targetPosition);
        }
        //look at and move to new directions
    }

    void UpdateTarget()
    {
        //Update the target to always match currentMoveTarget
        target = move.currentMoveTarget;
    }

    public void WhipDash()
    {
        if (isDashing == true)
        {
            //transform.LookAt(WhiplashPrefab.transform.position);
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetToDash, 15 * Time.deltaTime);
            if (player.transform.position == targetToDash)
            {
                
                AbilityParent.instance.EReady = false;
                isDashing = false;
                isMoving = true;                
            }
        }

    }
}


