using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HateReap : MonoBehaviour
{
    public GameObject slash;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 30 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health = (10);
            
        }
        if (collision.gameObject.tag == "ReapPath")
        {
            Destroy(slash);
        }
    }

    
}
