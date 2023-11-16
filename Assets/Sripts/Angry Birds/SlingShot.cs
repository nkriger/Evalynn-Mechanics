using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    public GameObject prefabProjectile;

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    public float velocityMult = 4f;

    private void Awake()
    {
        Transform launchPointTrans = transform.Find("launchPoint");
        launchPoint = launchPointTrans.gameObject;
        if(launchPoint == null)
        {
            Debug.LogWarning("SlingShot.Awake launchPoint is null");
        }
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void Update()
    {
        //if slingshot is not in aimingmode, dont run this code
        if (!aimingMode) return;

        //get the current mouse position in 2D screen space
        Vector3 mousePos2D = Input.mousePosition;

        //convert the mouse pos 2d into 3d space
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta from the launch pos to the new mousePos3D
        //delta means find the difference
        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit mouseDelta to the radius of the slingshot sphere collider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;

        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            //mouse was released
            aimingMode = false;

            //fire the projectile
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

            FollowCam.Instance.poi = projectile;

            //now forget that projectile, so we can shoot another.
            projectile = null;
        }
    }

    private void OnMouseDown()
    {
        //player has pressed the mouse button while over slingshot
        aimingMode = true;

        //instantiate projectile
        projectile = Instantiate(prefabProjectile);

        //start it at the launch point
        projectile.transform.position = launchPos;

        //set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnMouseEnter()
    {
        //Debug.Log("Slingshot.OnMouseEnter");
        launchPoint.SetActive(true);

    }

    private void OnMouseExit()
    {
        //Debug.Log("Slingshot.OnMouseExit");
        launchPoint.SetActive(false);
    }
}
