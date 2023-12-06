using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HateReap : MonoBehaviour
{
    public GameObject slash;
    public int reapDamage;
    public bool hasHit;

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 30 * Time.deltaTime);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!hasHit)
            {
                hasHit = true;
                collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - reapDamage;
            }
            
            Debug.Log("enemy hit");
            
        }
        if (collision.gameObject.tag == "ReapPath")
        {
            Destroy(slash);
        }
    }

    
}
