using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject Player;

    public GameObject moveTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseTracking();
    }

    private void mouseTracking()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
    }

    private void OnMouseDown()
    {
        Debug.Log("moveto point");
        Instantiate(moveTarget, transform.position, Quaternion.identity);
    }

}
