using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FollowCam : MonoBehaviour
{

    static public FollowCam Instance;

    public GameObject poi;

    public float camZ;

    public float easing;

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
        if (poi == null) return;

        //get the position of the poi
        Vector3 destination = poi.transform.position;
        //retain the destination z value
        destination.z = camZ;

        //move camera to destination
        transform.position = destination;

        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;

        transform.position = destination;
    }

    //had questions to get this working but needed to leae to make it to next class on time


}
