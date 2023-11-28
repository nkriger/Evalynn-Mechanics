using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLine : MonoBehaviour
{
    static public projectileLine Instance;
    public float minDist = 0.1f;
    public LineRenderer line;
    private GameObject _poi;
    public List<Vector3> points;

    

    private void Awake()
    {
        //setup singleton
        Instance = this;

        //set a referance to the LineRenderer
        line = GetComponent<LineRenderer>();

        //disable the line render
        line.enabled = false;

        //initialize the points list
        points = new List<Vector3>();

    }

    public GameObject poiProperty
    {
        get
        {
            return _poi;
        }
        set
        {
            _poi = value;
            //when _poi is set to a new value, it reset everything
            if(_poi != null) 
            {
                line.enabled = false;
                points = new List<Vector3> ();
                AddPoint();
            }
        }
    }

    //we need to add points threw the line
    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            //if the point isnt far enough from the last point we drew return
            return;
        }
        if(points.Count == 0 )
        {
            //this is the launch point

            Vector3 laumchPos = Slingshot.Instance.launchPoint.transform.position;
            Vector3 launchPointDiff = pt - laumchPos;

            //add an extra bit of line to aid aiming
            points.Add(pt + launchPointDiff);
            points.Add(pt);
            line.positionCount = 2;

            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);

            line.enabled = true;


        }
        else
        {
            //normal projectile in flight behavior
            points.Add(pt);
            
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }
    }
    //returns the location of the most recently added point
    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
            {
                //if no points, then return the zero vector as a default
                return Vector3.zero;
            }

            return points[points.Count - 1];
        }
    }

    // a fucntion to clear the line

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        //if no poi go fine one
        if (poiProperty == null)
        {
            if (FollowCam.Instance.poi != null)
            {
                //follow cam is follwing something lets make sure we know what it is
                if (FollowCam.Instance.poi.tag == "projectile")
                {
                    poiProperty = FollowCam.Instance.poi;
                    Debug.Log("POI RESET");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        AddPoint();

        if (poiProperty.GetComponent<Rigidbody>().IsSleeping())
        {
            Clear();
            poiProperty = null;
        }
        
        
    }



}
