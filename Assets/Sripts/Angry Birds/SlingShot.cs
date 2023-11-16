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

    private void Update()
    {
        mouseDetection();
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

    private void mouseDetection()
    {
        //if the slingshot is now in aiming mode dont run this code
        if (!aimingMode) return;

        //get the current mouse position in 2d screen coordinates
        Vector3 mousePos2D = Input.mousePosition;

        //convert the mouse position to 3d world coordinates
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * 10f;
            FollowCam.Instance.poi = projectile;

            projectile = null;
        }
    }

}
