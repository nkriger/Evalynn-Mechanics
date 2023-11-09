using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{

    public GameObject launchPoint;
    public GameObject prefabProjectile;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
        
    }
    private void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        print("Mouse entered");
    
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        print("Mouse exited");
    
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        projectile = Instantiate(prefabProjectile);

        projectile.transform.position = launchPos;
        
        projectile.GetComponent<Rigidbody>().isKinematic = true;


    }
}
