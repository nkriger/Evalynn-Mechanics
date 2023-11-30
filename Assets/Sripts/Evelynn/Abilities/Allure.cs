using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

[CreateAssetMenu]
public class Allure : AbilitySO
{

    public float AllureT2Timer;
    public GameObject AllureT1;
    public GameObject AllureT2;

    public GameObject AllureTarget;



    public override void Activate()
    {
        Debug.Log("Allure");
    }
}
