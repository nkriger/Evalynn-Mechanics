using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HSpikeMovement : MonoBehaviour
{
    public float SpikeSpeed;
    public GameObject deathsKissMarks;
    public bool plantedMark;
    public bool Qhit;
    public HateSpike hateSpike;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * SpikeSpeed * Time.deltaTime);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
         if (collision.gameObject.tag == "Enemy")
         {
            if (!Qhit)
            {
                if (hateSpike != null)
                {
                    collision.gameObject.GetComponent<Enemy>().health -= hateSpike.damage;
                    Qhit = true;
                    Debug.Log("Hit Enemy");
                    if (plantedMark == false)
                    {
                        GameObject childObject = Instantiate(deathsKissMarks, collision.transform.position, Quaternion.identity, collision.transform);
                        plantedMark = true;
                    }
                }                
            }  
         }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Qrange")
        {
            gameObject.SetActive(false);
            Debug.Log("Out of range");
        }
    }
}
