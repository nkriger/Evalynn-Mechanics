using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.UIElements.Experimental;

/// <summary>
/// Follow Cam
/// 1. cam sits at initial pos. Doesnt move during aimingmode
/// 2. once projectile is launched, cam will follow projectile (with some easing for more natural feel)
/// 3. as cam moves up in the air, need to "zoom out" so we can still see the ground
/// 4. when projectile is at rest, stop following and return to initial pos
/// 
/// problems to fix
/// 1. projectile flies past the end of our ground DONE
/// 2. projectile neither bounces or stops once it hits the ground DONE
/// 3. when projectile is launched, camera jumps to position of poi (looks bad) DONE
/// 4. when projectile is at a certain height all we see is sky (hard to judge where projectile is) DONE
/// </summary>
public class FollowCam : MonoBehaviour
{
    //Singlton
    static public FollowCam Instance;

    //Need something to follow
    public GameObject poi;

    //Initial Z pos of the camera (back at the slingshot)
    public float camZ;

    //easing value
    public float easing = 0.05f;

    //limit for x and y values
    public Vector2 minXY;
    

    //initialize our Singleton
    private void Awake()
    {
        Instance = this;
        camZ = this.transform.position.z;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 destination;
        //lets not run this unless we have to
        if (poi == null)
        {
            destination = Vector3.zero;

        }
        else
        {
            destination = poi.transform.position;
            if (poi.tag == "projectile")
            {
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    poi = null;
                }
            }
        } 

        //get position of poi (the thing I want to follow)
        
        //retain the destination z value
        destination.z = camZ;

        //Limit cams x and y
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        //calculate interpolation towards poi
        destination = Vector3.Lerp(transform.position, destination, easing);

        //retain the destination.z of camZ
        destination.z = camZ;

        //move camera to the destination
        transform.position = destination;

        //Set orthographic size to keep the ground in view. Camera size will scale based on the height of the camera
        GetComponent<Camera>().orthographicSize = destination.y + 10f;
    }

    //had questions to get this working but needed to leae to make it to next class on time


}
