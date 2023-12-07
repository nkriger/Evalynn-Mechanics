using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingEmbrace : MonoBehaviour
{
    public GameObject leftSlash;
    public GameObject rightSlash;
    public DeathsEmbrace deathsEmbrace;
    public float slashSpeed = 10f;

    public int LeftslashMaxAngle = 120;
    public int RightslashMaxAngle = -120;


    private void Update()
    {
        leftSlashing();
        rightSlashing();
    }

    private void leftSlashing()
    {
        if (leftSlash.transform.rotation.y < LeftslashMaxAngle)
        {
            leftSlash.transform.RotateAround(transform.position, Vector3.up, LeftslashMaxAngle * 5 * Time.deltaTime);
        }
        else
        {
            Debug.Log("Left Slash Destroyed");
            Destroy(gameObject);
        }
    }
    private void rightSlashing()
    {
        if (rightSlash.transform.rotation.y > RightslashMaxAngle)
        {
            rightSlash.transform.RotateAround(transform.position, Vector3.up, RightslashMaxAngle * 5 * Time.deltaTime);
        }
        else
        {
            Debug.Log("Right Slash Destroyed");   
            Destroy(gameObject);
        }
    }

}
