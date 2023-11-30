using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
   



    static public bool goalMat = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Goal.goalMat = true;

            //feedback
            Color c = GetComponent<Renderer>().material.color;

            c.a = 1.0f;
            GetComponent<Renderer>().material.color = c;
        }
    }
}
